using System;
using System.Text;

namespace Encoder
{
    internal class NumberBusinessRule : IBusinessRule
    {
        public bool TryApply(IStringScanner scanner, StringBuilder output)
        {
            if (scanner.HasData && Char.IsDigit(scanner.NextCharacter) )
            {
                var number = scanner.ReadNumber();
                Array.Reverse(number);
                output.Append(number);
                return true;
            }
            return false;
        }
    }
}