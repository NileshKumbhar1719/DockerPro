using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD.Controllers;
using CRUD.DTOs;
using CRUD.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace CRUD.API.Test
{
    [TestFixture]
    public class OrderPROTests
    {
        private Mock<ICRUDService> _serviceMock;
        private Mock<ILogger<OrderPRO>> _loggerMock;
        private OrderPRO _controller;

        [SetUp]
        public void SetUp()
        {
            _serviceMock = new Mock<ICRUDService>();
            _loggerMock = new Mock<ILogger<OrderPRO>>();

            _controller = new OrderPRO(
                _serviceMock.Object,
                _loggerMock.Object
            );
        }

        [Test]
        public async Task GetAllOrders_ReturnsOkResult_WithData()
        {
            // Arrange
            var expectedOrders = new List<OrderDTOs>
            {
                new OrderDTOs
                {
                    Id = 1,
                    Status = "Pending",
                    TotalAmount = 100
                },
                new OrderDTOs
                {
                    Id = 2,
                    Status = "Completed",
                    TotalAmount = 200
                }
            };

            _serviceMock
                .Setup(s => s.GetAllData(1, 1940))
                .ReturnsAsync(expectedOrders);

            // Act
            var result = await _controller.GetAllOrders();

            // Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());

            var okResult = (OkObjectResult)result;

            Assert.That(okResult.StatusCode ?? 200, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo(expectedOrders));
        }

        [Test]
        public async Task GetAllOrders_CallsServiceWithCorrectParameters()
        {
            // Act
            await _controller.GetAllOrders(2, 10);

            // Assert
            _serviceMock.Verify(
                s => s.GetAllData(2, 10),
                Times.Once);
        }
    }
}