using AutoFixture;
using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.FilterHandlers;
using ITFCode.Core.Service.FilterHandlers.Base;
using ITFCode.Core.Service.Tests.TestData;
using System.Reflection;

namespace ITFCode.Core.Service.Tests.FilterHandlers
{
    public abstract class BaseRangeFilterHandlerBase_Tests<TRangeFilterHandler, TFilter>
        where TRangeFilterHandler : class
        where TFilter : class
    {
        #region Consts

        protected const int STEP_0 = 0;
        protected const int STEP_1 = 1;
        protected const int STEP_2 = 5;
        protected const int STEP_3 = 50;
        protected const int STEP_4 = 200;
        protected const int STEP_5 = 1000;

        protected const string Property_DateTimeOffset = nameof(BoolValueFilter.Value);

        #endregion

        #region Private & Protected Fields 

        protected readonly Fixture _fixture = new Fixture();

        #endregion

        #region Facts

        [Fact]
        public void Constructor_Throw_If_Parameter_Is_Null()
        {
            TFilter? filter = default;
            var exception = Assert.Throws<TargetInvocationException>(() => Activator.CreateInstance(typeof(TRangeFilterHandler), filter));
            Assert.IsType<ArgumentNullException>(exception.InnerException);
        }

        [Fact]
        public void Parent_Classes_Should_Be_Is_()
        {
            Assert.Equal(typeof(ValueFilterHandler<BoolValueFilter>), typeof(BoolValueFilterHandler).BaseType);
        }

        #endregion

        #region Protected Methods 

        protected ICollection<TestSimpleClass> GenerateSimpleData(int count)
        {
            decimal generateDecimal() => new(new Random().Next() + new Random().NextDouble());
            double generateDouble() => new Random().Next() + new Random().NextDouble();
            float generateFloat() => new Random().Next() + new Random().NextSingle();

            return Enumerable.Range(0, count)
                .Select(x => _fixture.Build<TestSimpleClass>()
                    .With(p => p.FloatProperty, generateFloat())
                    .With(p => p.FloatNullProperty, generateFloat())
                    .With(p => p.DoubleProperty, generateDouble())
                    .With(p => p.DoubleNullProperty, generateDouble())
                    .With(p => p.DecimalProperty, generateDecimal())
                    .With(p => p.DecimalNullProperty, new decimal(new Random().Next(-1000000, 1000000) + new Random().NextDouble()))
                    .Create())
                .ToList();
        }

        protected ICollection<TestComplexClass> GenerateComplexData(int count)
        {
            return Enumerable.Range(0, count)
                .Select(x => _fixture.Build<TestComplexClass>()
                    .Create())
                .ToList();
        }

        #endregion
    }
}