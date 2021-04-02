using System.Collections.Generic;
using System.Text;

namespace Encoder
{
    public class EncoderProcessor
    {
        private readonly IEnumerable<IBusinessRule> _rules;
        private readonly IStringScannerFactory _scannerFactory;

        public EncoderProcessor() : this(
            new StringScannerFactory(),
            new SpaceBusinessRule(),
            new DefaultBusinessRule()) { }

        internal EncoderProcessor(IStringScannerFactory scannerFactory, params IBusinessRule[] rules)
        {
            _scannerFactory = scannerFactory;
            _rules = rules;
        }

        public string Encode(string message)
        {
            var scanner = _scannerFactory.Create(message);
            var output = new StringBuilder();

            while (scanner.HasData)
            {
                foreach (var rule in _rules)
                {
                    if (rule.TryApply(scanner, output)) break;
                }
            }

            return output.ToString();
        }
    }
}