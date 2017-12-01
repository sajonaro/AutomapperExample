using System;
using Xunit;

namespace Tests
{
    using System.Linq;

    using AutoMapper;
    using AutoMapper.Configuration;

    using Client;
    using Client.DTOS;

    using Domain;

    public class TestFixture
    {
        private readonly IMapper mapper;

        public TestFixture()
        {
            // this.mapper = MapperFactory.GetMapper();
             this.mapper = ManualConfigMapperFactory.GetMapper();
            this.mapper = ProfileBasedMapperFactory.GetMapper();
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



        [Fact]
        public void CustomMappingToElementTest()
        {
            //arrange
            var product = new Product
            {
                Name = "bicyle",

                Orders = new Order[]
                    {
                        new Order {Amout = 5},
                        new Order {Amout = 10}
                    }
            };

            var dest = this.mapper.Map<Product, PurchaseDetailsDTO>(product);

            Assert.True(dest.OrderAmounts.Length ==2);
            Assert.True(dest.OrderAmounts.First().EpsilonEquals(5.0));
        }


        [Fact]
        public void NewTest()
        {
            Mapper.Initialize(
                cfg =>
                    {
                        //clientDTO
                        cfg.CreateMap<Customer, ClientDTO>();

                        //PurchaseDetailsDTO
                        cfg.CreateMap<Product, PurchaseDetailsDTO>().
                            ForMember(m => m.ProductName, opt =>
                                opt.MapFrom(e => e.Name));
                    });

            var s = Mapper.Map<Product, PurchaseDetailsDTO>(new Product());

        }
    }
}
