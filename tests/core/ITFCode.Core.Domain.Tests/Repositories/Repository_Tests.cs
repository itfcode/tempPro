using AutoFixture;
using ITFCode.Core.Domain.Repositories.Interfaces;
using ITFCode.Core.Domain.Tests.TestScope;
using Microsoft.EntityFrameworkCore;

namespace ITFCode.Core.Domain.Tests.Repositories
{
    public class Repository_Tests
    {
        #region Private & Protected  

        protected readonly Fixture _fixture = new Fixture();
        protected readonly IEntityRepository<EntityWithSimpleKey> _repoSimpleKey;
        protected readonly IEntityRepository<EntityWithComplexKey> _repoComplexKey;
        //protected readonly IUnitiOfWork<EntityWithComplexKey> _repoComplexKey;
        protected readonly TestDbContext _dbContext;

        #endregion

        #region Constructors 

        public Repository_Tests()
        {
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _dbContext = new TestDbContext(options);
            _repoSimpleKey = new EntityWithSimpleKeyRepository(_dbContext);
            _repoComplexKey = new EntityWithComplexKeyRepository(_dbContext);
        }

        #endregion

        #region Facts

        [Fact]
        public void Constructor_Throw_If_Null_Params()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new EntityWithSimpleKeyRepository(null));
        }

        [Fact]
        public void Get_Throw_If_Null_Param_Test()
        {
            Assert.Throws<ArgumentNullException>(() => _repoSimpleKey.Get(null));
            Assert.Throws<ArgumentNullException>(() => _repoComplexKey.Get(null));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(50)]
        public void Get_By_Key_Test(int count)
        {
            var entities = PopulateEnitiesSingleKey(count);

            foreach (var entity in entities)
            {
                var getted = _repoSimpleKey.Get(entity.Id);
                Assert.Equal(entity.Id, actual: getted.Id);
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(50)]
        public void Get_By_Keys_Test(int count)
        {
            var entities = PopulateEnitiesComplexKey(count);

            foreach (var entity in entities)
            {
                var getted = _repoComplexKey.Get(entity.Key1, entity.Key2);
                Assert.Equal(entity.Key1, actual: getted.Key1);
                Assert.Equal(entity.Key2, actual: getted.Key2);
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(50)]
        public void Find_Test(int count)
        {
            var entities = PopulateEnitiesComplexKey(count);

            foreach (var entity in entities)
            {
                var getted = _repoComplexKey.Find(x => x.Name == entity.Name);
                Assert.NotNull(getted);
                Assert.Equal(entity.Key1, actual: getted.Key1);
                Assert.Equal(entity.Key2, actual: getted.Key2);
            }

            Assert.Null(_repoComplexKey.Find(x => x.Name == Guid.NewGuid().ToString()));
        }

        [Fact]
        public void Find_Throw_If_Null_Param_Test()
        {
            Assert.Throws<ArgumentNullException>(() => _repoSimpleKey.Find(null));
            Assert.Throws<ArgumentNullException>(() => _repoComplexKey.Find(null));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(50)]
        public void Exists_Test(int count)
        {
            var entities = PopulateEnitiesComplexKey(count);

            Assert.True(_repoComplexKey.Exists());

            foreach (var entity in entities)
            {
                Assert.True(_repoComplexKey.Exists(x => x.Name == entity.Name));
            }

            Assert.False(_repoComplexKey.Exists(x => x.Name == Guid.NewGuid().ToString()));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(50)]
        public void Count_Test(int count)
        {
            var entities = PopulateEnitiesComplexKey(count);

            Assert.Equal(count, _repoComplexKey.Count());

            foreach (var entity in entities)
            {
                Assert.Equal(1, _repoComplexKey.Count(x => x.Name == entity.Name));
            }

            Assert.Equal(0, _repoComplexKey.Count(x => x.Name == Guid.NewGuid().ToString()));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(50)]
        public void Add_Test(int count)
        {
            Assert.Equal(0, _repoComplexKey.Count());

            for (int i = 0; i < count; i++)
                _repoSimpleKey.Add(_fixture.Create<EntityWithSimpleKey>());

            Assert.Equal(0, _repoComplexKey.Count());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(50)]
        public void AddRange_Test(int count)
        {
            Assert.Equal(0, _repoComplexKey.Count());

            var entities = Enumerable.Range(0, count)
                .Select(x => _fixture.Create<EntityWithSimpleKey>())
                .ToArray();

            _repoSimpleKey.AddRange(entities);

            Assert.Equal(0, _repoComplexKey.Count());
        }

        #endregion

        #region Async Methods 

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(50)]
        public async Task GetAsync_By_Key_Test(int count)
        {
            var entities = PopulateEnitiesSingleKey(count);

            foreach (var entity in entities)
            {
                var getted = await _repoSimpleKey.GetAsync(entity.Id);
                Assert.NotNull(getted);
                Assert.Equal(entity.Id, actual: getted.Id);
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(50)]
        public async Task GetAsync_By_Keys_Test(int count)
        {
            var entities = PopulateEnitiesComplexKey(count);

            foreach (var entity in entities)
            {
                var getted = await _repoComplexKey.GetAsync(entity.Key1, entity.Key2);
                Assert.NotNull(getted);
                Assert.Equal(entity.Key1, actual: getted.Key1);
                Assert.Equal(entity.Key2, actual: getted.Key2);
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(50)]
        public async Task FindAsync_Test(int count)
        {
            var entities = PopulateEnitiesComplexKey(count);

            foreach (var entity in entities)
            {
                var getted = _repoComplexKey.Find(x => x.Name == entity.Name);
                Assert.NotNull(getted);
                Assert.Equal(entity.Key1, actual: getted.Key1);
                Assert.Equal(entity.Key2, actual: getted.Key2);
            }

            Assert.Null(await _repoComplexKey.FindAsync(x => x.Name == Guid.NewGuid().ToString()));
        }

        [Fact]
        public async Task FindAsync_Throw_If_Null_Param_Test()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _repoSimpleKey.FindAsync(null));
            await Assert.ThrowsAsync<ArgumentNullException>(() => _repoComplexKey.FindAsync(null));
        }

        [Fact]
        public async Task FindAsync_Throw_If_CancelationToken_Test()
        {
            CancellationTokenSource cancellationTokenSource = new(0);

            await Assert.ThrowsAsync<OperationCanceledException>(() => _repoSimpleKey.FindAsync(x => x.Id == 1, cancellationTokenSource.Token));
            await Assert.ThrowsAsync<OperationCanceledException>(() => _repoComplexKey.FindAsync(x => x.Key1 == 1, cancellationTokenSource.Token));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(50)]
        public async Task ExistsAsync_Test(int count)
        {
            var entities = PopulateEnitiesComplexKey(count);

            Assert.True(await _repoComplexKey.ExistsAsync());

            foreach (var entity in entities)
            {
                Assert.True(await _repoComplexKey.ExistsAsync(x => x.Name == entity.Name));
            }

            Assert.False(await _repoComplexKey.ExistsAsync(x => x.Name == Guid.NewGuid().ToString()));
        }

        [Fact]
        public async Task ExistsAsync_Throw_If_CancelationToken_Test()
        {
            CancellationTokenSource cancellationTokenSource = new(0);

            await Assert.ThrowsAsync<OperationCanceledException>(() => _repoSimpleKey.ExistsAsync(cancellationToken: cancellationTokenSource.Token));
            await Assert.ThrowsAsync<OperationCanceledException>(() => _repoSimpleKey.ExistsAsync(cancellationToken: cancellationTokenSource.Token));

            await Assert.ThrowsAsync<OperationCanceledException>(() => _repoComplexKey.ExistsAsync(x => x.Key1 == 1, cancellationTokenSource.Token));
            await Assert.ThrowsAsync<OperationCanceledException>(() => _repoComplexKey.ExistsAsync(x => x.Key1 == 1, cancellationTokenSource.Token));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(50)]
        public async Task CountAsync_Test(int count)
        {
            var entities = PopulateEnitiesComplexKey(count);

            Assert.Equal(count, await _repoComplexKey.CountAsync());

            foreach (var entity in entities)
            {
                Assert.Equal(1, await _repoComplexKey.CountAsync(x => x.Name == entity.Name));
            }

            Assert.Equal(0, await _repoComplexKey.CountAsync(x => x.Name == Guid.NewGuid().ToString()));
        }

        [Fact]
        public async Task CountAsync_Throw_If_CancelationToken_Test()
        {
            CancellationTokenSource cancellationTokenSource = new(0);

            await Assert.ThrowsAsync<OperationCanceledException>(() => _repoSimpleKey.CountAsync(cancellationToken: cancellationTokenSource.Token));
            await Assert.ThrowsAsync<OperationCanceledException>(() => _repoSimpleKey.CountAsync(cancellationToken: cancellationTokenSource.Token));

            await Assert.ThrowsAsync<OperationCanceledException>(() => _repoComplexKey.CountAsync(x => x.Key1 == 1, cancellationTokenSource.Token));
            await Assert.ThrowsAsync<OperationCanceledException>(() => _repoComplexKey.CountAsync(x => x.Key1 == 1, cancellationTokenSource.Token));
        }


        // void Delete(object id);
        // void Delete(TEntity entityToDelete);
        // Task DeleteAsync(object id);


        #endregion

        #region Private Methods 

        private EntityWithSimpleKey[] PopulateEnitiesSingleKey(int count)
        {
            var res = new EntityWithSimpleKey[count];
            for (int i = 0; i < count; i++)
            {
                var entity = _fixture.Create<EntityWithSimpleKey>();
                res[i] = entity;
                _dbContext.TestEntities.Add(entity);
            }

            _dbContext.SaveChanges();

            return res;
        }

        private EntityWithComplexKey[] PopulateEnitiesComplexKey(int count)
        {
            var res = new EntityWithComplexKey[count];
            for (int i = 0; i < count; i++)
            {
                var entity = _fixture.Create<EntityWithComplexKey>();
                res[i] = entity;
                _dbContext.TestEntitiesWithComplexKey.Add(entity);
            }

            _dbContext.SaveChanges();

            return res;
        }

        #endregion
    }
}