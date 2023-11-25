using ITFCode.Core.Domain.Entities.Base.Interface;
using System.Reflection;

namespace ITFCode.Core.Domain.Tests
{
    public class Simple_Tests
    {
        [Fact]
        public void All_Enitity_Classes_Should_Be_Inheratnced_From_IEntity()
        {
            var assembly = Assembly.GetAssembly(typeof(IEntity));
            Assert.NotNull(assembly);

            var classes = assembly.GetTypes()
                .Where(x => x.FullName != null && x.FullName.StartsWith("ITFCode.Core.Domain.Entities"))
                .Where(x => x.IsClass)
                .ToList();

            Assert.NotEmpty(classes);
            Assert.True(classes.All(x => x.GetInterface(nameof(IEntity)) is not null));
        }
    }
}