using System.Data;
using JenkinsDemo.Data.Models;
using Microsoft.AspNetCore.Components;

namespace JenkinsDemo.Client.Pages
{
    public partial class Calculator
    {
        [Parameter]
        public CalculatorModel Calc { get; set; } = new CalculatorModel();

        public void ProcessCalculatorFunctions(string buttonContent)
        {
            switch (buttonContent)
            {
                case "Clear":
                    Calc.ClearCalculatorContent();
                    break;
                case "DEL":
                    if (!string.IsNullOrEmpty(Calc.DisplayedCalculation))
                        Calc.DisplayedCalculation = Calc.DisplayedCalculation.Remove(Calc.DisplayedCalculation.Length - 1);
                    break;
                case " ":
                    break;
                case "=":
                    Calc.CalculateResult();
                    break;
                default:
                    Calc.DisplayedCalculation += buttonContent;
                    break;
            }
        }
    }
}