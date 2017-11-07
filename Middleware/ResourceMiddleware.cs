using App.Metrics.AspNetCore.Resource.Metrics;
using App.Metrics.Gauge;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace App.Metrics.AspNetCore.Resource.Middleware
{
    // ReSharper disable ClassNeverInstantiated.Global
    public class ResourceMiddleware
    // ReSharper restore ClassNeverInstantiated.Global
    {
        private const string ResourceItemsKey = "__App.Metrics.Resource__";
        private readonly ILogger<ResourceMiddleware> _logger;
        private readonly RequestDelegate _next;
        private IMetrics _metrics;

        private IGauge _maxWorkingSet;
        private IGauge _pagedMemorySize64;
        private IGauge _nonpagedSystemMemorySize64;
        private IGauge _peakPagedMemorySize64;
        private IGauge _peakWorkingSet64;
        private IGauge _totalProcessorTime;
        private IGauge _userProcessorTime;
        private IGauge _virtualMemorySize64;
        private IGauge _workingSet64;
        private IGauge _threadsCount;
        private IGauge _gcCollectionCount;
        private IGauge _gcTotalMemory;
        private IGauge _lastGCTime;

        private ResourceMetrics _ResourceMetrics = new ResourceMetrics();

        public ResourceMiddleware(
            RequestDelegate next,
            ILogger<ResourceMiddleware> logger,
            IOptions<ResourceMetricsOptions> ResourceMetricsOptionsAccessor,
            IMetrics metrics)
        {
            _logger = logger;
            _next = next;
            _metrics = metrics;

            // Setup the metrics.
            _maxWorkingSet = _metrics.Provider.Gauge.Instance(ResourceMetricsRegistry.MaxWorkingSetGauge);
            _pagedMemorySize64 = _metrics.Provider.Gauge.Instance(ResourceMetricsRegistry.PagedMemorySize64Gauge);
            _nonpagedSystemMemorySize64 = _metrics.Provider.Gauge.Instance(ResourceMetricsRegistry.NonpagedSystemMemorySize64Gauge);
            _peakPagedMemorySize64 = _metrics.Provider.Gauge.Instance(ResourceMetricsRegistry.PeakPagedMemorySize64Gauge);
            _peakWorkingSet64 = _metrics.Provider.Gauge.Instance(ResourceMetricsRegistry.PeakWorkingSet64Gauge);
            _totalProcessorTime = _metrics.Provider.Gauge.Instance(ResourceMetricsRegistry.TotalProcessorTimeGauge);
            _userProcessorTime = _metrics.Provider.Gauge.Instance(ResourceMetricsRegistry.UserProcessorTimeGauge);
            _virtualMemorySize64 = _metrics.Provider.Gauge.Instance(ResourceMetricsRegistry.VirtualMemorySize64Gauge);
            _workingSet64 = _metrics.Provider.Gauge.Instance(ResourceMetricsRegistry.WorkingSet64Gauge);
            _threadsCount = _metrics.Provider.Gauge.Instance(ResourceMetricsRegistry.ThreadsCountGauge);
            _gcCollectionCount = _metrics.Provider.Gauge.Instance(ResourceMetricsRegistry.GCCollectionCountGauge);
            _gcTotalMemory = _metrics.Provider.Gauge.Instance(ResourceMetricsRegistry.GCTotalMemoryGauge);
            _lastGCTime = _metrics.Provider.Gauge.Instance(ResourceMetricsRegistry.LastGCTimeGauge);
        }

        // ReSharper disable UnusedMember.Global
        public async Task Invoke(HttpContext context)
        // ReSharper restore UnusedMember.Global
        {
            _logger.MiddlewareExecuting<ResourceMiddleware>();

            _maxWorkingSet.SetValue(_ResourceMetrics.MaxWorkingSet);
            _pagedMemorySize64.SetValue(_ResourceMetrics.PagedMemorySize64);
            _nonpagedSystemMemorySize64.SetValue(_ResourceMetrics.NonpagedSystemMemorySize64);
            _peakPagedMemorySize64.SetValue(_ResourceMetrics.PeakPagedMemorySize64);
            _peakWorkingSet64.SetValue(_ResourceMetrics.PeakWorkingSet64);
            _totalProcessorTime.SetValue(_ResourceMetrics.TotalProcessorTime);
            _userProcessorTime.SetValue(_ResourceMetrics.UserProcessorTime);
            _virtualMemorySize64.SetValue(_ResourceMetrics.VirtualMemorySize64);
            _workingSet64.SetValue(_ResourceMetrics.WorkingSet64);
            _threadsCount.SetValue(_ResourceMetrics.ThreadsCount);
            _gcCollectionCount.SetValue(_ResourceMetrics.GCCollectionCount);
            _gcTotalMemory.SetValue(_ResourceMetrics.GCTotalMemory);
            _lastGCTime.SetValue(_ResourceMetrics.LastGCTime);

            await _next(context);

            _logger.MiddlewareExecuted<ResourceMiddleware>();
        }
    }
}
