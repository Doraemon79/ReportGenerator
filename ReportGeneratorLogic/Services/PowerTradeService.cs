using Axpo;
using ReportGeneratorLogic.Services.Interfaces;
using Serilog;

namespace ReportGeneratorLogic.Services
{
    public class PowerTradeService : IPowerTradeService
    {
        public async Task<IEnumerable<PowerTrade>> GetTradesAsync(DateTime date)
        {
            Log.Information("Getting trades for {date}", date);
            var powerService = new PowerService();
            var st = powerService.GetTradesAsync(date);
            return await powerService.GetTradesAsync(date);
        }
    }
}
