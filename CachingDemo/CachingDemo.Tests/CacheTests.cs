using CachingDemo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CachingDemo.Tests
{
    /*
    [TestClass]
    public class CacheTests
    {
        private MockRepository mockRepository;

        private Mock<IRepository<TKey, T>> mockRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockRepository = this.mockRepository.Create<IRepository<TKey, T>>();
        }

        private Cache CreateCache()
        {
            return new Cache(
                this.mockRepository.Object,
                TODO,
                TODO,
                TODO);
        }

        [TestMethod]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var cache = this.CreateCache();
            T item = null;

            // Act
            var result = cache.Create(
                item);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var cache = this.CreateCache();
            TKey key = default(TKey);

            // Act
            var result = cache.Delete(
                key);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void Read_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var cache = this.CreateCache();
            TKey key = default(TKey);

            // Act
            var result = cache.Read(
                key);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var cache = this.CreateCache();
            TKey key = default(TKey);
            T item = null;

            // Act
            var result = cache.Update(
                key,
                item);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
    */
}