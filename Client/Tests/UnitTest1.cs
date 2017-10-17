using System;
using Xunit;

namespace Tests
{
    using System.Security.Cryptography.X509Certificates;

    using AutoMapper;

    using Client;

    using Domain;

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            ReflectionBasedAutomapperConfiguration.ConfigureMapping();

            var p = new Order{Amout = 10,PurchaseDEscription = "test"};

            var res = Mapper.Map<PurchaseDetailsDTO>(p);



            Assert.True(res != null);
        }

    }
}
