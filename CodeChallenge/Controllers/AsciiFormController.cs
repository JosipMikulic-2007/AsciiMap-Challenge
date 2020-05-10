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
            if (formData.AsciiMap == null || !ModelState.IsValid)
            {
                return Json(new { ErrorMessage = "Txt file with ASCII map is required" }, @"application/json");
            }

            var result = AsciiMapService.ProcessUploadedFile(formData.AsciiMap);

            return Json(new { MapResult = result }, @"application/json");
        }
    }
}