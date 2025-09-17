using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherForecastMobileClient;

namespace WeatherForecastMobileClient.Tests
{
    [TestClass]
    public class MainPageTests
    {
        [TestMethod]
        public void GetCounterText_ReturnsSingleTime_WhenCountIsOne()
        {
            var result = MainPage.GetCounterText(1);
            Assert.AreEqual("Clicked 1 time", result);
        }

        [TestMethod]
        public void GetCounterText_ReturnsTimes_WhenCountIsGreaterThanOne()
        {
            var result = MainPage.GetCounterText(2);
            Assert.AreEqual("Clicked 2 times", result);
        }
    }
}
