namespace CachingDemo.Tests
{
    [TestClass]
    public class WriteThroughStrategyTests
    {
        private MockRepository mockRepository;
        private Mock<ObjectCache> cacheMock;
        private Mock<IRepository<string, string>> repoMock;

        [TestInitialize]
        public void TestInitialize()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
            cacheMock = mockRepository.Create<ObjectCache>();
            repoMock = mockRepository.Create<IRepository<string, string>>();
        }

        private WriteThroughStrategy<string, string> CreateWriteThroughStrategy()
        {
            return new WriteThroughStrategy<string, string>();
        }

        [TestMethod]
        public void Create_Through_Cache_And_Repo()
        {
            // Arrange
            var writeThroughStrategy = CreateWriteThroughStrategy();
            string item = "data";
            CacheItemPolicy policy = new CacheItemPolicy();

            repoMock.Reset();
            cacheMock.Reset();

            // Repo.Create must be called once.
            repoMock
                .Setup(r => r.Create(It.IsAny<string>()))
                .Returns("key from repo");

            // Cache.Add must also be called once to store the data.
            cacheMock
                .Setup(c => c.Add(It.IsAny<CacheItem>(), It.IsAny<CacheItemPolicy>()))
                .Returns(true);

            // Act
            var result = writeThroughStrategy.Create(
                item,
                cacheMock.Object,
                policy,
                repoMock.Object);

            // Assert
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void Delete_Through_Cache_And_Repo()
        {
            // Arrange
            var writeThroughStrategy = CreateWriteThroughStrategy();
            string key = "key";
            CacheItemPolicy policy = new CacheItemPolicy();

            repoMock.Reset();
            cacheMock.Reset();

            // Repo.Create must be called once.
            repoMock
                .Setup(r => r.Delete(It.IsAny<string>()))
                .Returns(true);

            // Cache.Add must also be called once to store the data.
            cacheMock
                .Setup(c => c.Remove(It.IsAny<string>(), null))
                .Returns(true);

            // Act
            var result = writeThroughStrategy.Delete(
                key,
                cacheMock.Object,
                repoMock.Object);

            // Assert
            mockRepository.VerifyAll();
        }

        [TestMethod]
        public void Write_Through_Cache_And_Repo()
        {
            // Arrange
            var writeThroughStrategy = CreateWriteThroughStrategy();
            string key = "key";
            string item = "data";
            CacheItemPolicy policy = new CacheItemPolicy();

            repoMock.Reset();
            cacheMock.Reset();

            // Repo.Create must be called once.
            repoMock
                .Setup(r => r.Update(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            // Cache.Add must also be called once to store the data.
            cacheMock
                .Setup(c => c.Set(It.IsAny<CacheItem>(), It.IsAny<CacheItemPolicy>()));

            // Act
            var result = writeThroughStrategy.Write(
                key,
                item,
                cacheMock.Object,
                policy,
                repoMock.Object);

            // Assert
            mockRepository.VerifyAll();
        }
    }
}