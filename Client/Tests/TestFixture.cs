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

            var product = new Product{Name = "bicyle"};

            var res = mapper.Map<Product,PurchaseDetailsDTO>(product);

            Assert.True(res.ProductName == "bicyle");
        }

        [Fact]
        public void CustomerToClientTest()
        {

            var res = mapper.Map<Customer, ClientDTO>(new Customer{Name = "John"});

            Assert.True(res.Name == "John");
        }

    }
}
