using System.Collections.Generic;
using System.Text;

namespace Encoder
{
    internal class VowelBusinessRule : IBusinessRule
    {
        private static readonly IDictionary<char, char> VowelMap = new Dictionary<char, char>{
            {'a', '1'}, {'e', '2'}, {'i', '3'}, {'o', '4'}, {'u', '5'}
        };

        public bool TryApply(IStringScanner scanner, StringBuilder output)
        {
            if (scanner.HasData && VowelMap.ContainsKey(char.ToLower(scanner.NextCharacter)))
            {
                output.Append(VowelMap[char.ToLower(scanner.ReadCharacter())]);
                return true;
            }
            return false;
        }
    }
}