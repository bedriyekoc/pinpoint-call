namespace PinPointCallerVersionOne
{
    public class EventData
    {
        public string Id { get; set; }
        public string IssueUrl { get; set; }
        public string Title { get; set; }
        public string Priority { get; set; }
        public List<string> ImpactedEntities { get; set; }
        public int TotalIncidents { get; set; }
        public string State { get; set; }
        public string Trigger { get; set; }
        public string IsCorrelated { get; set; }
        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }
        public List<string> Sources { get; set; }
        public List<string> AlertPolicyNames { get; set; }
        public List<string> AlertConditionNames { get; set; }
        public string WorkflowName { get; set; }



    }
}
