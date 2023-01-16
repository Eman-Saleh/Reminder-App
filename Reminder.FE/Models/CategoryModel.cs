namespace Reminder.FE.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CreatedBy { get; set; }
        public int? ParentId { get; set; }
        public string? ParentName { get; set; }
        public string? _CreatedBy { get; set; }
    }
}
