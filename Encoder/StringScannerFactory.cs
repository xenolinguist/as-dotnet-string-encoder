namespace Encoder
{
    internal class StringScannerFactory : IStringScannerFactory
    {
        public IStringScanner Create(string input) => new StringScanner(input);
    }
}