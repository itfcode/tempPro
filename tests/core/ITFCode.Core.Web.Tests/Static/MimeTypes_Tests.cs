using ITFCode.Core.Web.Static;

namespace ITFCode.Core.Web.Tests.Static
{
    public class MimeTypes_Tests
    {
        [Fact]
        public void GetByExtension_Test() 
        {
            Assert.Equal(MimeTypes.AAC, MimeTypes.GetByExtension(nameof(MimeTypes.AAC).ToLower()));
            Assert.Equal(MimeTypes.ABW, MimeTypes.GetByExtension(nameof(MimeTypes.ABW).ToLower()));
        }
    }
}
