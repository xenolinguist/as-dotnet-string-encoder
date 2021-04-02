using System.Text;

namespace Encoder
{
    internal class YBusinessRule : IBusinessRule
    {
        public bool TryApply(IStringScanner scanner, StringBuilder output)
        {
            if (scanner.HasData && char.ToLower(scanner.NextCharacter) == 'y')
            {
                output.Append(' ');
                scanner.ReadCharacter();
                return true;
            }
            return false;
        }
    }
}