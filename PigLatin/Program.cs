using System;
using System.Linq;

namespace PigLatinTest
{
    class PigLatin
    {//Commented out the main method to avoid the "More than one entry point" error
        //Changed this to an object class, removed static from the methods below to be able to test
        //static void Main(string[] args)
        //{
        //    string userInput = GetInput("Please input a word or sentence to translate to pig Latin");
        //    *Need a method to substring anything with spaces (last unit test)
        //           - Substring separated by ' ' char, and foreach substring, run through the ToPigLatin() method
        //           - Then combine separate 'words' into a string and return that string.

        //    string translation = ToPigLatin(userInput);
        //    Console.WriteLine(translation);
        //}

        public string GetInput(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine().ToLower().Trim();
            return input;
        }

        public bool IsVowel(char c)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            
            return c.ToString() == vowels.ToString();
            //This method always returns false, since we are comparing a character to an array.
            //A foreach loop with a break would work, to make sure we return a bool of True as soon as we find the first vowel.
            //Like this:
            //foreach (var v in vowels)
            //{
            //    if (c.ToString() == v.ToString())
            //    {
            //        isVowel = true;
            //        break;
            //    }
            //    else
            //    {
            //        isVowel = false;
            //    }
            //}
            //return isVowel;
        }

        public string ToPigLatin(string word)
        {
            char[] specialChars = { '@', '.', '-', '$', '^', '&' };
            word = word.ToLower();
            foreach(char c in specialChars)
            {
                foreach(char w in word)
                {
                    if (w == c)
                    {
                        Console.WriteLine("That word has special characters, we will return it as is"); 
                        //this is working as expected, based on email format ('@' and '.')
                        return word;
                    }
                }
                
            }

            bool noVowels = true;
            foreach(char letter in word)
            {
                if (IsVowel(letter))
                {
                    noVowels = false; 
                    //break; keyword needed here, since we are just lookingi for the first instance of this being false.
                }
            }

            if (noVowels)  
            {
                return word; 
            }

            char firstLetter = word[0];
            string output = "placeholder";
            if (IsVowel(firstLetter) == true)
            {
                output = word + "ay"; //based on spec, this should be "way", not "ay".  
                //That change will only impact words that start with a vowel.
            }
            else
            {
                int vowelIndex = -1;
                //Handle going through all the consonants
                for (int i = 0; i <= word.Length; i++)
                {
                    if (IsVowel(word[i]) == true)
                    {
                        vowelIndex = i;
                        break;
                    }
                }

                string sub = word.Substring(vowelIndex + 1);
                //wrong index being used above.  Should be Substring(vowelIndex); to include the first vowel.
                string postFix = word.Substring(0, vowelIndex -1);
                //wrong index being used above.  Should be Substring(0, vowelIndex); to exclude the first vowel.

                output = sub + postFix + "ay";
            }

            return output;
        }
    }
}
