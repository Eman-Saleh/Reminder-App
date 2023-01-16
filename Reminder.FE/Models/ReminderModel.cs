namespace Reminder.FE.Models
{
    public class ReminderModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? CategoryId { get; set; }
        public int? CreatedBy { get; set; }
        public string?  _Category { get; set; }
        public string?  _CreatedBy { get; set; }
        public DateTime? ReminderDate { get; set; }
    }
}
