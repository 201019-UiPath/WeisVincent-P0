using SufferShopBL;
using SufferShopBL.Validation;
using Xunit;

namespace SufferShopBLTest
{
    public class InputValidatorTest
    {
        [Theory]
        [InlineData("1")]
        [InlineData("3")]
        public void InputStringShouldHaveOneDigit(string input)
        {
            InputValidator validator = new InputValidator(input, new IsOneDigitCondition());

            Assert.True(validator.InputIsValidated());

        }

        [Theory]
        [InlineData("12")]
        [InlineData("345")]
        public void InputStringShouldNotHaveOneDigit(string input)
        {
            InputValidator validator = new InputValidator(input, new IsOneDigitCondition());

            Assert.False(validator.InputIsValidated());

        }


        [Theory]
        [InlineData("some")]
        [InlineData("body once told me")]
        public void InputStringShouldNotBeEmpty(string input)
        {
            InputValidator validator = new InputValidator(input, new NotEmptyInputCondition());

            Assert.True(validator.InputIsValidated());
        }

        [Theory]
        [InlineData("Yes Mr")]
        [InlineData("Mr Moist")]
        public void InputStringShouldBeTwoWords(string input)
        {
            InputValidator validator = new InputValidator(input, new IsTwoWordsCondition());

            Assert.True(validator.InputIsValidated());
        }
        
    }
}
