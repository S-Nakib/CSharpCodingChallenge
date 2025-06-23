using System.Runtime.CompilerServices;
using System.Text;

namespace CSharpCodingChallenge;


/// <summary>
/// Class <c>OldPhoneKeyPad</c> models an Old Phone Keypad that contains Digits from 0-9 and a * and # button.
/// </summary>
/// <remarks>
/// Each button has a number to identify it
/// and pressing a button multiple times will cycle through the letters on it allowing each button to represent
/// more than one letter.
/// For example,
/// Pressing 2 once will return ‘A’ but pressing twice in succession will return ‘B’.
/// You must pause for a second in order to type two characters from the same button after each other: “222 2 22” -> “CAB”.
/// </remarks>
public class OldPhoneKeyPad
{

    /// <value>
    /// Field <c>DigitToCharsMapping</c> represents the Phone Pad's Digit's to Character's mapping.
    /// The nth digit maps to the nth index in the array and each character is represented by a char array.
    /// </value>
    private static readonly char[][] DigitToCharsMapping =
    [
        [' '],
        ['&', '\'', '('],
        ['A', 'B', 'C'],
        ['D', 'E', 'F'],
        ['G', 'H', 'I'],
        ['J', 'K', 'L'],
        ['M', 'N', 'O'],
        ['P', 'Q', 'R', 'S'],
        ['T', 'U', 'V'],
        ['W', 'X', 'Y', 'Z']
    ];


    /// <summary>
    /// Method <c>OldPhonePad</c> converts a sequence of button presses on an old phone keypad into an alphabetic string.
    /// </summary>
    /// <param name="input">
    /// The sequence of button press
    /// </param>
    /// <returns>
    /// The Alphabetic string that button press represents
    /// </returns>
    /// <example>Examples:
    /// <code>OldPhonePad(“33#”)</code> => output: E
    /// <code>OldPhonePad(“227*#”)</code> => output: B
    /// <code>OldPhonePad(“4433555 555666#”)</code> => output: HELLO
    /// <code>OldPhonePad(“8 88777444666*664#”)</code> => output: TURING
    /// </example>

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static string OldPhonePad(string input)
    {
        var stringBuilder = new StringBuilder();

        // Counter for consecutive identical characters
        var repetition = 0;

        /*
         * Every time we encounter a '*', instead of deleting the last character instantly from the StringBuilder,
           we keep track of the number of deleted characters.
         * Later when we encounter a digit(0-9), we will replace the appropriate alphabetic character to the
           last deleted index pointed by the stringBuilderDeletedIndexPointer and update the pointer.
         * The idea is to decrease deletions and addition from the StringBuilder because they are costly operations.
         */
        var stringBuilderDeletedIndexPointer = 0;


        /*
         * We are iterating the input and whenever the current character doesn't match the next character,
           we will append the character to the StringBuilder.
         * The last char is always a '#', so loop until Length - 1
         */
        for (var index = 0; index < input.Length - 1; index++)
        {
            var currentChar = input[index];
            var nextChar = input[index + 1];


            // If the current character is not a digit or '*', skip it

            if (char.IsNumber(currentChar))
            {
                repetition++;

                if (currentChar == nextChar) continue;

                /* If we have deleted character in the StringBuilder, replace from the end instead of appending */
                if (stringBuilderDeletedIndexPointer > 0)
                {
                    stringBuilder[^stringBuilderDeletedIndexPointer] = GetMapping(currentChar - '0', repetition);
                    stringBuilderDeletedIndexPointer--;
                }
                else
                {
                    // No pending deletions, append new character
                    stringBuilder.Append(GetMapping(currentChar - '0', repetition));
                }

                repetition = 0;
            }

            if (currentChar == '*')
            {
                // Marking the deleted character, by ensuring we don't try to delete more characters than exist
                stringBuilderDeletedIndexPointer = int.Min(stringBuilder.Length, stringBuilderDeletedIndexPointer + 1);
            }
        }

        // Remove any remaining characters marked for deletion from the end
        stringBuilder.Remove(stringBuilder.Length - stringBuilderDeletedIndexPointer, stringBuilderDeletedIndexPointer);

        return stringBuilder.ToString();
    }


    /// <summary>
    /// Provides the mapping of a digit to its corresponding character based on the number of repetitions.
    /// </summary>
    /// <param name="digit">The digit(0-9) that is pressed</param>
    /// <param name="repetition">The number of times the digit is pressed.</param>
    /// <returns>The Mapped Alphabetic Character</returns>
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static char GetMapping(int digit, int repetition)
    {
        return DigitToCharsMapping[digit][(repetition - 1) % DigitToCharsMapping[digit].Length];
    }
}