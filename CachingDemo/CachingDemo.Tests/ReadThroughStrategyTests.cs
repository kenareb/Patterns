namespace CachingDemo.Tests
{
    [TestClass]
    public class ReadThroughStrategyTests
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

            // Cache.Get must be called twice: first call returns null, second returns data.
            cacheMock
                .SetupSequence(c => c.Get(It.IsAny<string>(), null))
                .Returns(default(string))
                .Returns("from cache");

            // Cache.Add must also be called nce to store the data.
            cacheMock
                .Setup(c => c.Add(It.IsAny<CacheItem>(), It.IsAny<CacheItemPolicy>()))
                .Returns(true);

            // Repo.Read must be called once after the cache returns a null.
            repoMock
                .Setup(r => r.Read(It.IsAny<string>()))
                .Returns("from repo");
        }

        private ReadThroughStrategy<string, string> CreateReadThroughStrategy()
        {
            return new ReadThroughStrategy<string, string>();
        }

        [TestMethod]
        public void Read_Through_Cache_And_Repo()
        {
            // Arrange
            var readThroughStrategy = CreateReadThroughStrategy();
            string key = "key";
            CacheItemPolicy policy = new CacheItemPolicy();

            // Act
            var result = readThroughStrategy.Read(
                key,
                cacheMock.Object,
                policy,
                repoMock.Object);

            // Assert
            mockRepository.VerifyAll();
        }
    }
}