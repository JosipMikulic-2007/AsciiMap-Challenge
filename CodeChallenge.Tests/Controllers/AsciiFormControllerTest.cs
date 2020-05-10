using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeChallenge;
using CodeChallenge.Controllers;

namespace CodeChallenge.Tests.Controllers
{
    [TestClass]
    public class AsciiFormControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            AsciiFormController controller = new AsciiFormController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
