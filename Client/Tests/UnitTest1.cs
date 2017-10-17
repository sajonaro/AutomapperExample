using System;
using Xunit;

namespace Tests
{
    using System.Security.Cryptography.X509Certificates;

    using AutoMapper;

    using Client;
    using Client.DTOS;

    using Domain;

    public class UnitTest1
    {
        [Fact]
        public void ProductToProductDTOTest()
        {
            IMapper mapper = MapperFactory.GetMapper();

            var product = new Product{Name = "bicyle"};

            var res = mapper.Map<Product,PurchaseDetailsDTO>(product);

            Assert.True(res.ProductName == "bicyle");
        }

        [Fact]
        public void CustomerToClientTest()
        {
            IMapper mapper = MapperFactory.GetMapper();

            var res = mapper.Map<Customer, ClientDTO>(new Customer{Name = "John"});

            Assert.True(res.Name == "John");
        }

    }
}
