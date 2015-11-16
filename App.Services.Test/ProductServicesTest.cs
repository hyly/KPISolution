using System;
using NUnit.Framework;
using Moq;
using App.Data.DomainModel;
using App.Data.DomainModel.Entities;
using App.Services.Implementation;
using App.Services.Core;

namespace App.Services.Test
{
    [TestFixture]
    public class ProductServicesTest
    {
        private Mock<IUnitOfWork> mockUnitOfWork = null;
        private Mock<IProductRepository> mockRepository = null;
        private ProductServices services = null;

        public ProductServicesTest()
        {
            this.mockRepository = this.CreateMockRepository();
            this.mockUnitOfWork = this.CreateMockUnitOfWork();
            services = new ProductServices(mockUnitOfWork.Object);
            ObjectMapper.CreateObjectServicesMap();
        }

        private Mock<IProductRepository> CreateMockRepository()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>(MockBehavior.Strict);
            mock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Product(){
                    Active=true,Color="Yellow",Name="Test 1",ProductId=1
                })
                .Verifiable();
            return mock;
            
        }

        private Mock<IUnitOfWork> CreateMockUnitOfWork()
        {
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>(MockBehavior.Strict);
            mock.Setup(x => x.ProductRepository).Returns(this.mockRepository.Object).Verifiable();
            return mock;
        }

        [Test]
        public void GetProductByIdTest()
        {
            var product = this.services.GetProductById(1);
            Assert.IsNotNull(product);
        }
    }
}
