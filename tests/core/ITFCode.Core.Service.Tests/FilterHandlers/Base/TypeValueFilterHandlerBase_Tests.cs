﻿using AutoFixture;
using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.FilterHandlers;
using ITFCode.Core.Service.FilterHandlers.Base;
using ITFCode.Core.Service.Tests.TestData;
using System;
using System.Reflection;

namespace ITFCode.Core.Service.Tests.FilterHandlers
{
    public abstract class BaseValueFilterHandlerBase_Tests<TValueFilterHandler, TFilter>
        where TValueFilterHandler : class
        where TFilter : class
    {
        #region Consts

        protected const int STEP_1 = 5;
        protected const int STEP_2 = 50;
        protected const int STEP_3 = 200;
        protected const int STEP_4 = 1000;

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
            var exception = Assert.Throws<TargetInvocationException>(() => Activator.CreateInstance(typeof(TValueFilterHandler), filter));
            Assert.IsType<ArgumentNullException>(exception.InnerException);
        }

        [Fact]
        public void Parent_Classes_Should_Be_Is_()
        {
            Assert.Equal(typeof(ValueFilterHandler<BoolValueFilter>), typeof(BoolValueFilterHandler).BaseType);
        }

        #endregion

        #region Protected Methods 

        protected ICollection<TestClass> GenerateData(int count)
        {
            decimal generateDecimal() => new(new Random().Next() + new Random().NextDouble());
            double generateDouble() => new Random().Next() + new Random().NextDouble();
            float generateFloat() => new Random().Next() + new Random().NextSingle();

            return Enumerable.Range(0, count)
                .Select(x => _fixture.Build<TestClass>()
                    .With(p => p.FloatProperty, generateFloat())
                    .With(p => p.FloatNullProperty, generateFloat())
                    .With(p => p.DoubleProperty, generateDouble())
                    .With(p => p.DoubleNullProperty, generateDouble())
                    .With(p => p.DecimalProperty, generateDecimal())
                    .With(p => p.DecimalNullProperty, new decimal(new Random().Next(-1000000, 1000000) + new Random().NextDouble()))
                    .Create())
                .ToList();
        }

        #endregion
    }
}