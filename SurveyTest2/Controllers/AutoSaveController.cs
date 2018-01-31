using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SurveyTest2.Controllers
{
    public class AutoSaveController : Controller
    {
        // GET: InputTest
        public ActionResult InputTest()
        {
            ViewBag.input1 = "David";
            ViewBag.input2 = "Tom";
            ViewBag.drop1 = "3";
            ViewBag.radio = "3";
            ViewBag.area1 = "";
            return View();
        }

        [HttpPost]
        public ActionResult SaveDB()
        {
            List<String> ans = new List<String>();
            try
            {
                ans.Add(Request.Form["a"]);
                ans.Add(Request.Form["txtinput1"]);
                ans.Add(Request.Form["txtinput2"]);
                ans.Add("radio: "+ Request.Form["optradio"]);
                ans.Add("check: "+ Request.Form["check"]);
                ans.Add("drop1: "+ Request.Form["drop1"]);
                ans.Add("drop2: " + Request.Form["drop2"]);

                ans.Add("area1: " + Request.Form["area1"].ToString());
                ans.Add("area2: " + Request.Form["area2"]);

            }
            catch(Exception ex){
                ans.Add( "Input Error!!!!" + ex.ToString());
            }
           
            try
            {
                HttpFileCollectionBase files = Request.Files;
                ans.Add(files.Count.ToString());
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];
                    if (file.FileName == "")
                        continue;

                    string fname = file.FileName;
                    ans.Add("Inside Else:"+fname);

                    // Get the complete folder path and store the file inside it.  
                    fname = System.IO.Path.Combine(Server.MapPath("~/Upload/"), fname);
                    file.SaveAs(fname);
                    
                }

            }
            catch (Exception ex)
            {
                ans.Add("File Error!!!!");
            }
            var jsonSerialiser = new JavaScriptSerializer();
            var jsonans = jsonSerialiser.Serialize(ans);


            return Json(jsonans); 
        }
    }
}