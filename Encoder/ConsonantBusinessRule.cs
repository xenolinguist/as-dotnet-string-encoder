using System.Text;

namespace Encoder
{
    internal class ConsonantBusinessRule : IBusinessRule
    {
        public bool TryApply(IStringScanner scanner, StringBuilder output)
        {
            if (scanner.HasData && char.IsLetter(scanner.NextCharacter))
            {
                char inputLetter = char.ToLower(scanner.ReadCharacter());
                char outputLetter = (char)(inputLetter - 1);
                output.Append(outputLetter);
                return true;
            }
            return false;
        }
    }
}