using Microsoft.AspNetCore.Components;

namespace JenkinsDemo.Client.Shared.Components
{
    public partial class CalculatorButton
    {
        [Parameter]
        public string ButtonContent { get; set; }
    }
}
