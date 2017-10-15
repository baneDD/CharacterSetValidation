# CharacterSetValidation

This is a simple project used to determine the most performant method to allow only English and French characters trough. We loop through a set of strings a fixed number of times and measure the time it takes to process them.

There are five methods being tested here:

- Compiled RegEx comparison
- Numeric character-by-character comparison using looping through each character
- Numeric character-by-character comparison using LINQ
- Converting string to bytes using specified encoding and then converting back to string
- Using the built-in IsDigitOrLetter comparison method in .net

