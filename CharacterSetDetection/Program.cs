using System;
using System.Diagnostics;

namespace CharacterSetValidation
{
    class Program
    {
        private static int numIterations = 1000000;
        private delegate bool IsAsciiDelegate(string str);

        public static void Main(string[] args)
        {
            var characterTestSet = new string[] { "harry potter", "s'il vous plaît", "1984", "پاکستان", "s'well", "谢谢" , "Sapiens: Une brève histoire de l'humanité"};


            ProcessTestStringsAndOuputSummary(numIterations, characterTestSet, CharacterSetValidationMethods.IsValidEncodingComparison);

            ProcessTestStringsAndOuputSummary(numIterations, characterTestSet, CharacterSetValidationMethods.IsValidNumericCharByCharComparison);

            ProcessTestStringsAndOuputSummary(numIterations, characterTestSet, CharacterSetValidationMethods.IsValidNumericCharByCharMethodGroupComparison);

            ProcessTestStringsAndOuputSummary(numIterations, characterTestSet, CharacterSetValidationMethods.IsValidCharacterMethodsComparison);

            ProcessTestStringsAndOuputSummary(numIterations, characterTestSet, CharacterSetValidationMethods.IsValidRegexComparison);
        }

        private static void ProcessTestStringsAndOuputSummary(int numIterations, string[] testStrings, IsAsciiDelegate methodToUse)
        {

            ValidateStringsInArrayAndOutputToConsole(testStrings, methodToUse);
            CalculateTimingsOverIterations(numIterations, testStrings, methodToUse);
        }

        private static void ValidateStringsInArrayAndOutputToConsole(string[] testStrings, IsAsciiDelegate methodToUse)
        {
            Console.WriteLine($"Processed using {methodToUse.Method.Name}:");

            foreach (var str in testStrings)
			{
                ValidateTestStringAndOutputToConsole(str, methodToUse);
			}

            Console.WriteLine("\n");
        }

        private static void ValidateTestStringAndOutputToConsole(string str, IsAsciiDelegate method)
        {
            var qualifier = method(str) ? string.Empty : " NOT";
			Console.WriteLine($"\"{str}\" is{qualifier} a valid string");
        }

        private static void CalculateTimingsOverIterations(int numIterations, string[] testStrings, IsAsciiDelegate methodToUse)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < numIterations; i++)
            {
                foreach (var str in testStrings)
                    methodToUse(str);
            }

            stopwatch.Stop();

            Console.WriteLine($"For {numIterations} {methodToUse.Method.Name} took {stopwatch.ElapsedMilliseconds} milliseconds!\n");
        }
    }
}
