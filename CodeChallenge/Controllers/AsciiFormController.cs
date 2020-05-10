using CodeChallenge.Models;
using CodeChallenge.Services;
using System.Web.Mvc;

namespace CodeChallenge.Controllers
{
    public class AsciiFormController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ActionResult AsciiMapPath(AsciiForm formData)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { ErrorMessage = "Ascii map txt file is required" }, @"application/json");
            }

            var result = AsciiMapService.ProcessUploadedFile(formData.AsciiMap);

            return Json(new { MapResult = result }, @"application/json");
        }
    }
}