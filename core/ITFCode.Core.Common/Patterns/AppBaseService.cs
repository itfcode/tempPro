using ITFCode.Core.Common.Exceptions;
using Microsoft.Extensions.Logging;

namespace ITFCode.Core.Common.Patterns
{
    public abstract class AppBaseService : DisposableTemplate
    {
        #region Private & Protected Fields 

        private readonly ILogger<AppBaseService> _logger;

        #endregion

        #region Protected Properties 

        protected ILogger<AppBaseService> Logger => _logger ?? throw new PropertyNotDefinedException(nameof(Logger));

        #endregion

        #region Constructors 

        public AppBaseService(ILogger<AppBaseService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #endregion
    }
}