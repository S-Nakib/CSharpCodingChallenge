using CSharpCodingChallenge;

while (true)
{
    Console.WriteLine("\n\nPlease provide an input");

    var input = Console.ReadLine();

    if (input.EndsWith('#') is false)
    {
        Console.WriteLine("Adding # at the and");
        input += "#";
    }

    var output = OldPhoneKeyPad.OldPhonePad(input);

    Console.WriteLine($"The output string is:\"{output}\"");

}