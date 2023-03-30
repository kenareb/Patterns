using CachingDemo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CachingDemo.Tests
{
    [TestClass]
    public class CacheTests
    {
        private MockRepository mockRepository;

        private Mock<IRepository<string, string>> repoMock;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            repoMock = this.mockRepository.Create<IRepository<string, string>>();
        }

        private Cache<string, string> CreateCache()
        {
            return new Cache<string, string>(
                repoMock.Object,
                ReadMode.ReadThrough,
                WriteMode.WriteThrough);
        }

        [TestMethod]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var cache = CreateCache();
            string item = "data";

            // Repo.Create must be called once.
            repoMock
                .Setup(r => r.Create(It.IsAny<string>()))
                .Returns("key from repo");

            // Act
            var result = cache.Create(
                item);

            // Assert
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var cache = CreateCache();
            string key = "key";

            // Repo.Delete must be called once.
            repoMock
                .Setup(r => r.Delete(It.IsAny<string>()))
                .Returns(true);

            // Act
            var result = cache.Delete(
                key);

            // Assert
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void Read_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var cache = this.CreateCache();
            string key = "key";

            // Repo.Read must be called once.
            repoMock
                .Setup(r => r.Read(It.IsAny<string>()))
                .Returns("from repo");

            // Act
            var result = cache.Read(
                key);

            // Assert
            Assert.AreEqual("from repo", result);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var cache = this.CreateCache();
            string key = "key";
            string item = "data";

            // Repo.Update must be called once.
            repoMock
                .Setup(r => r.Update(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            // Act
            var result = cache.Update(
                key,
                item);

            // Assert
            Assert.IsTrue(result);
            this.mockRepository.VerifyAll();
        }
    }
}