using Axpo;
using Moq;
using ReportGeneratorLogic.Services;

namespace ReportGeneratorTests
{
    public class PowerTradeServiceTest
    {
        private readonly PowerTradeService PowerTradeService_Sut;
        private readonly Mock<PowerService> _powerTradeServiceMock = new Mock<PowerService>();



        public PowerTradeServiceTest()
        {
            PowerTradeService_Sut = new PowerTradeService();
        }

        [Fact]
        public void ShouldTakeTradeRecordsAndWriteToCsv()
        {
            //Arrange
            PowerPeriod period1 = new PowerPeriod(1);
            PowerPeriod period2 = new PowerPeriod(2);
            PowerPeriod period3 = new PowerPeriod(3);
            PowerPeriod[] periods = { period1, period2, period3 };
            DateTime dateTest = new DateTime(2021, 1, 1);
            PowerTrade pw1 = PowerTrade.Create(dateTest, 3);
            PowerTrade pw2 = PowerTrade.Create(dateTest, 3);

            //Act
            var service = new PowerTradeService();
            Moq.Language.Flow.IReturnsResult<PowerService> returnsResult = _powerTradeServiceMock.Setup(x => x.GetTradesAsync(dateTest)).ReturnsAsync(new List<PowerTrade> { pw1, pw2 });
            var test = service.GetTradesAsync(dateTest);

            //Assert
            Assert.Equal(2, test.Result.Count());
        }
    }
}