using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LMS.Models
{
    [Table(name: "Loan_Applications")]
    public class LoanApplication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Loan Application Id")]
        public int LoanApplicationId { get; set; }


        [Required]
        [StringLength(50)]
        [Display(Name = "Application Holder Name ")]
        public string ApplicationHolderName { get; set; }

        [Required]
        [Display(Name = "Account Number ")]
        public int AccountNumber { get; set; }

        [Required]
        
        [Display(Name = "Account Holder Email ")]
        public string ApplicationHolderEmail { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [StringLength(20)]
        [Display(Name = "Account IFSC Code ")]
        public string IfscCode { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Display(Name = "Required Loan Amount ($)")]
        public int LoanAmount { get; set; }

        #region Navigation Properties to the Application Status Model

        public ICollection<ApplicationStatus> ApplicationStatuses { get; set; }

        #endregion

        #region Navigation Properties to the Loan Type Model
        virtual public int LoanId { get; set; }

        [ForeignKey(nameof(LoanApplication.LoanId))]
        public LoanType LoanType { get; set; }

        #endregion



    }
}
