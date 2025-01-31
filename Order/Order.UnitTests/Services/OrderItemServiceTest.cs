﻿using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Order.Host.Data.Entities;
using Order.Host.Models.Dto;

namespace Order.UnitTests.Services
{
    public class OrderItemServiceTest
    {
        private readonly IOrderItemService _service;

        private readonly Mock<ILogger<OrderItemService>> _logger;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IOrderItemRepository> _repository;
        private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _wrapper;

        public OrderItemServiceTest()
        {
            _repository = new Mock<IOrderItemRepository>();
            _mapper = new Mock<IMapper>();
            _logger = new Mock<ILogger<OrderItemService>>();
            _wrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();

            var dbContextTransaction = new Mock<IDbContextTransaction>();
            _wrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

            _service = new OrderItemService(
                _wrapper.Object,
                _logger.Object,
                _repository.Object,
                _mapper.Object,
                _logger.Object);
        }

        [Fact]
        public async Task Add_Succesful()
        {
            // arrange
            var testName = "Test";
            var testCost = 10m;
            var testOrderId = 5;
            var testId = 5;
            _repository.Setup(s => s.Add(testName, testCost, testOrderId)).ReturnsAsync(testId);

            // act
            var result = await _service.Add(testName, testCost, testOrderId);

            // assert
            result.Should().NotBeNull();
            result.Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task Add_Failed()
        {
            // arrange
            var testName = "Test";
            var testCost = 10m;
            var testOrderId = 5;
            int? testId = null!;
            _repository.Setup(s => s.Add(testName, testCost, testOrderId)).ReturnsAsync(testId);

            // act
            var result = await _service.Add(testName, testCost, testOrderId);

            // assert
            result.Should().NotBeNull();
            result.Should().Be(0);
        }

        [Fact]
        public async Task Get_Succesful()
        {
            // arrange
            var testId = 5;
            var testName = "Test";
            var testCost = 5m;
            var testItem = new OrderItem()
            {
                Id = testId,
                Name = testName,
                Cost = testCost,
            };

            var testEntity = new OrderItemEntity()
            {
                Id = testId,
                Name = testName,
                Cost = testCost,
            };
            _repository.Setup(s => s.Get(testId)).ReturnsAsync(testEntity);
            _mapper.Setup(s => s.Map<OrderItem>(It.Is<OrderItemEntity>(i => i.Equals(testEntity)))).Returns(testItem);

            // act
            var result = await _service.Get(testId);

            // assert
            result.Should().NotBeNull();
            result.Should().NotBe(new OrderItem());
        }

        [Fact]
        public async Task Get_Failed()
        {
            // arrange
            var testId = 5;
            OrderItemEntity testEntity = null!;
            _repository.Setup(s => s.Get(testId)).ReturnsAsync(testEntity);

            // act
            var result = await _service.Get(testId);

            // assert
            result.Should().NotBeNull();
            result?.Name.Should().BeNullOrEmpty();
            result?.Cost.Should().Be(0);
        }

        [Fact]
        public async Task Delete_Succesful()
        {
            // arrange
            var testResult = true;
            _repository.Setup(s => s.Delete(It.IsAny<int>())).ReturnsAsync(testResult);

            // act
            var result = await _service.Delete(It.IsAny<int>());

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task Delete_Failed()
        {
            // arrange
            var testResult = false;
            _repository.Setup(s => s.Delete(It.IsAny<int>())).ReturnsAsync(testResult);

            // act
            var result = await _service.Delete(It.IsAny<int>());

            // assert
            result.Should().BeFalse();
        }
    }
}
