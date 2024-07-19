using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JenkinsDemo.Data.Models
{
    public class EchoModel
    {
        public string? StatementContent { get; set; }
        public string EchoedStatement { get; set; } = "";

        public void EchoUppercase()
        {
            if (!string.IsNullOrEmpty(StatementContent))
                EchoedStatement = StatementContent.ToUpper();
        }
        public void EchoLowercase()
        {
            if (!string.IsNullOrEmpty(StatementContent))
                EchoedStatement = StatementContent.ToLower();
        }
        public void EchoNoSpaces()
        {
            if (!string.IsNullOrEmpty(StatementContent))
                EchoedStatement = StatementContent.Replace(" ", string.Empty);
        }
        public void EchoSplitCharacters()
        {
            if (!string.IsNullOrEmpty(StatementContent))
                EchoedStatement = string.Join(" ", StatementContent.ToCharArray());
        }
        public void EchoReverse()
        {
            if (!string.IsNullOrEmpty(StatementContent))
            {
                char[] stringToReverse = StatementContent.ToCharArray();
                Array.Reverse(stringToReverse);
                EchoedStatement = new string(stringToReverse);
            }
        }
    }
}

