using StringCalculatorProj;

StringCalculator calculator = new StringCalculator();

Console.Write("Please enter a string of numbers (for example, '1,2,3'): ");
string numbers = Console.ReadLine();

try
{
    int sum = calculator.Add(numbers);
    Console.WriteLine("The sum of the numbers is: " + sum); // Prints the sum of the numbers in the string.
}
catch (Exception ex)
{
    // This will catch any exceptions (like negative numbers) and print the error message.
    Console.WriteLine(ex.Message); 
}