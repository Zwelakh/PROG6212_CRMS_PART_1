namespace PROG6212_CRMS_PART_1.Models
{
    public class ClaimModel
    {

        public int ClaimID { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string? LecturerName { get; set; }
        public int HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        public IEnumerable<IFormFile>? SupportingDocuments { get; set; }
        public string? Status { get; set; }
    }
}
