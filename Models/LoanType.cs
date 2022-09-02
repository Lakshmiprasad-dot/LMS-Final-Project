using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LMS.Models
{
    [Table(name: "Loan_Types")]
    public class LoanType
    {

        [Key]                                                       // Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]       // Identity Column
        [Display(Name = "Loan ID")]
        public int LoanId { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Loan Type")]
        public string LoanName { get; set; }

        [Required]
        [Column(TypeName = "varchar(500)")]
        [Display(Name = "Loan Details")]
        public string Details { get; set; }

        [Required]
        [Display(Name = "Minimum Loan Amount ")]
        public int MinimumAmount { get; set; }

        [Required]
        [Display(Name = "Maximum Loan Amount ")]
        public int MaximumAmount { get; set; }

        [Required]
        [Display(Name = "Loan Given to")]
        public string LoanGivenTo { get; set; }

        [Required]
        [DefaultValue(1)]
        [Display(Name = "Guaranters Required")]
        public int NumberOfGuaranters { get; set; }


        #region Navigation Properties to the rate of interest Model

        public ICollection<RateOfInterest> RateOfInterests{ get; set; }

        #endregion

        #region Navigation Properties to the Loan Application Model

        public ICollection<LoanApplication> LoanApplications { get; set; }

        #endregion

        #region Navigation Properties to the Loan Eligibility Model

        public ICollection<LoanEligibility> LoanEligibilities { get; set; }

        #endregion
    }
}




