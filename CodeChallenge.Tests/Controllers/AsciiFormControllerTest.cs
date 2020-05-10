using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeChallenge;
using CodeChallenge.Controllers;
using CodeChallenge.Models;

namespace CodeChallenge.Tests.Controllers
{
    [TestClass]
    public class AsciiFormControllerTest
    {
        [TestMethod]
        public void Index()
        {
            AsciiFormController controller = new AsciiFormController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AsciiMapPath()
        {
            AsciiFormController controller = new AsciiFormController();
            AsciiForm formData = new AsciiForm() { AsciiMap = null};

            var result = controller.AsciiMapPath(formData);

            Assert.IsInstanceOfType(result, typeof (ActionResult));

        }
    }
}
