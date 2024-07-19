using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JenkinsDemo.Data.Models
{
    public class CalculatorModel
    {
        public string DisplayedCalculation { get; set; }
        public string CalculationResult { get; set; }
        public List<string> CalcButtons { get; set; } = new List<string> { "DEL", "Clear", " ", "/", "7", "8", "9", "*", "4", "5", "6", "-", "1", "2", "3", "+", "0", ".", "=" };

        public void ClearCalculatorContent()
        {
            DisplayedCalculation = "";
            CalculationResult = "";
        }

        public void CalculateResult()
        {
            try
            {
                DataTable table = new DataTable();
                double result = Convert.ToDouble(table.Compute(DisplayedCalculation, string.Empty));
                CalculationResult = Math.Round(result, 2).ToString();
                DisplayedCalculation = CalculationResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
        }
    }
}
