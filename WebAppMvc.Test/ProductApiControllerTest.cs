using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAppMvc.Controllers;
using WebAppMvc.Models.Entities;
using WebAppMvc.Models.MockData;
using WebAppMvc.Models.Services;

namespace WebAppMvc.Test;

public class ProductApiControllerTest
{
    private MoqData _moqData;

    public ProductApiControllerTest()
    {
        this._moqData = new MoqData();
    }

    [Fact]
    public void GetTest()
    {
        #region Arrange

        var moq = new Mock<IProductService>();
        moq.Setup(p => p.GetAll()).Returns(_moqData.GetAll());
        var apiController = new ProductApiController(moq.Object);

        #endregion

        #region Act

        var result = apiController.Get();

        #endregion

        #region Assert

        Assert.IsType<OkObjectResult>(result);
        Assert.IsType<List<Product>>((result as OkObjectResult).Value);


        #endregion
    }

    [Theory]
    [InlineData(1, -1)]
    public void GetByIdTest(int validId, int invalidId)
    {
        #region ValidId

        #region Arrange

        var moq = new Mock<IProductService>();
        moq.Setup(p => p.GetById(validId)).Returns(_moqData.GetAll().FirstOrDefault(p => p.Id == validId));
        var apiController = new ProductApiController(moq.Object);

        #endregion

        #region Act

        var result = apiController.Get(validId);

        #endregion

        #region Assert

        Assert.IsType<OkObjectResult>(result);
        Assert.IsType<Product>((result as OkObjectResult).Value);

        #endregion

        #endregion

        #region InvalidId

        #region Arrange

        moq.Setup(p => p.GetById(invalidId)).Returns(_moqData.GetAll().FirstOrDefault(p => p.Id == invalidId));

        #endregion

        #region Act

        var invalidResult= apiController.Get(invalidId);

        #endregion

        #region Assert

        Assert.IsType<NotFoundResult>(invalidResult);

        #endregion

        #endregion
    }

    [Fact]
    public void Post_Test()
    {
        #region valid

        #region Arrange

        var moq = new Mock<IProductService>();

        var productApiController = new ProductApiController(moq.Object);

        var product = new Product
        {
            Id = 1,
            Description = "cccc",
            Name = "Sumsoung",
            Price = 4500
        };

        #endregion

        #region Act

        var result = productApiController.Post(product);

        #endregion

        #region Assert

        Assert.IsType<CreatedAtActionResult>(result);

        #endregion

        #endregion
    }

    [Theory]
    [InlineData(1,-1)]
    public void DeleteTest(int validId,int invalidId)
    {
        #region Arrange

        var moq=new Mock<IProductService>();
        moq.Setup(p => p.Remove(validId));
        moq.Setup(p => p.GetById(validId)).Returns(_moqData.GetAll().FirstOrDefault(p => p.Id == validId));
        var apiController=new ProductApiController(moq.Object);

        #endregion

        #region Act

        var validResult = apiController.Delete(validId);
        var invalidResult = apiController.Delete(invalidId);

        #endregion

        #region Assert

        Assert.IsType<OkObjectResult>(validResult);
        Assert.IsType<NotFoundResult>(invalidResult);

        #endregion
    }
}