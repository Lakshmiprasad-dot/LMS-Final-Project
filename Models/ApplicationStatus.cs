using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models
{
    [Table(name: "Loan_Applications_Status")]
    public class ApplicationStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int AplicationStatusId { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Display(Name = "Loan Application Id")]
        public int ApplicationID { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Display(Name = "Loan Application Approval Status")]
        public string Status { get; set; }


        #region Navigation Properties to the Loan Application Model
        virtual public int LoanApplicationId { get; set; }

        [ForeignKey(nameof(ApplicationStatus.LoanApplicationId))]
        public LoanApplication LoanApplication { get; set; }

        #endregion
    }
}
