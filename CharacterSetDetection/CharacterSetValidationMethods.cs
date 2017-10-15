using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CharacterSetValidation
{
    /// <summary>
    /// This class implements the methods that validate the character set so that only English and French characters are valid
    /// </summary>
    public class CharacterSetValidationMethods
    {
        private static Regex CharacterSetValidationRegex = new Regex(@"[\x20-\xFF]", RegexOptions.Compiled);

        /// <summary>
        /// We are using conversion from encoding to bytes and back here to validate our character set.
        /// In order for this to work for both English and French characters, we are using Code Page 437.
        /// More information here: https://en.wikipedia.org/wiki/Code_page_437
        /// </summary>
        /// <returns><c>true</c>, if characters used are valid, <c>false</c> otherwise.</returns>
        /// <param name="inputStr">Input string.</param>
		public static bool IsValidEncodingComparison(string inputStr)
		{
			byte[] asciiBytes = Encoding.GetEncoding(437).GetBytes(inputStr);
			string inputStrAscii = Encoding.GetEncoding(437).GetString(asciiBytes);
			return inputStr.Equals(inputStrAscii);
		}

        /// <summary>
        /// We are inspecting the string character-by-character and return as soon as an invalid character is found
        /// </summary>
        /// <returns><c>true</c>, if characters used are valid, <c>false</c> otherwise.</returns>
        /// <param name="inputStr">Input string.</param>
		public static bool IsValidNumericCharByCharComparison(string inputStr)
		{
			foreach (char c in inputStr)
			{
				if (c < 32 || c > 255) return false;
			}

			return true;
		}

        /// <summary>
        /// Inspects the string character by character but uses Linq as opposed to a standard loop
        /// </summary>
        /// <returns><c>true</c>, if characters used are valid, <c>false</c> otherwise.</returns>
        /// <param name="inputStr">Input string.</param>
		public static bool IsValidNumericCharByCharMethodGroupComparison(string inputStr)
		{
			return inputStr.All(c => c > 31 && c < 256);
		}

        /// <summary>
        /// We are using IsLetterOrDigit method here but this does not actually work correctly for French characters
        /// </summary>
        /// <returns><c>true</c>, if valid character methods comparison was ised, <c>false</c> otherwise.</returns>
        /// <param name="inputStr">Input string.</param>
		public static bool IsValidCharacterMethodsComparison(string inputStr)
		{
			return inputStr.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || char.IsPunctuation(c));
		}

		public static bool IsValidRegexComparison(string inputStr)
		{
			return CharacterSetValidationRegex.IsMatch(inputStr);
		}
    }
}
