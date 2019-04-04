using JHilburnFabricManager.Models;
using JHilburnFabricManager.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace JHilburnFabricManager.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {         
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FabricList()
        {
            List<FabricViewModel> fabricList = null;
            fabricList = GetFabrics();
            //ViewBag.FabricList = fabricLsit;
            return View(fabricList);
        }

        public ActionResult AddEditFabric(int id)
        {
            if(id > 0)
            {
                var fabric = GetFabricById(id);
                return View(fabric);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEditFabric(FabricViewModel model)
        {
            if (ModelState.IsValid)
            {               
                var result = "";
                if (model.Id > 0)
                {
                    var url = "/fabrics/" + model.Id;
                    var jsonObj = new JavaScriptSerializer().Serialize(model);
                    result = Common.Put(url, model);
                }
                else
                {
                    var url = "/fabrics";
                    result = Common.Post(url, model);
                }

                if(result != null || result != "Invalid Fabric")
                {
                    return RedirectToAction("Confirmation", "Home");
                    //return RedirectToMainPage();
                }
            }
            return View();
        }


        public ActionResult Delete(int id)
        {
            var fabric = GetFabricById(id);
            return PartialView("_DeleteFabric", fabric);
        }

        public ActionResult DeleteFabric(int id)
        {
            var url = "/fabrics/" + id;
            Common.Delete(url);
            return RedirectToMainPage();
        }

        public ActionResult ManageFabricInventory()
        {
            List<FabricViewModel> fabricList = null;
            fabricList = GetFabrics();
            int totalInventory = 0;
            foreach(var fab in fabricList)
            {
                int itemCount = fab.Inventory;
                totalInventory = totalInventory + itemCount;
            }
            ViewBag.TotalInventory = totalInventory;
            return View(fabricList);
        }

        public ActionResult Confirmation()
        {
            return View();
        }

        #region Helpers
        private ActionResult RedirectToMainPage()
        {
            return RedirectToAction("FabricList", "Home");
        }

        public List<FabricViewModel> GetFabrics()
        {
            var url = "/fabrics";

            var output = Common.Get(url);
            List<FabricViewModel> result = JsonConvert.DeserializeObject<List<FabricViewModel>>(output);

            return result;
        }

        private FabricViewModel GetFabricById(int id)
        {
            FabricViewModel model = null;
            var url = "/fabrics/" + id;
            var result = Common.Get(url);
            model = JsonConvert.DeserializeObject<FabricViewModel>(result);
            return model;
        }
        #endregion
    }
}