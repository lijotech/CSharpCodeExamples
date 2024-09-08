using ExtendFactoryPatternUsingDI.Interface;

namespace ExtendFactoryPatternUsingDI.Services
{
    /// <summary>
    /// Some service for generating prefix of the label
    /// </summary>
    public class PrefixGenService : IPrefixGenService
    {
        public string GetPrefix()
        {
            // Get the current month name
            string monthName = DateTime.Now.ToString("MMMM");

            // Get the first and last letter of the month name
            string prefix = monthName[0].ToString() + monthName[monthName.Length - 1].ToString();

            return prefix.ToUpper();
        }
    }
}