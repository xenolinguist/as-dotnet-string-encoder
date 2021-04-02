using System.Text;

namespace Encoder
{
    internal class SpaceBusinessRule : IBusinessRule
    {
        public bool TryApply(IStringScanner scanner, StringBuilder output)
        {
            if (scanner.HasData && scanner.NextCharacter == ' ' )
            {
                output.Append('y');
                scanner.ReadCharacter();
                return true;
            }
            return false;
        }
    }
}