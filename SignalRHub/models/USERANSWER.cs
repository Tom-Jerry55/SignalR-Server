namespace SignalRHub.models
{
    public class USERANSWER
    {
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public string? Answer { get; set; }
        public bool IsSubmitted { get; set; }
    }

    public class PollResult
    {
        public string? Answer { get; set; }
        public int AnsweredPercent { get; set; }
        public int AnsweredCount { get; set; }
    }
    public class PolledQuestion
    {
        public int QuestionId { get; set; }
        public bool IsPollEnded { get; set; }
        public int NumberOfParticipants { get; set; }
        public int NumberOfSubmissions { get; set; }
        public int PollDuration { get; set; }
        public List<PollResult>? PollResult { get; set; }
    }

}
