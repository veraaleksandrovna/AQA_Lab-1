using NLog;
namespace JsonSerialization;

public class Phone
{
    private static Logger logger = LogManager.GetCurrentClassLogger();

    public string Model { get; set; }

    public string OperationSystemType { get; set; }

    public string MarketLaunchDate { get; set; }

    public string Price { get; set; }

    public bool IsAvailable { get; set; }

    public int ShopId { get; set; }

    public void Report()
    {
        logger.Info(
            $"Modet: {Model}, OperationSystemType: {OperationSystemType}, MarketLaunchDate: {MarketLaunchDate}, " +
            $"Price: {Price}, ShopId: {Program.shops.ShopByNumber(ShopId)}\n");
    }
}
