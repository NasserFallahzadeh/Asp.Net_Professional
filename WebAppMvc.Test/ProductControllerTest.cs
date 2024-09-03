using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAppMvc.Controllers;
using WebAppMvc.Models.Entities;
using WebAppMvc.Models.MockData;
using WebAppMvc.Models.Services;

namespace WebAppMvc.Test;

public class ProductControllerTest
{
    [Fact]
    public void Index_Test()
    {
        #region Arrange

        var moqData = new MoqData();

        var moq = new Mock<IProductService>();
        moq.Setup(p => p.GetAll()).Returns(moqData.GetAll());

        var productController = new ProductController(moq.Object);

        #endregion

        #region Act

        var result = productController.Index();

        #endregion

        #region Assert

        Assert.IsType<ViewResult>(result);

        Assert.IsAssignableFrom<List<Product>>((result as ViewResult).Model);

        #endregion
    }

    [Theory]
    [InlineData(1, -1)]
    public void Details_Test(int validId, int invalidId)
    {
        #region valid

        #region Arrange

        var moqData = new MoqData();

        var moq = new Mock<IProductService>();
        moq.Setup(p => p.GetById(validId)).Returns(moqData.GetAll().FirstOrDefault(p => p.Id == validId));

        var productController = new ProductController(moq.Object);

        #endregion

        #region Act

        var result = productController.Details(validId);

        #endregion

        #region Assert

        Assert.IsType<ViewResult>(result);

        Assert.IsAssignableFrom<Product>((result as ViewResult).Model);

        #endregion

        #endregion

        #region invalid

        #region Arrange

        moq.Setup(p => p.GetById(invalidId)).Returns(moqData.GetAll().FirstOrDefault(p => p.Id == invalidId));

        #endregion

        #region Act

        var invalidResult = productController.Details(invalidId);

        #endregion

        #region Assert

        Assert.IsType<NotFoundResult>(invalidResult);

        #endregion

        #endregion
    }

    [Fact]
    public void Create_Test()
    {
        #region valid

        #region Arrange

        var moq = new Mock<IProductService>();

        var productController = new ProductController(moq.Object);

        var product = new Product
        {
            Id = 1,
            Description = "cccc",
            Name = "Sumsoung",
            Price = 4500
        };

        #endregion

        #region Act

        var result = productController.Create(product);

        #endregion

        #region Assert

        var redirect = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirect.ActionName);
        Assert.Null(redirect.ControllerName);

        #endregion

        #endregion

        #region invlaid

        #region Arrange

        var invalidProduct = new Product
        {
            Price = 5
        };

        productController.ModelState.AddModelError(nameof(Product.Name),"لطفا نام را وارد کنید");

        #endregion

        #region Act

        var invalidResult = productController.Create(invalidProduct);

        #endregion

        #region Assert

        Assert.IsType<BadRequestObjectResult>(invalidResult);

        #endregion

        #endregion
    }
}