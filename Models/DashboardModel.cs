namespace trabajo_de_SF2.Models
{
    public class DashboardModel
    {
        public string? Status { get; set; }
        public string? LastValidation { get; set; }
        public List<CriticalService>? CriticalServices { get; set; }
        public List<ApiSync>? ApiSyncs { get; set; }
        public string? LastSyncTime { get; set; }
        public int LatencyMs { get; set; }
        public int UptimePercent { get; set; }
    }

    public class CriticalService
    {
        public string? Provider { get; set; }
        public string? ServiceName { get; set; }
        public string? Status { get; set; }
        public string? StatusColor { get; set; }
        public string? Icon { get; set; }
    }

    public class ApiSync
    {
        public string? Name { get; set; }
        public string? Status { get; set; }
        public string? StatusColor { get; set; }
        public string? LastSync { get; set; }
        public string? SyncType { get; set; }
    }
}
