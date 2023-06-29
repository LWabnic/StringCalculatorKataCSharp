using StringCalculatorProj;

namespace StringCalculatorTestProj;

public class Tests
{
    private StringCalculator calculator;
    
    [SetUp]
    public void Initialize()
    {
        calculator = new StringCalculator();
    }

    // Test Add method with an empty string
    [Test]
    public void Add_EmptyString_ReturnsZero()
    {
        var sum = calculator.Add("");
        Assert.AreEqual(0, sum);
    }

    // Test Add method with one number
    [Test]
    public void Add_OneNumber_ReturnsTheNumber()
    {
        var sum = calculator.Add("5");
        Assert.AreEqual(5, sum);
    }

    // Test Add method with two numbers
    [Test]
    public void Add_TwoNumbers_ReturnsTheirSum()
    {
        var sum = calculator.Add("5,7");
        Assert.AreEqual(12, sum);
    }

    // Test Add method with multiple numbers
    [Test]
    public void Add_MultipleNumbers_ReturnsTheirSum()
    {
        var sum = calculator.Add("1,2,3,4,5");
        Assert.AreEqual(15, sum);
    }

    // Test Add method with new line as a delimiter
    [Test]
    public void Add_NewLineDelimiter_ReturnsSum()
    {
        var sum = calculator.Add("1\n2,3");
        Assert.AreEqual(6, sum);
    }

    // Test Add method with a custom delimiter
    [Test]
    public void Add_CustomDelimiter_ReturnsSum()
    {
        var sum = calculator.Add("//;\n1;2");
        Assert.AreEqual(3, sum);
    }

    // Test Add method with a negative number
    [Test]
    public void Add_NegativeNumber_ThrowsException()
    {
        var ex = Assert.Throws<ApplicationException>(() => calculator.Add("2,-4,3,-5"));
        Assert.That(ex.Message, Is.EqualTo("Negatives not allowed: -4,-5"));
    }

    // Test Add method with a number greater than 1000
    [Test]
    public void Add_NumberGreaterThan1000_IgnoresNumber()
    {
        var sum = calculator.Add("1001,2");
        Assert.AreEqual(2, sum);
    }

    // Test Add method with delimiters of any length
    [Test]
    public void Add_DelimitersOfAnyLength_ReturnsSum()
    {
        var sum = calculator.Add("//[|||]\n1|||2|||3");
        Assert.AreEqual(6, sum);
    }

    [Test]
    public void Add_DelimitersOfVariousSpecialCharacters_ReturnsSum()
    {
        // Using "##" and "@@" as delimiters
        var sum = calculator.Add("//[##][@@]\n1##2@@3");
        Assert.AreEqual(6, sum);
    }

    [Test]
    public void Add_MultipleDelimitersOfDifferentLengths_ReturnsSum()
    {
        // Using "***" and "@@" as delimiters
        var sum = calculator.Add("//[***][@@]\n1***2@@3");
        Assert.AreEqual(6, sum);
    }

    [Test]
    public void Add_MultipleDelimitersWithMoreComplexPattern_ReturnsSum()
    {
        // Using "**#*" and "@@@" as delimiters
        var sum = calculator.Add("//[**#*][@@@]\n1**#*2@@@3");
        Assert.AreEqual(6, sum);
    }


}
