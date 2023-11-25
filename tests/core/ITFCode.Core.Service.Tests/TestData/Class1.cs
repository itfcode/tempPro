namespace ITFCode.Core.Service.Tests.TestData
{
    public class TestEntityClass<TEntity> where TEntity : class
    {
        private readonly object _obj;

        public TestEntityClass(object obj)
        {
            _obj = obj;
        }
    }


    public class TestResolver
    {

        public void Resolve()
        {
            var res = new TestEntityClass<TestSimpleClass>(new { Res = 10 });
        }
    }
}
