using System.Diagnostics.CodeAnalysis;

namespace ITFCode.Core.Common.Exceptions
{
    public class PropertyNotDefinedException : Exception
    {
        public PropertyNotDefinedException([NotNull] string propertyName) : base($"{propertyName} not defined")
        {
        }
    }
}
