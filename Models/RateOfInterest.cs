using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LMS.Models
{
    [Table(name: "Rate_Of_Interests")]
    public class RateOfInterest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        virtual public int RateOfInterestId { get; set; }

        [Required]
        [Display(Name = "Rate Of Interest % ")]
        virtual public int LoanAmount1 { get; set; }


        #region Navigation Properties to the Loan Type Model
        virtual public int LoanId { get; set; }

        [ForeignKey(nameof(RateOfInterest.LoanId))]
        public LoanType LoanType { get; set; }

        #endregion
    }
}

