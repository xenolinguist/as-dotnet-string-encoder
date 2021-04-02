using System.Text;

namespace Encoder
{

    internal interface IBusinessRule
    {
        bool TryApply(IStringScanner scanner, StringBuilder output);
    }
}