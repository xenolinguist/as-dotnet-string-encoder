using System;

namespace Encoder
{
    internal class StringScanner : IStringScanner
    {
        private readonly char[] _buffer;
        private readonly int _length;
        private int _index;

        public StringScanner(string input)
        {
            _buffer = input.ToCharArray();
            _length = _buffer.Length;
            _index = 0;
        }

        public bool HasData => _index < _length;
        public char NextCharacter => _buffer[_index];
        public char ReadCharacter() => _buffer[_index++];

        public char[] ReadNumber()
        {
            int startIndex = _index;
            while (HasData && Char.IsDigit(NextCharacter))
            {
                _index++;
            }
            return _buffer[startIndex.._index];
        }
    }
}