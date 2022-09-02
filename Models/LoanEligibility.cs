using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models
{
    [Table(name: "Loan_Eligibility_Criteria")]
    public class LoanEligibility
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoanEligibilityId { get; set; }

        [Required]
        [Display(Name = "Age Limit (above)")]
        public int AgeLimit { get; set; }

        [Required]
        [Display(Name = "Nationality")]
        public string Nationality { get; set; }

        [Required]
        [Display(Name = "Type of employment")]
        public string TypeOfEmployment { get; set; }

        [Required]
        [Display(Name = "Monthly income (Rupees)")]
        public int MonthlyIncome { get; set; }

        #region Navigation Properties to the Loan Type Model
        virtual public int LoanId { get; set; }

        [ForeignKey(nameof(LoanEligibility.LoanId))]
        public LoanType LoanType { get; set; }

        #endregion
    }
}
