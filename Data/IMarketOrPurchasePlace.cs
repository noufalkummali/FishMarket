using FishMarketing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishMarketing.Data
{
    public interface IMarketOrPurchasePlace
    {
        List<MarketAndPurchasePlace> GetMarketOrPurchasePlaceList(string type);
        MarketAndPurchasePlace GetMarketOrPurchasePlace(int id);
        string AddMarketOrPurchasePlace(MarketAndPurchasePlace model);
        string UpdateMarketOrPurchasePlace(MarketAndPurchasePlace model);
        string DeleteMarketOrPurchasePlace(MarketAndPurchasePlace model);

    }
}
