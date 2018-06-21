namespace Calc.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Calculation object
    /// </summary>
    public class CalculatorModel
    {
        /// <summary>
        /// Gets or Sets value of fist number 
        /// </summary>
        [Required]
        public int X { get; set; }

        /// <summary>
        /// Gets or sets value of first number
        /// </summary>
        [Required]
        public int Y { get; set; }

        /// <summary>
        /// Name of the selected method
        /// </summary>
        public string SelectedMethod { get; set; }
    }
}