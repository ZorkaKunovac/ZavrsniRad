using System.Text.RegularExpressions;
using Xamarin.Forms.Internals;

namespace GamingHub2.MobileApp.Validators.Rules
{
    /// <summary>
    /// Validation Rule to check if a field value matches the provided regular expression.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class IsValidRegexRule : IValidationRule<string>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Validation Message.
        /// </summary>
        public string ValidationMessage { get; set; }
        public string RegexRule { get; set; }

        #endregion

        #region Method

        /// <summary>
        /// Check the value is valid or not
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>returns bool value</returns>
        public bool Check(string value)
        {
            return string.IsNullOrEmpty(value) ||
                   Regex.IsMatch(value.ToString(), RegexRule, RegexOptions.IgnoreCase);
        }
        #endregion
    }
}
