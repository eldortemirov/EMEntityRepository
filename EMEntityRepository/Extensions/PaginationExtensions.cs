using EMEntityRepository.ResultModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMEntityRepository.Extensions
{
    public static class PaginationExtensions
    {
        /// <summary>
        /// Get result from IEnumerable<IEntity> list with pagination / Получить результат из списка IEnumerable<IEntity> с нумерацией страниц
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PagedResult<TEntity> ToPagedList<TEntity>(this IEnumerable<TEntity> data, int pageIndex = 0, int pageSize = 10) where TEntity : class
        {
            var total = data.Count();
            var itemIndex = pageIndex * pageSize;
            var entityList = data.Skip(itemIndex).Take(pageSize).ToList();

            return new PagedResult<TEntity> { Data = entityList, PageIndex = pageIndex, PageSize = pageSize, Total = total };
        }

        /// <summary>
        /// Get result from IQueryable<IEntity> list with pagination / Получить результат из списка IQueryable<IEntity> с нумерацией страниц
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PagedResult<TEntity> ToPagedList<TEntity>(this IQueryable<TEntity> data, int pageIndex = 0, int pageSize = 10) where TEntity : class
        {
            var total = data.Count();
            var itemIndex = pageIndex * pageSize;
            var entityList = data.Skip(itemIndex).Take(pageSize).ToList();

            return new PagedResult<TEntity> { Data = entityList, PageIndex = pageIndex, PageSize = pageSize, Total = total };
        }

        /// <summary>
        /// Get async result from IQueryable<IEntity> list with pagination / Получить результат всинхронно из списка IQueryable<IEntity> с нумерацией страниц
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<PagedResult<TEntity>> ToPagedListAsync<TEntity>(this IQueryable<TEntity> data, int pageIndex = 0, int pageSize = 10) where TEntity : class
        {
            var total = data.Count();
            var itemIndex = pageIndex * pageSize;
            var entityList = await data.Skip(itemIndex).Take(pageSize).ToListAsync();

            return new PagedResult<TEntity> { Data = entityList, PageIndex = pageIndex, PageSize = pageSize, Total = total };
        }
    }
}
