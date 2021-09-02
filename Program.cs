/* 
Kalin Nebeker and Franco Cespi
CS-1415 Lab 1: Vigenere Cypher
Started: 8/31/2021
This program encode the characters of a message using a Vigenere key
*/

using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

    class VigenereCypher
    {
        static void Main(string[] args)
        {
            Tests();
            Run();
        }

        static void Tests()
        {
            Debug.Assert(Cypher("h", "a") == "h");
            Debug.Assert(Cypher("h", "b") == "i");
            Debug.Assert(Cypher("a*", "b") == "b*");
            Debug.Assert(Cypher("hello", "b") == "ifmmp");
            Debug.Assert(Cypher("hello", "ba") == "iemlp");
            Debug.Assert(ShiftOne('t', 'a') == 't');
            Debug.Assert(ShiftOne('t', 'b') == 'u');
        }

        // It will run the program prompting the user to provide a message and a key to encrypt it, showing the resulting string
        static void Run()
        {
            string input, key;
            Console.WriteLine("\nWelcome to the Vigenere cypher encrypter!!!\n");
            Console.WriteLine("Please input the message you want to encrypt");
            input = Console.ReadLine();
            Console.WriteLine("Please input a secret key");
            key = Console.ReadLine();

            Console.WriteLine("Your encrypted message is: " + Cypher(input, key));
        }

        // takes a 'inputChar' and salts it with 'keyChar' 
        static char ShiftOne(char inputChar, char keyChar)
        {
            int inputCharOffset = inputChar - 'a';
            int keyCharOffset = keyChar - 'a';
            int answercharOffset =  ((inputCharOffset + keyCharOffset) % 26);

            return (char) ('a' + answercharOffset);
        }

        /*
            takes two strings and returns and encripted version of the first
        */
        static string Cypher(string input, string key)
        {
            char[] output = CopyChars(input);
            int index = 0;

            for (int i = 0; i < input.Length; i++) {
                if (!Regex.IsMatch(input[index].ToString(), "^[a-zA-Z0-9]*$")) {
                    continue;
                }
                int keyIndex = index % key.Length;
                output[index] = ShiftOne(input[index], key[keyIndex]);
                index++;
            }
            
            string outputString = new string(output);
            return outputString;
        }

        // takes an string and return a copy of it as a char array 
        static char[] CopyChars(string input)
        {
            return input.ToCharArray();
        }
    }
