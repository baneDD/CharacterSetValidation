using NUnit.Framework;

namespace CharacterSetValidation
{
    [TestFixture()]
    public class CharacterSetDetectionTests
    {
        private readonly string[] ValidStrings = { "harry potter", "s'il vous plaît", "1984", "s'well", "Sapiens: Une brève histoire de l'humanité" };
        private readonly string[] InvalidStrings = { "پاکستان", "谢谢" };
        private delegate bool ValidateStringDelegate(string str);

        [Test()]
        public void IsValidEncodingComparison_WhenGivenValidInput_ValidationShouldPass()
        {
            TestValidStrings(CharacterSetValidationMethods.IsValidEncodingComparison);
        }

		[Test()]
		public void IsValidEncodingComparison_WhenGivenInvalidInput_ValidationShouldFail()
        {
			TestInvalidStrings(CharacterSetValidationMethods.IsValidEncodingComparison);
		}

		[Test()]
		public void IsValidNumericCharByCharComparison_WhenGivenValidInput_ValidationShouldPass()
		{
			TestValidStrings(CharacterSetValidationMethods.IsValidNumericCharByCharComparison);
		}

		[Test()]
		public void IsValidNumericCharByCharComparison_WhenGivenInvalidInput_ValidationShouldFail()
		{
			TestInvalidStrings(CharacterSetValidationMethods.IsValidNumericCharByCharComparison);
		}

		[Test()]
		public void IsValidNumericCharByCharMethodGroupComparison_WhenGivenValidInput_ValidationShouldPass()
		{
			TestValidStrings(CharacterSetValidationMethods.IsValidNumericCharByCharMethodGroupComparison);
		}

		[Test()]
		public void IsValidNumericCharByCharMethodGroupComparison_WhenGivenInvalidInput_ValidationShouldFail()
		{
			TestInvalidStrings(CharacterSetValidationMethods.IsValidNumericCharByCharMethodGroupComparison);
		}

		[Test()]
		public void IsValidCharacterMethodsComparison_WhenGivenValidInput_ValidationShouldPass()
		{
			TestValidStrings(CharacterSetValidationMethods.IsValidCharacterMethodsComparison);
		}

		[Test()]
		public void IsValidCharacterMethodsComparison_WhenGivenInvalidInput_ValidationShouldFail()
		{
			TestInvalidStrings(CharacterSetValidationMethods.IsValidCharacterMethodsComparison);
		}

		[Test()]
		public void IsValidRegexComparison_WhenGivenValidInput_ValidationShouldPass()
		{
			TestValidStrings(CharacterSetValidationMethods.IsValidRegexComparison);
		}

		[Test()]
		public void IsValidRegexComparison_WhenGivenInvalidInput_ValidationShouldFail()
		{
			TestInvalidStrings(CharacterSetValidationMethods.IsValidRegexComparison);
		}

        private void TestValidStrings(ValidateStringDelegate method)
        {
            foreach (var str in ValidStrings)
            {
                Assert.IsTrue(method(str));
            }
        }

		private void TestInvalidStrings(ValidateStringDelegate method)
		{
			foreach (var str in InvalidStrings)
			{
				Assert.IsFalse(method(str));
			}
		}
    }
}
