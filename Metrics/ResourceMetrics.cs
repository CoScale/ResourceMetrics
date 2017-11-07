using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace App.Metrics.AspNetCore.Resource.Metrics
{
    public class ResourceMetrics
    {
        private volatile Boolean running;

        public ResourceMetrics()
        {
            running = true;
            CheckGCTime();
        }

        public long MaxWorkingSet { get { return Process.GetCurrentProcess().MaxWorkingSet.ToInt64(); } }

        public long NonpagedSystemMemorySize64 { get { return Process.GetCurrentProcess().NonpagedSystemMemorySize64; } }

        public long PagedMemorySize64 { get { return Process.GetCurrentProcess().PagedMemorySize64; } }

        public long PeakPagedMemorySize64 { get { return Process.GetCurrentProcess().PeakPagedMemorySize64; } }

        public long PeakWorkingSet64 { get { return Process.GetCurrentProcess().PeakWorkingSet64; } }

        public double TotalProcessorTime { get { return Process.GetCurrentProcess().TotalProcessorTime.TotalMilliseconds; } }

        public double UserProcessorTime { get { return Process.GetCurrentProcess().UserProcessorTime.TotalMilliseconds; } }

        public long VirtualMemorySize64 { get { return Process.GetCurrentProcess().VirtualMemorySize64; } }

        public long WorkingSet64 { get { return Process.GetCurrentProcess().WorkingSet64; } }

        public int ThreadsCount { get { return Process.GetCurrentProcess().Threads.Count; } }

        public int GCCollectionCount { get {
                int total = 0;
                for (var i = 0; i < GC.MaxGeneration; i++)
                {
                    total += GC.CollectionCount(i);
                }
                return total;
            }
        }

        public long GCTotalMemory { get { return GC.GetTotalMemory(false); } }

        private long _lastGCTime;

        public long LastGCTime { get
            {
                Interlocked.Increment(ref _lastGCTime);
                try
                {
                    return _lastGCTime;
                }
                finally
                {
                    Interlocked.Decrement(ref _lastGCTime);
                }
            }
        }

        private void CheckGCTime()
        {
            var pollGC = new Action(() =>
            {
                // Register for a notification.
                GC.RegisterForFullGCNotification(10, 10);

                Stopwatch gcTimer = new Stopwatch();

                while (running)
                {
                    // Check for a notification of an approaching collection.
                    GCNotificationStatus s = GC.WaitForFullGCApproach();
                    if (s == GCNotificationStatus.Succeeded)
                    {
                        // GC is about to start.
                        gcTimer.Restart();
                    }

                    // Check for a notification of a completed collection.
                    s = GC.WaitForFullGCComplete();
                    if (s == GCNotificationStatus.Succeeded)
                    {
                        Interlocked.Increment(ref _lastGCTime);
                        try
                        {
                            _lastGCTime = gcTimer.ElapsedMilliseconds;
                        }
                        finally
                        {
                            Interlocked.Decrement(ref _lastGCTime);
                        }
                    }

                    Thread.Sleep(500);
                }
                // Finishing monitoring GC.
                GC.CancelFullGCNotification();
            });
            Task.Run(pollGC);
        }
    }
}
