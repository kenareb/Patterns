namespace CachingDemo.Tests
{
    /*
    [TestClass]
    public class WriteThroughStrategyTests
    {
        private MockRepository mockRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private WriteThroughStrategy CreateWriteThroughStrategy()
        {
            return new WriteThroughStrategy();
        }

        [TestMethod]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var writeThroughStrategy = this.CreateWriteThroughStrategy();
            T item = null;
            ObjectCache cache = null;
            CacheItemPolicy policy = null;
            IRepository repo = null;

            // Act
            var result = writeThroughStrategy.Create(
                item,
                cache,
                policy,
                repo);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var writeThroughStrategy = this.CreateWriteThroughStrategy();
            TKey key = default(TKey);
            ObjectCache cache = null;
            IRepository repo = null;

            // Act
            var result = writeThroughStrategy.Delete(
                key,
                cache,
                repo);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void Write_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var writeThroughStrategy = this.CreateWriteThroughStrategy();
            TKey key = default(TKey);
            T item = null;
            ObjectCache cache = null;
            CacheItemPolicy policy = null;
            IRepository repo = null;

            // Act
            var result = writeThroughStrategy.Write(
                key,
                item,
                cache,
                policy,
                repo);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
    */
}