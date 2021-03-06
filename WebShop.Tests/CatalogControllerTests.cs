﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using WebShop.Controllers;
using WebShop.Domain.Dto.Product;
using WebShop.Domain.Filters;
using WebShop.Domain.Models.Products;
using WebShop.Interfaces;

namespace WebShop.Tests
{
    [TestClass]
    public class CatalogControllerTests
    {
        [TestMethod]
        public void ProductDetails_Returns_View_With_Correct_Items()
        {
            var productMock = new Mock<IProductData>();
            productMock.Setup(p => p.GetProductById(It.IsAny<int>())).Returns(new ProductDto()
            {
                Id = 1,
                Name = "Test",
                ImageUrl = "TestImage.jpg",
                Order = 0,
                Price = 10,
                Brand = new BrandDto()
                {
                    Id = 1,
                    Name = "TestBrand"
                }
            });

            var controller = new CatalogController(productMock.Object);

            var result = controller.ProductDetails(1);

            var viewResult = Xunit.Assert.IsType<ViewResult>(result);
            var model = Xunit.Assert.IsAssignableFrom<ProductViewModel>(viewResult.ViewData.Model);
            Xunit.Assert.Equal(1, model.Id);
            Xunit.Assert.Equal("Test", model.Name);
            Xunit.Assert.Equal(10, model.Price);
            Xunit.Assert.Equal("TestBrand", model.Brand);
        }

        [TestMethod]
        public void ProductDetails_Returns_NotFound()
        {
            var productMock = new Mock<IProductData>();
            productMock.Setup(p => p.GetProductById(It.IsAny<int>())).Returns((ProductDto)null);
            var controller = new CatalogController(productMock.Object);

            var result = controller.ProductDetails(1);

            Xunit.Assert.IsType<NotFoundResult>(result);
        }

        [TestMethod]
        public void Shop_Method_Returns_Correct_View()
        {
            var productMock = new Mock<IProductData>();
            productMock.Setup(p => p.GetProducts(It.IsAny<ProiductFilter>())).Returns(new List<ProductDto>()
            {
                new ProductDto()
                {
                    Id = 1,
                    Name = "Test",
                    ImageUrl = "TestImage.jpg",
                    Order = 0,
                    Price = 10,
                    Brand = new BrandDto()
                    {
                        Id = 1,
                        Name = "TestBrand"
                    }
                },
                new ProductDto()
                {
                    Id = 2,
                    Name = "Test2",
                    ImageUrl = "TestImage2.jpg",
                    Order = 1,
                    Price = 22,
                    Brand = new BrandDto()
                    {
                        Id = 1,
                        Name = "TestBrand"
                    }
                }
            });
            var controller = new CatalogController(productMock.Object);

            var result = controller.Shop(1, 5);

            var viewResult = Xunit.Assert.IsType<ViewResult>(result);
            var model = Xunit.Assert.IsAssignableFrom<CatalogViewModel>(
                viewResult.ViewData.Model);

            Xunit.Assert.Equal(2, model.Products.Count());
            Xunit.Assert.Equal(5, model.BrandId);
            Xunit.Assert.Equal(1, model.SectionId);
            Xunit.Assert.Equal("TestImage2.jpg", model.Products.ToList()[1].ImageUrl);
        }
    }
}
