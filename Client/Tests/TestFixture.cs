using System;
using Xunit;

namespace Tests
{

    using AutoMapper;

    using Client;
    using Client.DTOS;

    using Domain;

    public class TestFixture
    {
        private readonly IMapper mapper;

        public TestFixture()
        {
            //this.mapper = MapperFactory.GetMapper();
            this.mapper = ManualConfigMapperFactory.GetMapper();
        }

        [Fact]
        public void ProductToProductDTOTest()
        {
            //arrange
            var product = new Product { Name = "bicyle" };
            //act
            var res = mapper.Map<Product, PurchaseDetailsDTO>(product);
            //assert
            Assert.True(res.ProductName == "bicyle");
        }

        [Fact]
        public void CustomerToClientTest()
        {

            var res = mapper.Map<Customer, ClientDTO>(new Customer { Name = "John", Orders = new Order[] { new Order(), new Order() } });

            Assert.True(res.Name == "John");
            Assert.True(res.OrdersCount == 2);
        }

    }
}
