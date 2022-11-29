using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishMarketing.Data;
using FishMarketing.Models;
using FishMarketing.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FishMarketing.Controllers
{
    public class PurchasePlaceController : Controller
    {
        private readonly IMarketOrPurchasePlace purchasePlace;
        public PurchasePlaceController (IMarketOrPurchasePlace _purchasePlace)
        {
            purchasePlace = _purchasePlace;
        }

        // GET: PurchasePlaceController
        public ActionResult Index()
        {
            List<PurchasePlaceVm> PurchasePlaceListVm =new List<PurchasePlaceVm>();
            var PurchasePlaceList = purchasePlace.GetMarketOrPurchasePlaceList("P");
            PurchasePlaceVm PurchasePlace = new PurchasePlaceVm();
            foreach(var pur in PurchasePlaceList)
            {
                PurchasePlace = new PurchasePlaceVm();

                PurchasePlace.PurchasePlaceId = pur.MarketPurchasePlaceId;                
                PurchasePlace.Name = pur.Name;
                PurchasePlace.ContactName = pur.ContactName;
                PurchasePlace.Code = pur.Code;
                PurchasePlace.Address = pur.Address;
                PurchasePlace.Place = pur.Place;
                PurchasePlace.MobileNumber = pur.MobileNumber;
                PurchasePlace.Type = pur.Type;
                PurchasePlace.IsActive = pur.IsActive;

                PurchasePlaceListVm.Add(PurchasePlace);
            }



            return View(PurchasePlaceListVm);
        }

        // GET: PurchasePlaceController/Details/5
       

        // GET: PurchasePlaceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PurchasePlaceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PurchasePlaceVm purPlaceVm)
        {
            int UserloginId = HttpContext.Session.GetInt32("UserLoginId")??0;
            if (ModelState.IsValid)
            {
                try
                {
                    MarketAndPurchasePlace purPlace = new MarketAndPurchasePlace
                    {
                        Name = purPlaceVm.Name,
                        ContactName = purPlaceVm.ContactName,
                        Code = purPlaceVm.Code,
                        MobileNumber = purPlaceVm.MobileNumber,
                        Type = "P",
                        Address = purPlaceVm.Address,
                        Advance = 0,
                        Cdate = DateTime.Now,
                        Clogin= UserloginId,
                        Deposit=0,
                        IsActive=true,
                        Place= purPlaceVm.Place,
                        ProfCommission=0,                        
                    };
                    string result = purchasePlace.AddMarketOrPurchasePlace(purPlace);
                    if (result == "OK")
                        return RedirectToAction(nameof(Index));
                   
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: PurchasePlaceController/Edit/5
        public ActionResult Edit(int id)
        {
            var purchasePlase = purchasePlace.GetMarketOrPurchasePlace(id);
            if (purchasePlase == null)
            {
                NotFound();
            }
            PurchasePlaceVm purchasePlaseVm = new PurchasePlaceVm
            {
                PurchasePlaceId = purchasePlase.MarketPurchasePlaceId,
                Name = purchasePlase.Name,
                ContactName = purchasePlase.ContactName,
                Code = purchasePlase.Code,
                Address = purchasePlase.Address,
                Place = purchasePlase.Place,
                MobileNumber = purchasePlase.MobileNumber,
                Type = purchasePlase.Type,
                IsActive = purchasePlase.IsActive,
            };
            return View(purchasePlaseVm);

        }

        // POST: PurchasePlaceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PurchasePlaceVm purPlaceVm)
        {
            int UserloginId = HttpContext.Session.GetInt32("UserLoginId") ?? 0;           
            try
            {
                if(ModelState.IsValid)
                {
                    var purchasePlase = purchasePlace.GetMarketOrPurchasePlace(purPlaceVm.PurchasePlaceId);
                    purchasePlase.Name = purPlaceVm.Name;
                    purchasePlase.Code = purPlaceVm.Code;
                    purchasePlase.ContactName = purPlaceVm.ContactName;
                    purchasePlase.Address = purPlaceVm.Address;
                    purchasePlase.Place = purPlaceVm.Place;
                    purchasePlase.MobileNumber = purPlaceVm.MobileNumber;
                    purchasePlase.Mdate = DateTime.Now;
                    purchasePlase.Mlogin = UserloginId;                    

                    string result = purchasePlace.UpdateMarketOrPurchasePlace(purchasePlase);

                    if (result == "OK")
                        return RedirectToAction(nameof(Index));
                }
                
                return View(purPlaceVm);
            }
            catch(Exception ex)
            {
                return View(purPlaceVm);
            }
        }

        // GET: PurchasePlaceController/Delete/5
        public ActionResult Delete(int id)
        {
            var purplace = purchasePlace.GetMarketOrPurchasePlace(id);
            if (purplace == null)
            {
                return NotFound();
            }
            string result = purchasePlace.DeleteMarketOrPurchasePlace(purplace);
            return RedirectToAction(nameof(Index));
            
        }

        
    }
}
