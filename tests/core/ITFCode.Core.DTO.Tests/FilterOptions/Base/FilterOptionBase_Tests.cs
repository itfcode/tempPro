using AutoFixture;
using ITFCode.Core.DTO.FilterOptions.Base;
using ITFCode.Core.DTO.Tests.Base;

namespace ITFCode.Core.DTO.Tests.FilterOptions.Base
{
    public abstract class FilterOptionBase_Tests<TFilterOption> : DtoClassesBase_Tests where 
        TFilterOption : FilterOption
    {
        [Fact]
        public void Check_TypeName_Test() 
        {
            var valueFilter = _fixture.Create<TFilterOption>();
            Assert.Equal(valueFilter.GetType().Name, valueFilter.TypeFilter);
        }
    }
}