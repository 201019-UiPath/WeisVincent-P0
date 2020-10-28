using SufferShopLib.Validation;
using System;
using System.Data;
using Xunit;

namespace SufferShopLibTest
{
    public class InputValidatorTest
    {
        #region One Digit Condition tests (IsOneDigitCondition)
        [Theory]
        [InlineData("1")]
        [InlineData("3")]
        public void OneDigitInputShouldReturnTrue(string input)
        {
            InputValidator validator = new InputValidator(input, new IsOneDigitCondition());

            Assert.True(validator.InputIsValidated());

        }

        [Theory]
        [InlineData("12")]
        [InlineData("345")]
        public void NotOneDigitInputShouldReturnFalse(string input)
        {
            InputValidator validator = new InputValidator(input, new IsOneDigitCondition());

            Assert.False(validator.InputIsValidated());

        }
        #endregion

        #region One or Two Digit Condition tests (IsOneOrTwoDigitsCondition)
        [Theory]
        [InlineData("12")]
        [InlineData("3")]
        public void TwoOrOneDigitInputShouldReturnTrue(string input)
        {
            InputValidator validator = new InputValidator(input, new IsOneOrTwoDigitsCondition());

            Assert.True(validator.InputIsValidated());

        }

        [Theory]
        [InlineData("12345")]
        [InlineData("678")]
        public void MoreThanTwoDigitInputShouldReturnFalse(string input)
        {
            InputValidator validator = new InputValidator(input, new IsOneOrTwoDigitsCondition());

            Assert.False(validator.InputIsValidated());

        }
        #endregion

        #region Two Words Condition tests (IsTwoWordsCondition)
        [Theory]
        [InlineData("Yes Mr")]
        [InlineData("Mr Moist")]
        public void TwoWordInputShouldReturnTrue(string input)
        {
            InputValidator validator = new InputValidator(input, new IsTwoWordsCondition());

            Assert.True(validator.InputIsValidated());
        }

        [Theory]
        [InlineData("Yes sir ree")]
        [InlineData("ILostMySpaceBar")]
        public void NotTwoWordInputShouldReturnFalse(string input)
        {
            InputValidator validator = new InputValidator(input, new IsTwoWordsCondition());

            Assert.False(validator.InputIsValidated());
        }
        #endregion

        #region Empty/Null Condition tests (NotEmptyInputCondition)
        [Theory]
        [InlineData("some")]
        [InlineData("body once told me")]
        public void NotEmptyInputShouldReturnTrue(string input)
        {
            InputValidator validator = new InputValidator(input, new NotEmptyInputCondition());

            Assert.True(validator.InputIsValidated());
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyInputShouldReturnFalse(string input)
        {
            InputValidator validator = new InputValidator(input, new NotEmptyInputCondition());

            Assert.False(validator.InputIsValidated());
        }
        #endregion

        #region Email Condition tests (IsEmailCondition)
        [Theory]
        [InlineData("email@email.xyz")]
        [InlineData("I.Am.Ironman@gmail.com")]
        public void EmailInputShouldReturnTrue(string input)
        {
            InputValidator validator = new InputValidator(input, new IsEmailCondition());

            Assert.True(validator.InputIsValidated());
        }

        [Theory]
        [InlineData("em@ail@email.com")]
        [InlineData("I.Am.Ironman@g@mail.com")]
        [InlineData("Vincent.Weis")]
        public void NotEmailInputShouldReturnFalse(string input)
        {
            InputValidator validator = new InputValidator(input, new IsEmailCondition());

            Assert.False(validator.InputIsValidated());
        }
        #endregion


        [Fact]
        public void InputValidatorWithNullInputConditionsShouldThrowNoNullArgumentException()
        {
            InputValidator validator = new InputValidator("sampleinput", new IsEmailCondition());
            

            Assert.Throws<NoNullAllowedException>( () => validator.InputConditions = null );
        }


    }
}
