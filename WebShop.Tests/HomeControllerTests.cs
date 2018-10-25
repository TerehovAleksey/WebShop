using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebShop.Controllers;

namespace WebShop.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        private HomeController _controller;

        [TestInitialize]
        public void SetupTest()
        {
            _controller = new HomeController();
        }

        [TestMethod]
        public void Index_Method_Returns_View()
        {
            var result =  _controller.Index();
            var model = Xunit.Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void ErrorStatus_404_Redirects_To_NotFound()
        {
            var result = _controller.ErrorStatus("404");
            var redirectToActionResult = Xunit.Assert.IsType<RedirectToActionResult>(result);
            Xunit.Assert.Null(redirectToActionResult.ControllerName);
            Xunit.Assert.Equal("PageNotFound", redirectToActionResult.ActionName);
        }

        [TestMethod]
        public void ErrorStatus_Another_Returns_ContentResult()
        {
            var result = _controller.ErrorStatus("500");
            var contentResult = Xunit.Assert.IsType<ContentResult>(result);
            Xunit.Assert.Equal("Статусный код ошибки: 500", contentResult.Content);
        }

        [TestMethod]
        public void Shop_Method_Returns_View()
        {
            var result = _controller.Shop();
            var model = Xunit.Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void ProductDetails_Method_Returns_View()
        {
            var result = _controller.ProductDetails();
            var model = Xunit.Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void Login_Method_Returns_View()
        {
            var result = _controller.Login();
            var model = Xunit.Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void ContactUs_Method_Returns_View()
        {
            var result = _controller.ContactUs();
            var model = Xunit.Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void ChekOut_Method_Returns_View()
        {
            var result = _controller.CheckOut();
            var model = Xunit.Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void Cart_Method_Returns_View()
        {
            var result = _controller.Cart();
            var model = Xunit.Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void BlogSingle_Method_Returns_View()
        {
            var result = _controller.BlogSingle();
            var model = Xunit.Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void Blog_Method_Returns_View()
        {
            var result = _controller.Blog();
            var model = Xunit.Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void Error_Method_Returns_View()
        {
            var result = _controller.Error();
            var model = Xunit.Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void PageNotFound_Method_Returns_View()
        {
            var result = _controller.PageNotFound();
            var model = Xunit.Assert.IsType<ViewResult>(result);
        }
    }
}
