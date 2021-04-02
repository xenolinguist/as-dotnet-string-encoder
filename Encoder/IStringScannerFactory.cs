namespace Encoder
{
    internal interface IStringScannerFactory
    {
        IStringScanner Create(string input);
    }
}