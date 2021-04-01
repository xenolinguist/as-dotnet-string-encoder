using System;
using System.Text;

namespace Encoder
{
    public class EncoderProcessor
    {
        public string Encode(string message)
        {
            var result = new StringBuilder();
            for (int i = 0; i < message.Length; i++)
            {
                char c = Char.ToLower(message[i]);
                if (c == ' ')
                {
                    result.Append('y');
                }
                else if (Char.IsLetter(c))
                {
                    switch (c)
                    {
                        case 'a': result.Append('1'); break;
                        case 'e': result.Append('2'); break;
                        case 'i': result.Append('3'); break;
                        case 'o': result.Append('4'); break;
                        case 'u': result.Append('5'); break;
                        case 'y': result.Append(' '); break;
                        default: result.Append((char)(c - 1)); break;
                    }
                }
                else if (Char.IsDigit(c))
                {
                    int j = i + 1;
                    while (j < message.Length && Char.IsDigit(message[j]))
                    {
                        j++;
                    }
                    var number = message[i..j].ToCharArray();
                    Array.Reverse(number);
                    i=j-1;
                    result.Append(number);
                }
                else
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }
    }
}