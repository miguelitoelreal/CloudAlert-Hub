namespace trabajo_de_SF2.Models
{
    public class IncidentModel
    {
        public int Id { get; set; }
        public string? Provider { get; set; }
        public string? ProviderIcon { get; set; }
        public string? Title { get; set; }
        public string? Severity { get; set; }
        public string? SeverityColor { get; set; }
        public string? Duration { get; set; }
        public string? Location { get; set; }
        public string? RootCauseAnalysis { get; set; }
        public List<TimelineEvent>? Timeline { get; set; }
        public List<ServiceImpact>? ImpactedServices { get; set; }
        public List<string>? OfficialLinks { get; set; }
        public List<Responder>? Responders { get; set; }
        public string? TechnicalDetails { get; set; }
    }

    public class TimelineEvent
    {
        public string? Time { get; set; }
        public string? Description { get; set; }
    }

    public class ServiceImpact
    {
        public string? Severity { get; set; }
        public string? ServiceName { get; set; }
        public string? SeverityColor { get; set; }
    }

    public class Responder
    {
        public string? Role { get; set; }
        public string? Name { get; set; }
        public bool Status { get; set; }
    }
}
