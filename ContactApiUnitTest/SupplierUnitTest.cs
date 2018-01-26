using ContactApi.Controllers;
using ContactApi.Models;
using ContactApi.Repository.Interface;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ContactApiUnitTest
{
    public class SupplierUnitTest
    {
        [Fact]
        public async Task GetSupplierll_ShouldReturnAllSuppliers()
        {
            //Arrange
            var repoMock = new Mock<ISupplierRepository>();
            repoMock.Setup(x => x.All()).ReturnsAsync(() => GetTestSuppliers());
            var controller = new SupplierController(repoMock.Object);

            //Action
            var result = await controller.Get();

            //Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var customers = okResult.Value.Should().BeAssignableTo<List<Supplier>>().Subject;

            customers.Count.Should().Be(4);
        }

        [Fact]
        public async Task FindSupplier_ShouldReturnCorrectSupplier()
        {
            //Arrange
            var repoMock = new Mock<ISupplierRepository>();
            var suppliers = GetTestSuppliers();
         
            repoMock.Setup(x => x.Find(1)).ReturnsAsync(() => suppliers.Find(c => c.Id == 1));
            var controller = new SupplierController(repoMock.Object);

            //Action
            var result = await controller.Get(1);

            //Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var customer = okResult.Value.Should().BeAssignableTo<Supplier>().Subject;

            customer.FirstName.Should().Be("Gaurav");
            customer.LastName.Should().Be("Singh");
            customer.Telephone.Should().Be("9898989898");
        }

        private List<Supplier> GetTestSuppliers()
        {
            var supplier = new List<Supplier>() {
                new Supplier() { FirstName = "Gaurav", LastName = "Singh", Id=1, Telephone="9898989898" },
                new Supplier() { FirstName = "Alberto", LastName = "Staley", Id=2, Telephone="9999988888" },
                new Supplier() { FirstName = "Harry", LastName = "Petty", Id=3, Telephone="9988998899" },
                new Supplier() { FirstName = "Ravi", LastName = "Udall", Id=4, Telephone="9998889898" },

            };
            return supplier;
        }
    }
}
