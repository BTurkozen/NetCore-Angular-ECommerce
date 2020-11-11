using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace API.Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T,bool>> Criteria { get; }
        List<Expression<Func<T,object>>> Includes { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T,object>> OrderByDescending { get; }

        /// <summary>
        /// Ekranda gösterilecek rakam miktarı
        /// </summary>
        int Take { get; }
        /// <summary>
        /// kac ürünü atlıyacağı rakam miktarı
        /// </summary>
        int Skip { get; }
        /// <summary>
        /// Sayfalanma yapılsınmı yapılmasınmı?
        /// </summary>
        bool IsPagingEnabled { get; }
    }
}
