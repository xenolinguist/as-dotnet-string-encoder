using System.Text;

namespace Encoder
{
    internal class DefaultBusinessRule : IBusinessRule
    {
        public bool TryApply(IStringScanner scanner, StringBuilder output)
        {
            output.Append(scanner.ReadCharacter());
            return true;
        }
    }
}