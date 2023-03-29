namespace CachingDemo.Tests
{
    [TestClass]
    public class CacheAsideStrategyTests
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

            cacheMock
                .Setup(c => c.Get(It.IsAny<string>(), null))
                .Returns("from cache");

            // We don't set any expectations for repoMock, so with strict mode, we'll ensure, that
            // the repo is never called.
        }

        private CacheAsideStrategy<string, string> CreateCacheAsideStrategy()
        {
            return new CacheAsideStrategy<string, string>();
        }

        [TestMethod]
        public void Read_Cache_Only()
        {
            // Arrange
            var cacheAsideStrategy = CreateCacheAsideStrategy();
            string key = "key";

            CacheItemPolicy policy = new CacheItemPolicy();

            // Act
            var result = cacheAsideStrategy.Read(
                key,
                cacheMock.Object,
                policy,
                repoMock.Object);

            // Assert
            mockRepository.VerifyAll();
        }
    }
}