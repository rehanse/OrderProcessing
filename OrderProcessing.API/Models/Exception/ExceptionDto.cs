namespace OrderProcessing.API.Models.Exception
{
    public class ExceptionDto
    {
        public string? Api_id { get; set; }
        public int? Response_code { get; set; }
        public string? Response_message { get; set; }
        public string? Severity { get; set; }
        public string? Unique_logid { get; set; }
        public DateTime Created_datetime { get; set; } = DateTime.UtcNow;
    }
}
