namespace Encoder
{
    internal interface IStringScanner
    {
        bool HasData { get; }
        char NextCharacter { get; }
        char ReadCharacter();
        char[] ReadNumber();
    }
}