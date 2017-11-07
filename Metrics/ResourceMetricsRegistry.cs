using App.Metrics;
using App.Metrics.Gauge;

namespace App.Metrics.AspNetCore.Resource.Metrics
{
    public static class ResourceMetricsRegistry
    {
        public static GaugeOptions MaxWorkingSetGauge => new GaugeOptions
        {
            Name = "Process maximum physical memory set",
            MeasurementUnit = Unit.Bytes
        };

        public static GaugeOptions NonpagedSystemMemorySize64Gauge => new GaugeOptions
        {
            Name = "Process nonpaged system memory size",
            MeasurementUnit = Unit.Bytes
        };

        public static GaugeOptions PagedMemorySize64Gauge => new GaugeOptions
        {
            Name = "Process paged memory size",
            MeasurementUnit = Unit.Bytes
        };

        public static GaugeOptions PeakPagedMemorySize64Gauge => new GaugeOptions
        {
            Name = "Process peak paged memory size",
            MeasurementUnit = Unit.Bytes
        };

        public static GaugeOptions PeakWorkingSet64Gauge => new GaugeOptions
        {
            Name = "Process peak working set",
            MeasurementUnit = Unit.Bytes
        };

        public static GaugeOptions TotalProcessorTimeGauge => new GaugeOptions
        {
            Name = "Process total processor time",
            MeasurementUnit = Unit.Custom("ms")
        };

        public static GaugeOptions UserProcessorTimeGauge => new GaugeOptions
        {
            Name = "Process user processor time",
            MeasurementUnit = Unit.Custom("ms")
        };

        public static GaugeOptions VirtualMemorySize64Gauge => new GaugeOptions
        {
            Name = "Process virtual memory size",
            MeasurementUnit = Unit.Bytes
        };

        public static GaugeOptions WorkingSet64Gauge => new GaugeOptions
        {
            Name = "Process working set",
            MeasurementUnit = Unit.Bytes
        };

        public static GaugeOptions ThreadsCountGauge => new GaugeOptions
        {
            Name = "Process threads count",
            MeasurementUnit = Unit.Threads
        };

        public static GaugeOptions GCCollectionCountGauge => new GaugeOptions
        {
            Name = "GC total collection count",
            MeasurementUnit = Unit.Custom("#")
        };

        public static GaugeOptions GCTotalMemoryGauge => new GaugeOptions
        {
            Name = "GC total memory",
            MeasurementUnit = Unit.Bytes
        };

        public static GaugeOptions LastGCTimeGauge => new GaugeOptions
        {
            Name = "GC last GC time",
            MeasurementUnit = Unit.Custom("ms")
        };
    }
}
