namespace CSharpCodingChallenge.Tests
{
    public class OldPhonePadTests
    {

        [Theory]
        [InlineData("1#", "&")]
        [InlineData("2#", "A")]
        [InlineData("3#", "D")]
        [InlineData("4#", "G")]
        [InlineData("5#", "J")]
        [InlineData("6#", "M")]
        [InlineData("7#", "P")]
        [InlineData("8#", "T")]
        [InlineData("9#", "W")]
        [InlineData("0#", " ")]
        public void SingleDigit_ReturnsCorrectCharacter(string input, string expected)
        {
            var result = OldPhoneKeyPad.OldPhonePad(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("11#", "'")]
        [InlineData("22#", "B")]
        [InlineData("33#", "E")]
        [InlineData("44#", "H")]
        [InlineData("55#", "K")]
        [InlineData("66#", "N")]
        [InlineData("77#", "Q")]
        [InlineData("88#", "U")]
        [InlineData("99#", "X")]
        [InlineData("00#", " ")]
        public void TwoDigits_ReturnsCorrectCharacter(string input, string expected)
        {
            var result = OldPhoneKeyPad.OldPhonePad(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("111#", "(")]
        [InlineData("222#", "C")]
        [InlineData("333#", "F")]
        [InlineData("444#", "I")]
        [InlineData("555#", "L")]
        [InlineData("666#", "O")]
        [InlineData("777#", "R")]
        [InlineData("888#", "V")]
        [InlineData("999#", "Y")]
        [InlineData("000#", " ")]
        public void ThreeDigits_ReturnsCorrectCharacter(string input, string expected)
        {
            var result = OldPhoneKeyPad.OldPhonePad(input);
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData("7777#", "S")]
        [InlineData("9999#", "Z")]
        [InlineData("0000#", " ")]
        public void FourDigits_ReturnsCorrectCharacter(string input, string expected)
        {
            var result = OldPhoneKeyPad.OldPhonePad(input);
            Assert.Equal(expected, result);
        }


        [Fact]
        public void AllCharactersByTheQuickBrownFox_ReturnsCorrectly()
        {
            var input = "1118443301177884442225511022777666966033366699058867 7777066688833777084433055529999 9990366641#";
            var result = OldPhoneKeyPad.OldPhonePad(input);
            var expected = "(THE 'QUICK' BROWN FOX JUMPS OVER THE LAZY DOG&";
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData("00#", " ")]
        [InlineData("000#", " ")]
        [InlineData("00 0#", "  ")]
        [InlineData("00100020003004#", " & A D G")]
        public void ConsecutiveZeros_ReturnsASingleWhiteSpace(string input, string expected)
        {
            var result = OldPhoneKeyPad.OldPhonePad(input);
            Assert.Equal(expected, result);
        }



        [Theory]
        [InlineData("#")]
        [InlineData(" #")]
        [InlineData("   #")]
        [InlineData("        #")]
        public void NullOrEmptyOrWhiteSpace_ReturnEmptyString(string input)
        {
            var result = OldPhoneKeyPad.OldPhonePad(input);

            Assert.Equal(string.Empty, result);
        }

        [Theory]
        [InlineData("5abc#")]
        [InlineData("5ABC#")]
        [InlineData("5@`4()*#")]
        [InlineData("5𡨸漢#")]
        public void NonDigitCharacters_AreIgnored(string input)
        {
            var result = OldPhoneKeyPad.OldPhonePad(input);

            Assert.Equal("J", result);

        }


        [Theory]
        [InlineData("*#")]
        [InlineData("***#")]
        [InlineData("* #")]
        [InlineData(" * #")]
        [InlineData("2*#")]
        [InlineData("2**#")]
        [InlineData("22***#")]
        [InlineData("2222****#")]
        [InlineData("22****22**#")]
        [InlineData("22****22**22***2*#")]
        [InlineData("22*22*22*2****#")]
        public void MultipleAsterisks_DeleteAllCharacter(string input)
        {
            var result = OldPhoneKeyPad.OldPhonePad(input);
            Assert.Equal(string.Empty, result);
        }

        [Theory]
        [InlineData("2* 3#")]
        [InlineData("2 2***3#")]
        [InlineData("22***2**3#")]
        [InlineData("2 2***2**2 2 2 2****2** 3 #")]
        public void MultipleAsterisks_DeleteAllCharacterExceptTheLast(string input)
        {
            var result = OldPhoneKeyPad.OldPhonePad(input);
            Assert.Equal("D", result);
        }

        [Theory]
        [InlineData("24*#")]
        [InlineData("2 4*2345****#")]
        public void MultipleAsterisks_DeleteAllCharacterExceptTheFirst(string input)
        {
            var result = OldPhoneKeyPad.OldPhonePad(input);
            Assert.Equal("A", result);
        }

        [Theory]
        [InlineData("2* 2 2*#")]
        [InlineData("22** 2 42**#")]
        public void MultipleAsterisks_DeleteAllCharacterExceptTheMiddle(string input)
        {
            var result = OldPhoneKeyPad.OldPhonePad(input);
            Assert.Equal("A", result);
        }


        [Theory]
        [InlineData("222 2 22#")]
        [InlineData("222  2 22#")]
        [InlineData("222  2  22#")]
        [InlineData("222  2  22 #")]
        [InlineData("222    2    22   #")]
        public void MultipleSpacesBetweenDigits_AreIgnored(string input)
        {
            var result = OldPhoneKeyPad.OldPhonePad(input);
            Assert.Equal("CAB", result);
        }

        [Theory]
        [InlineData("#2#")]
        [InlineData("##2#")]
        [InlineData("##2##")]
        public void MultipleHashes_AreIgnored(string input)
        {
            var result = OldPhoneKeyPad.OldPhonePad(input);
            Assert.Equal("A", result);
        }


        [Theory]
        [InlineData("222 2 22#", "CAB")]
        [InlineData("33#", "E")]
        [InlineData("“227*#", "B")]
        [InlineData("4433555 555666#", "HELLO")]
        [InlineData("8 88777444666*664#", "TURING")]
        public void ValidInputs_ReturnsExpectedOutput(string input, string expected)
        {
            var result = OldPhoneKeyPad.OldPhonePad(input);
            Assert.Equal(expected, result);
        }
    }
}
