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
    public class CustomerUnitTest
    {
        [Fact]
        public async Task GetCustomerAll_ShouldReturnAllCustomers()
        {
            //Arrange
            var repoMock = new Mock<ICustomerRepository>();
            repoMock.Setup(x => x.All()).ReturnsAsync(() => GetTestCustomer());
            var controller = new CustomerController(repoMock.Object);

            //Action
            var result = await controller.Get();

            //Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var customers = okResult.Value.Should().BeAssignableTo<List<Customer>>().Subject;

            customers.Count.Should().Be(4);
        }

        [Fact]
        public async Task FindCustomer_ShouldReturnCorrectCustomer()
        {
            //Arrange
            var repoMock = new Mock<ICustomerRepository>();
            var customers = GetTestCustomer();
         
            repoMock.Setup(x => x.Find(1)).ReturnsAsync(() => customers.Find(c => c.Id == 1));
            var controller = new CustomerController(repoMock.Object);

            //Action
            var result = await controller.Get(1);

            //Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var customer = okResult.Value.Should().BeAssignableTo<Customer>().Subject;

            customer.FirstName.Should().Be("Gaurav");
            customer.LastName.Should().Be("Singh");
            customer.Email.Should().Be("gaurav.singh@abc.com");
        }

        private List<Customer> GetTestCustomer()
        {
            var customers = new List<Customer>() {
                new Customer() { FirstName = "Gaurav", LastName = "Singh", BirthDay = DateTime.Parse("Apr 07, 1985"), Id=1, Email="gaurav.singh@abc.com" },
                new Customer() { FirstName = "Alberto", LastName = "Staley", BirthDay = DateTime.Parse("Apr 07, 1983"), Id=2, Email="alberto.staley@abc.com" },
                new Customer() { FirstName = "Harry", LastName = "Petty", BirthDay = DateTime.Parse("Apr 07, 1982"), Id=3, Email="harry.petty@abc.com" },
                new Customer() { FirstName = "Ravi", LastName = "Udall", BirthDay = DateTime.Parse("Apr 07, 1980"), Id=4, Email="ravi.udall@abc.com" },

            };
            return customers;
        }
    }
}
