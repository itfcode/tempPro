﻿using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.FilterHandlers.Base;
using System.Linq.Expressions;

namespace ITFCode.Core.Service.FilterHandlers
{
    public class BoolValueFilterHandler : ValueFilterHandler<BoolValueFilter>
    {
        #region Constructions

        public BoolValueFilterHandler(BoolValueFilter filter) : base(filter) { }

        #endregion

        #region Public Methods 

        public override Expression<Func<TEntity, bool>> Handle<TEntity>()
        {
            return HandleValue<TEntity, bool>();
        }

        #endregion
    }

}