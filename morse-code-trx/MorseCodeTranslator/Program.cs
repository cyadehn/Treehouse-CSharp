using System;
using System.Text;
using System.Collections.Generic;

namespace MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write(": ");
                string input = Console.ReadLine();
                if ( string.IsNullOrWhiteSpace(input) )
                {
                    break;
                }
                string output = MorseCodeTranslator.ToMorse(input);
                Console.WriteLine(output);

                Console.Write("Provide a morse message for translation: ");
                input = Console.ReadLine();
                if ( string.IsNullOrWhiteSpace(input) )
                {
                    break;
                }
                output = MorseCodeTranslator.ToText(input);
                Console.WriteLine(output);
            }
        }
    }
    static class MorseCodeTranslator
    {
        private static Dictionary<char, string> _textToMorse = new Dictionary<char, string>
        {
            {' ', "/"},
            {'A', ".-"},
            {'B', "-..."},
            {'C', "-.-."},
            {'D', "-.."},
            {'E', "."},
            {'F', "..-."},
            {'G', "--."},
            {'H', "...."},
            {'I', ".."},
            {'J', ".---"},
            {'K', "-.-"},
            {'L', ".-.."},
            {'M', "--"},
            {'N', "-."},
            {'O', "---"},
            {'P', ".--."},
            {'Q', "--.-"},
            {'R', ".-."},
            {'S', "..."},
            {'T', "-"},
            {'U', "..-"},
            {'V', "...-"},
            {'W', ".--"},
            {'X', "-..-"},
            {'Y', "-.--"},
            {'Z', "--.."},
            {'1', ".----"},
            {'2', "..---"},
            {'3', "...--"},
            {'4', "....-"},
            {'5', "....."},
            {'6', "-...."},
            {'7', "--..."},
            {'8', "---.."},
            {'9', "----."},
            {'0', "-----"},
            {',', "--..--"},
            {'.', ".-.-.-"},
            {'?', "..--.."},
            {';', "-.-.-."},
            {':', "---..."},
            {'/', "-..-."},
            {'-', "-....-"},
            {'\\', ".----."},
            {'"', ".-..-."},
            {'(', "-.--."},
            {')', "-.--.-"},
            {'=', "-...-"},
            {'+', ".-.-."},
            {'@', ".--.-."},
            {'!', "-.-.--"},
            {'Á', ".--.-"},
            {'É', "..-.."},
            {'Ö', "---."},
            {'Ä', ".-.-"},
            {'Ñ', "--.--"},
            {'Ü', "..--"}
        };
        private static Dictionary<string, char> _morseToText = new Dictionary<string, char>();
        static MorseCodeTranslator()
        {
            foreach (KeyValuePair<char, string> code in _textToMorse)
            {
                _morseToText.Add(code.Value, code.Key);
            };
        }
        public static string ToMorse(string input)
        {
            List<string> output = new List<string>(input.Length);
            foreach ( char character in input.ToUpper() )
            {
                try 
                { 
                    string morseCode = _textToMorse[character]; 
                    output.Add(morseCode);
                }
                catch ( KeyNotFoundException ex )
                {
                    output.Add("!");
                }
            }
            return string.Join(" ", output);
        }
        public static string ToText(string input)
        {
            List<char> output = new List<char>();
            var splitInput = input.Split(" ");
            foreach ( string str in splitInput )
            {
                try 
                { 
                    char c = _morseToText[str];
                    output.Add(c);
                }
                catch ( KeyNotFoundException ex )
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return string.Join("", output);
        }
    }
}
