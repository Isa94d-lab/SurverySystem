namespace Application.DTOs.Questions
{
    public class QuestionsDTO
    {
        public int Id { get; set; }
        public int Chapter_id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public string? Question_number { get; set; }
        public string? Response_type { get; set; }
        public string? Comment_question { get; set; }
        public string? Question_text { get; set; }
    }
}
