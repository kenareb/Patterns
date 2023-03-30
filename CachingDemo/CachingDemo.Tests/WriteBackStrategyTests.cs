namespace CachingDemo.Tests
{
    [TestClass]
    public class WriteBackStrategyTests
    {
        private MockRepository mockRepository;
        private Mock<ObjectCache> cacheMock;
        private Mock<IRepository<string, string>> repoMock;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            cacheMock = mockRepository.Create<ObjectCache>();
            repoMock = mockRepository.Create<IRepository<string, string>>();
        }

        private WriteBackStrategy<string, string> CreateWriteBackStrategy()
        {
            return new WriteBackStrategy<string, string>();
        }

        [TestMethod]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var writeBackStrategy = this.CreateWriteBackStrategy();
            string item = "data";
            CacheItemPolicy policy = null;

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
            var result = writeBackStrategy.Create(
                item,
                cacheMock.Object,
                policy,
                repoMock.Object);

            // Wait 10 seconds, so that a baclground thread has time to finish.
            Task.Delay(TimeSpan.FromSeconds(10)).GetAwaiter().GetResult();

            // Assert
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var writeBackStrategy = this.CreateWriteBackStrategy();
            string key = "key";
            CacheItemPolicy policy = new CacheItemPolicy();

            repoMock.Reset();
            cacheMock.Reset();

            // Repo.Delete must be called once.
            repoMock
                .Setup(r => r.Delete(It.IsAny<string>()))
                .Returns(true);

            // Cache.Remove must also be called once to store the data.
            cacheMock
                .Setup(c => c.Remove(It.IsAny<string>(), null))
                .Returns(true);

            // Act
            var result = writeBackStrategy.Delete(
                key,
                cacheMock.Object,
                repoMock.Object);

            // Wait 10 seconds, so that a baclground thread has time to finish.
            Task.Delay(TimeSpan.FromSeconds(10)).GetAwaiter().GetResult();

            // Assert
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void Write_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var writeBackStrategy = this.CreateWriteBackStrategy();
            string key = "key";
            string item = "data";
            CacheItemPolicy policy = new CacheItemPolicy();

            repoMock.Reset();
            cacheMock.Reset();

            // Repo.Update must be called once.
            repoMock
                .Setup(r => r.Update(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            // Cache.Set must also be called once to store the data.
            cacheMock
                .Setup(c => c.Set(It.IsAny<CacheItem>(), It.IsAny<CacheItemPolicy>()));

            // Act
            var result = writeBackStrategy.Write(
                key,
                item,
                cacheMock.Object,
                policy,
                repoMock.Object);

            // Wait 10 seconds, so that a baclground thread has time to finish.
            Task.Delay(TimeSpan.FromSeconds(10)).GetAwaiter().GetResult();

            // Assert
            this.mockRepository.VerifyAll();
        }
    }
}