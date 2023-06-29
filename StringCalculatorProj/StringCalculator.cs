using System.Text.RegularExpressions;

namespace StringCalculatorProj;

public class StringCalculator
{
    private string _delimiter = ",|\n"; // Initial delimiters are comma and newline.
    private string _numbers; // The numbers that will be added.

    // The Add method takes a string of numbers, with optional custom delimiters, and returns their sum.
    public int Add(string input)
    {
        if (String.IsNullOrEmpty(input)) return 0; // If input is empty, return 0.

        GetDelimiterAndNumbers(input); // Extract any custom delimiters and the numbers from the input.

        return SumUpNumbers(); // Calculate and return the sum of the numbers.
    }

    // If the input starts with "//", it contains a custom delimiter. This method extracts it and the numbers.
    private void GetDelimiterAndNumbers(string input)
    {
        if (input.StartsWith("//"))
        {
            var match = Regex.Match(input, "//(.*)\n(.*)"); // Regex pattern to extract delimiter and numbers.
            _delimiter = match.Groups[1].Value; // Custom delimiter(s) extracted from the input.
            _numbers = match.Groups[2].Value; // The numbers to be added.
        }
        else
        {
            _numbers = input; // If no custom delimiter, the input is just the numbers.
        }

        _delimiter = BuildDelimiterPattern(); // Converts the delimiter string into a regex pattern.
    }
    
    private string BuildDelimiterPattern()
    {
        if (_delimiter.Contains('['))
        {
            // Split the delimiter string into individual delimiters, escape any regex special characters.
            var delimiters = _delimiter.Split(new[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
            return string.Join("|", delimiters.Select(Regex.Escape)); // Join the delimiters with "|", for use in regex.
        }
        else
        {
            // In this case, we just return the delimiter as is.
            return _delimiter;
        }
    }
    private int SumUpNumbers()
    {
        // Split the numbers string into individual numbers, convert to integers, and filter out any greater than 1000.
        var nums = Regex.Split(_numbers, _delimiter)
            .Select(int.Parse)
            .Where(n => n <= 1000)
            .ToList();

        // Check for any negative numbers. If found, throw an exception.
        var negativeNumbers = nums.Where(n => n < 0).ToList();
        if (negativeNumbers.Any())
        {
            throw new ApplicationException("Negatives not allowed: " + string.Join(",", negativeNumbers));
        }

        return nums.Sum(); // Return the sum of the numbers.
    }
}