using FishMarketing.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishMarketing.Data
{
    public class MarketOrPurchasePlaceData : IMarketOrPurchasePlace
    {
        private readonly FishMarketContext db;
        public MarketOrPurchasePlaceData(FishMarketContext _db)//Dependancy Injuction
        {
            db = _db;
        }
        public List<MarketAndPurchasePlace> GetMarketOrPurchasePlaceList(string _type)
        {
            List<MarketAndPurchasePlace> marketOrPurchasePlaceList = new List<MarketAndPurchasePlace>();
            if (_type != "")
                marketOrPurchasePlaceList = db.MarketAndPurchasePlaces.Where(a => a.Type == _type).ToList();
            else
                marketOrPurchasePlaceList = db.MarketAndPurchasePlaces.ToList();
            return marketOrPurchasePlaceList;
        }
        public MarketAndPurchasePlace GetMarketOrPurchasePlace(int id)
        {
            MarketAndPurchasePlace marketOrPurchasePlace = new MarketAndPurchasePlace();
            marketOrPurchasePlace = db.MarketAndPurchasePlaces.Include(a => a.Ledgers).FirstOrDefault(a => a.MarketPurchasePlaceId == id);
            return marketOrPurchasePlace;
        }
        public string AddMarketOrPurchasePlace(MarketAndPurchasePlace model)
        {
            try
            {

                Ledger ledger = new Ledger
                {
                    Id = model.Code,
                    Cdate = model.Cdate,
                    IsActive = true,
                    LedgerGroupId = 19,
                    Name = model.Name,
                    Type = model.Type,
                    MarketOrPurchae = model,
                };

                db.Ledgers.Add(ledger);
                db.SaveChanges();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        public string UpdateMarketOrPurchasePlace(MarketAndPurchasePlace model)
        {
            try
            {
                foreach(var ledger in model.Ledgers)
                {
                    ledger.Id = model.Code;
                    ledger.Name = model.Name;
                    ledger.Mdate = model.Mdate;

                    db.Ledgers.Update(ledger);
                }
                db.MarketAndPurchasePlaces.Update(model);
                db.SaveChanges();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
           
        }
        public string DeleteMarketOrPurchasePlace(MarketAndPurchasePlace model)
        {
            try
            {
                foreach (var ledger in model.Ledgers)
                {   
                    db.Ledgers.Remove(ledger);
                }
                db.MarketAndPurchasePlaces.Remove(model);
                db.SaveChanges();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
           
        }
    }
}
