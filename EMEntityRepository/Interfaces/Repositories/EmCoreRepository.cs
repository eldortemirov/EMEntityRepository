using EMEntityRepository.ResultModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EMEntityRepository.Interfaces.Repositories
{
    /// <summary>
    /// Abstract class with core repositories inherited from the interface / Абстрактный класс с основными репозиториями наследовал от интерфейса 
    /// </summary>
    /// <typeparam name="TEntity">Model type / Тип модели</typeparam>
    /// <typeparam name="TKey">Primary key type / Тип первичного ключа</typeparam>
    /// <typeparam name="TContext">MyDbContext inherited DbContext</typeparam>
    public abstract class EMCoreRepository<TEntity, TKey, TContext> : IEMCoreRepository<TEntity, TKey>
        where TEntity : class, IEMEntity<TKey>
        where TContext : DbContext
    {
        private readonly TContext context;
        private DbSet<TEntity> dbSet;
        public EMCoreRepository(TContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        private IQueryable<TEntity> GetQuery(bool isDelete = false)
        {
            IQueryable<TEntity> query = dbSet;
            query = query.Where(w => w.IsDelete == isDelete);
            return query;
        }

        private IEnumerable<TEntity> GetEnumerable(bool isDelete = false)
        {
            IEnumerable<TEntity> query = dbSet;
            query = query.Where(w => w.IsDelete == isDelete);
            return query;
        }

        /// <summary>
        /// IEnumarable<TEntity> all entries / Все записи IEnumarable<TEntity>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAllAsEnumerable()
        => GetEnumerable();

        /// <summary>
        /// IEnumarable<TEntity> all entries / Все записи IEnumarable<TEntity>
        /// </summary>
        /// <param name="isDelete">null, false, true</param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAllAsEnumerable(bool isDelete = false)
        => GetEnumerable(isDelete);

        ///// <summary>
        ///// IEnumarable<TEntity> all entries / Все записи IEnumarable<TEntity>
        ///// </summary>
        ///// <param name="predicate"></param>
        ///// <param name="isDelete"></param>
        ///// <returns></returns>
        //public IEnumerable<TEntity> GetAllAsEnumerable(Expression<Func<TEntity, bool>> predicate = null, bool isDelete = false)
        //{
        //    IQueryable<TEntity> query = GetQuery(isDelete);

        //    if (predicate != null) query = query.Where(predicate);

        //    return query.ToList();
        //}

        /// <summary>
        /// IEnumarable<TEntity> all entries / Все записи IEnumarable<TEntity>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAllAsEnumerableAsync()
        => await Task.Run(() => GetEnumerable());

        /// <summary>
        /// IEnumarable<TEntity> all entries / Все записи IEnumarable<TEntity>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAllAsEnumerableAsync(bool isDelete = false)
        => await Task.Run(() => GetEnumerable(isDelete));

        ///// <summary>
        ///// IEnumarable<TEntity> all entries / Все записи IEnumarable<TEntity>
        ///// </summary>
        ///// <param name="predicate"></param>
        ///// <param name="isDelete"></param>
        ///// <returns></returns>
        //public async Task<IEnumerable<TEntity>> GetAllAsEnumerableAsync(Expression<Func<TEntity, bool>> predicate = null, bool isDelete = false)
        //{
        //    IQueryable<TEntity> query = GetQuery(isDelete);

        //    if (predicate != null) query = query.Where(predicate);

        //    return await query.ToListAsync();
        //}

        /// <summary>
        /// IAsyncEnumarable<TEntity> all entries / Все записи IAsyncEnumarable<TEntity>
        /// </summary>
        /// <returns></returns>
        public async Task<IAsyncEnumerable<TEntity>> GetAllAsAsyncEnumerableAsync()
        => await Task.Run(() => (GetQuery()).AsAsyncEnumerable());

        /// <summary>
        /// IAsyncEnumarable<TEntity> all entries / Все записи IAsyncEnumarable<TEntity>
        /// </summary>
        /// <param name="isDelete"></param>
        /// <returns></returns>
        public async Task<IAsyncEnumerable<TEntity>> GetAllAsAsyncEnumerableAsync(bool isDelete = false)
        => await Task.Run(() => (GetQuery(isDelete)).AsAsyncEnumerable());

        ///// <summary>
        ///// IAsyncEnumarable<TEntity> all entries / Все записи IAsyncEnumarable<TEntity>
        ///// </summary>
        ///// <param name="predicate"></param>
        ///// <param name="isDelete"></param>
        ///// <returns></returns>
        //public async Task<IAsyncEnumerable<TEntity>> GetAllAsAsyncEnumerableAsync(Expression<Func<TEntity, bool>> predicate = null, bool isDelete = false)
        //{
        //    IQueryable<TEntity> query = GetQuery(isDelete);

        //    if (predicate != null) query = query.Where(predicate);

        //    return await Task.Run(() => query.AsAsyncEnumerable());
        //}

        /// <summary>
        /// IQueryable<TEntity> all entries / Все записи IQueryable<TEntity>
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> GetAllAsQueryable()
            => GetQuery();
        /// <summary>
        /// IQueryable<TEntity> all entries / Все записи IQueryable<TEntity>
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> GetAllAsQueryable(bool isDelete = false)
            => GetQuery(isDelete);

        /// <summary>
        /// IQueryable<TEntity> all entries with predicate / Все записи IQueryable<TEntity> c фильтрами
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="isDelete"></param>
        /// <returns></returns>
        public IQueryable<TEntity> GetAllAsQueryable(Expression<Func<TEntity, bool>> predicate = null, bool isDelete = false)
        {
            IQueryable<TEntity> query = GetQuery(isDelete);

            if (predicate != null) query = query.Where(predicate);

            return query;
        }

        /// <summary>
        /// IQueryable<TEntity> all entries with predicate / Все записи IQueryable<TEntity> c фильтрами
        /// </summary>
        /// <param name="include"></param>
        /// <param name="predicate"></param>
        /// <param name="isDelete"></param>
        /// <returns></returns>
        public IQueryable<TEntity> GetAllAsQueryable(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Expression<Func<TEntity, bool>> predicate = null, bool isDelete = false)
        {
            IQueryable<TEntity> query = GetQuery(isDelete);

            if (predicate != null) query = query.Where(predicate);

            if (include != null) query = include(query);


            return query;
        }

        /// <summary>
        /// IQueryable<TEntity> all entries / Все записи IQueryable<TEntity>
        /// </summary>
        /// <returns></returns>
        public async Task<IQueryable<TEntity>> GetAllAsQueryableAsync()
            => await Task.Run(() => GetQuery());

        /// <summary>
        /// Async IQueryable<TEntity> all entries / Все записи асинхронно IQueryable<TEntity>
        /// </summary>
        /// <param name="isDelete"></param>
        /// <returns></returns>
        public async Task<IQueryable<TEntity>> GetAllAsQueryableAsync(bool isDelete = false)
            => await Task.Run(() => GetQuery(isDelete));


        /// <summary>
        /// IQueryableAsync<TEntity> all entries with predicate / Все записи IQueryable<TEntity> c фильтрами
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="isDelete"></param>
        /// <returns></returns>
        public async Task<IQueryable<TEntity>> GetAllAsQueryableAsync(Expression<Func<TEntity, bool>> predicate = null, bool isDelete = false)
        {
            IQueryable<TEntity> query = GetQuery(isDelete);

            if (predicate != null) query = query.Where(predicate);

            return await Task.Run(() => query);
        }

        /// <summary>
        /// IQueryableAsync<TEntity> all entries with predicate / Все записи IQueryable<TEntity> c фильтрами
        /// </summary>
        /// <param name="include"></param>
        /// <param name="predicate"></param>
        /// <param name="isDelete"></param>
        /// <returns></returns>
        public async Task<IQueryable<TEntity>> GetAllAsQueryableAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Expression<Func<TEntity, bool>> predicate = null, bool isDelete = false)
        {
            IQueryable<TEntity> query = GetQuery(isDelete);

            if (predicate != null) query = query.Where(predicate);

            if (include != null) query = include(query);


            return await Task.Run(() => query);
        }

        /// <summary>
        /// Get result from database with pagination (pageIndex = 0; pageSize = 10; isDelete = false) / Получить результат из базы данных с нумерацией страниц (pageIndex = 0; pageSize = 10; isDelete = false)
        /// </summary>
        /// <param name="isDelete"></param>
        /// <returns></returns>
        public PagedResult<TEntity> ToPagedList()
        {
            int pageIndex = 0;
            int pageSize = 10;
            IQueryable<TEntity> query = GetQuery();

            var total = query.Count();
            var itemIndex = pageIndex * pageSize;
            var entityList = query.Skip(itemIndex).Take(10).ToList();

            return new PagedResult<TEntity> { Data = entityList, PageIndex = pageIndex, PageSize = pageSize, Total = total };
        }

        /// <summary>
        /// Get async result from database with pagination (pageIndex = 0; pageSize = 10) / Получить результат асинхронно из базы данных с нумерацией страниц (pageIndex = 0; pageSize = 10)
        /// </summary>
        /// <param name="isDelete"></param>
        /// <returns></returns>
        public PagedResult<TEntity> ToPagedList(bool isDelete = false)
        {
            int pageIndex = 0;
            int pageSize = 10;
            IQueryable<TEntity> query = GetQuery(isDelete);

            var total = query.Count();
            var itemIndex = pageIndex * pageSize;
            var entityList = query.Skip(itemIndex).Take(10).ToList();

            return new PagedResult<TEntity> { Data = entityList, PageIndex = pageIndex, PageSize = pageSize, Total = total };
        }

        /// <summary>
        /// Get result from database with pagination / Получить результат из базы данных с нумерацией страниц
        /// </summary>
        /// <param name="isDelete"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagedResult<TEntity> ToPagedList(int pageIndex = 0, int pageSize = 10, bool isDelete = false)
        {
            IQueryable<TEntity> query = GetQuery(isDelete);

            var total = query.Count();
            var itemIndex = pageIndex * pageSize;
            var entityList = query.Skip(itemIndex).Take(pageSize).ToList();

            return new PagedResult<TEntity> { Data = entityList, PageIndex = pageIndex, PageSize = pageSize, Total = total };
        }

        /// <summary>
        /// Get async result from database with pagination (pageIndex = 0; pageSize = 10; isDelete = false) / Получить результат асинхронно из базы данных с нумерацией страниц (pageIndex = 0; pageSize = 10; isDelete = false)
        /// </summary>
        /// <returns></returns>
        public async Task<PagedResult<TEntity>> ToPagedListAsync()
        {
            int pageIndex = 0;
            int pageSize = 10;
            IQueryable<TEntity> query = GetQuery();

            var total = query.Count();
            var itemIndex = pageIndex * pageSize;
            var entityList = await query.Skip(itemIndex).Take(10).ToListAsync();

            return new PagedResult<TEntity> { Data = entityList, PageIndex = pageIndex, PageSize = pageSize, Total = total };
        }

        /// <summary>
        /// Get async result from database with pagination (pageIndex = 0; pageSize = 10) / Получить результат асинхронно из базы данных с нумерацией страниц (pageIndex = 0; pageSize = 10)
        /// </summary>
        /// <param name="isDelete"></param>
        /// <returns></returns>
        public async Task<PagedResult<TEntity>> ToPagedListAsync(bool isDelete = false)
        {
            int pageIndex = 0;
            int pageSize = 10;
            IQueryable<TEntity> query = GetQuery(isDelete);

            var total = query.Count();
            var itemIndex = pageIndex * pageSize;
            var entityList = await query.Skip(itemIndex).Take(10).ToListAsync();

            return new PagedResult<TEntity> { Data = entityList, PageIndex = pageIndex, PageSize = pageSize, Total = total };
        }

        /// <summary>
        /// Get result from database with pagination / Получить результат из базы данных с нумерацией страниц
        /// </summary>
        /// <param name="isDelete"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<PagedResult<TEntity>> ToPagedListAsync(int pageIndex = 0, int pageSize = 10, bool isDelete = false)
        {
            IQueryable<TEntity> query = GetQuery(isDelete);

            var total = query.Count();
            var itemIndex = pageIndex * pageSize;
            var entityList = await query.Skip(itemIndex).Take(pageSize).ToListAsync();

            return new PagedResult<TEntity> { Data = entityList, PageIndex = pageIndex, PageSize = pageSize, Total = total };
        }

        /// <summary>
        /// Get result from database with pagination / Получить результат из базы данных с нумерацией страниц
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="isDelete"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagedResult<TEntity> ToPagedList(Expression<Func<TEntity, bool>> predicate = null, int pageIndex = 0, int pageSize = 10, bool isDelete = false)
        {
            IQueryable<TEntity> query = GetQuery(isDelete);
            if (predicate != null) query = query.Where(predicate);

            var total = query.Count();
            var itemIndex = pageIndex * pageSize;
            var entityList = query.Skip(itemIndex).Take(pageSize).ToList();

            return new PagedResult<TEntity> { Data = entityList, PageIndex = pageIndex, PageSize = pageSize, Total = total };
        }

        /// <summary>
        /// Get result from database with pagination / Получить результат из базы данных с нумерацией страниц
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="isDelete"></param>
        /// <returns></returns>
        public async Task<PagedResult<TEntity>> ToPagedListAsync(Expression<Func<TEntity, bool>> predicate = null, int pageIndex = 0, int pageSize = 10, bool isDelete = false)
        {
            IQueryable<TEntity> query = GetQuery(isDelete);
            if (predicate != null) query = query.Where(predicate);

            var total = query.Count();
            var itemIndex = pageIndex * pageSize;
            var entityList = await query.Skip(itemIndex).Take(pageSize).ToListAsync();

            return new PagedResult<TEntity> { Data = entityList, PageIndex = pageIndex, PageSize = pageSize, Total = total };
        }

        /// <summary>
        /// Add TEntity to table / Добавить TEntity запись в таблицу
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity Add(TEntity entity)
        {
            SetCreateDate(entity);
            dbSet.Add(entity);
            context.SaveChanges();
            return entity;
        }

        /// <summary>
        /// AddAsync TEntity to table / Добавить асинхронно TEntity запись в таблицу
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            SetCreateDate(entity);
            await dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// AddRange List<TEntity> to table / Добавить лист List<TEntity> записи в таблицу
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public List<TEntity> AddRange(List<TEntity> entities)
        {
            entities.ForEach(entity => SetCreateDate(entity));
            dbSet.AddRange(entities);
            context.SaveChanges();
            return entities;
        }

        /// <summary>
        /// AddRangeAsync List<TEntity> to table / Добавить лист асинхронно List<TEntity> записи в таблицу
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> AddRangeAsync(List<TEntity> entities)
        {
            entities.ForEach(entity => SetCreateDate(entity));
            await dbSet.AddRangeAsync(entities);
            await context.SaveChangesAsync();
            return entities;
        }

        /// <summary>
        /// Update TEntity to table / Изменить TEntity запись в таблицу
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity Update(TEntity entity)
        {
            SetUpdataDate(entity);
            context.Entry(entity).State = EntityState.Modified;
            dbSet.Update(entity);
            context.SaveChanges();
            return entity;
        }

        /// <summary>
        /// UpdateAsync TEntity to table / Изменить асинхронно TEntity запись в таблицу
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            SetUpdataDate(entity);
            context.Entry(entity).State = EntityState.Modified;
            dbSet.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// UpdateRange List<TEntity> to table / Изменить List<TEntity> записи в таблицу
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public List<TEntity> UpdateRange(List<TEntity> entities)
        {
            entities.ForEach(f => SetUpdataDate(f));
            dbSet.UpdateRange(entities);
            context.SaveChanges();
            return entities;
        }

        /// <summary>
        /// UpdateRangeAsync List<TEntity> to table / Изменить асинхронно List<TEntity> записи в таблицу
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entities)
        {
            entities.ForEach(f => SetUpdataDate(f));
            dbSet.UpdateRange(entities);
            await context.SaveChangesAsync();
            return entities;
        }

        /// <summary>
        /// Delete Id from table / Удалить Id запись из таблицы
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(TKey id)
        {
            var entity = dbSet.Find(id);
            if (entity == null)
                return false;

            if (entity.IsDelete)
                return false;

            SetIsDelete(entity);
            dbSet.Update(entity);

            context.SaveChanges();

            return true;
        }

        /// <summary>
        /// DeleteAsync Id from table / Удалить асинхронно Id запись из таблицы
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(TKey id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity == null)
                return false;

            if (entity.IsDelete)
                return false;

            SetIsDelete(entity);
            dbSet.Update(entity);

            await context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Delete TEntity from table / Удалить TEntity запись из таблицы
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(TEntity entity)
        {
            if (entity == null)
                return false;

            if (entity.IsDelete)
                return false;

            SetIsDelete(entity);
            dbSet.Update(entity);

            context.SaveChanges();

            return true;
        }

        /// <summary>
        /// DeleteAsync TEntity from table / Удалить асинхронно TEntity запись из таблицы
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(TEntity entity)
        {
            if (entity == null)
                return false;

            if (entity.IsDelete)
                return false;

            SetIsDelete(entity);
            dbSet.Update(entity);

            await context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// DeleteRange List<TEntity> from table / Удалить список List<TEntity> записи из таблицы
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public bool DeleteRange(List<TEntity> entities)
        {
            if (entities.Count == 0)
                return false;

            entities.ForEach(f => SetIsDelete(f));
            dbSet.UpdateRange(entities);

            context.SaveChanges();

            return true;
        }

        /// <summary>
        /// DeleteRangeAsync List<TEntity> from table / Удалить асинхронно список List<TEntity> записи из таблицы
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task<bool> DeleteRangeAsync(List<TEntity> entities)
        {
            if (entities.Count == 0)
                return false;

            entities.ForEach(f => SetIsDelete(f));
            dbSet.UpdateRange(entities);

            await context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// DeleteRange List<TKey> from table / Удалить список List<TKey> записи из таблицы
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public bool DeleteRange(List<TKey> idList)
        {
            if (idList.Count == 0)
                return false;

            var entities = dbSet.Where(w => idList.Contains(w.Id)).ToList();
            if (entities.Count == 0)
                return false;

            entities.ForEach(f => SetIsDelete(f));
            dbSet.UpdateRange(entities);

            context.SaveChanges();

            return true;
        }

        /// <summary>
        /// DeleteRangeAsync List<TKey> from table / Удалить асинхронно список List<TKey> записи из таблицы
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public async Task<bool> DeleteRangeAsync(List<TKey> idList)
        {
            if (idList.Count == 0)
                return false;

            var entities = await dbSet.Where(w => !w.IsDelete && idList.Contains(w.Id)).ToListAsync();
            if (entities.Count == 0)
                return false;

            entities.ForEach(f => SetIsDelete(f));

            dbSet.UpdateRange(entities);
            await context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Gets the first or default entity based / Получает первый объект или объект по умолчанию
        /// </summary>
        /// <returns></returns>
        public TEntity GetFirstOrDefault() => GetQuery().FirstOrDefault();

        /// <summary>
        /// Gets the first or default entity based / Получает первый объект или объект по умолчанию
        /// </summary>
        /// <returns></returns>
        public TResult GetFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> selector) => GetQuery().Select(selector).FirstOrDefault();
        
        /// <summary>
        /// Gets the first or default entity based / Получает первый объект или объект по умолчанию
        /// </summary>
        /// <returns></returns>
        public async Task<TEntity> GetFirstOrDefaultAsync() => await GetQuery().FirstOrDefaultAsync();

        /// <summary>
        /// Gets the first or default entity based / Получает первый объект или объект по умолчанию
        /// </summary>
        /// <param name="selector">The selector for projection / Селектор для проекции</param>
        /// <returns></returns>
        public async Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector) => await GetQuery().Select(selector).FirstOrDefaultAsync();

        /// <summary>
        /// Gets the first or default entity based on a predicate / Получает первый объект или объект по умолчанию на основе фильтра
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition / Функция для проверки каждого элемента на условие</param>
        /// <returns></returns>
        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> query = GetQuery();

            if (predicate != null)
                query = query.Where(predicate);

            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets the first or default entity based on a predicate / Получает первый объект или объект по умолчанию на основе фильтра
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition / Функция для проверки каждого элемента на условие</param>
        /// <returns></returns>
        public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> query = GetQuery();

            if (predicate != null)
                query = query.Where(predicate);

            return await query.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets the first or default entity based on a predicate / Получает первый объект или объект по умолчанию на основе фильтра
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition / Функция для проверки каждого элемента на условие</param>
        /// <param name="include">A function to include navigation properties / Функция для включения свойств навигации</param>
        /// <returns></returns>
        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate = null,
                                                  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = GetQuery();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);


            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets the first or default entity based on a predicate / Получает первый объект или объект по умолчанию на основе фильтра
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition / Функция для проверки каждого элемента на условие</param>
        /// <param name="include">A function to include navigation properties / Функция для включения свойств навигации</param>
        /// <returns></returns>
        public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null,
                                                  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = GetQuery();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);


            return await query.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets the first or default entity based on a predicate / Получает первый объект или объект по умолчанию на основе фильтра
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition / Функция для проверки каждого элемента на условие</param>
        /// <param name="orderBy">A function to order elements / Функция для сортировки элементов</param>
        /// <param name="include">A function to include navigation properties / Функция для включения свойств навигации</param>
        /// <returns></returns>
        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate = null,
                                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = GetQuery();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                return orderBy(query).FirstOrDefault();

            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets the first or default entity based on a predicate / Получает первый объект или объект по умолчанию на основе фильтра
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition / Функция для проверки каждого элемента на условие</param>
        /// <param name="orderBy">A function to order elements / Функция для сортировки элементов</param>
        /// <param name="include">A function to include navigation properties / Функция для включения свойств навигации</param>
        /// <returns></returns>
        public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null,
                                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = GetQuery();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).FirstOrDefaultAsync();

            return await query.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets the first or default entity based on a predicate / Получает первый объект или объект по умолчанию на основе фильтра
        /// </summary>
        /// <param name="selector">The selector for projection / Селектор для проекции</param>
        /// <param name="predicate">A function to test each element for a condition / Функция для проверки каждого элемента на условие</param>
        /// <param name="orderBy">A function to order elements / Функция для сортировки элементов</param>
        /// <param name="include">A function to include navigation properties / Функция для включения свойств навигации</param>
        /// <returns></returns>
        public TResult GetFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> selector,
                                                  Expression<Func<TEntity, bool>> predicate = null,
                                                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = GetQuery();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                return orderBy(query).Select(selector).FirstOrDefault();

            return query.Select(selector).FirstOrDefault();
        }

        /// <summary>
        /// Gets the first or default asynchronously entity based on a predicate  / Получает первый или заданный по умолчанию асинхронный объект на основе фильтра
        /// </summary>
        /// <param name="selector">The selector for projection / Селектор для проекции</param>
        /// <param name="predicate">A function to test each element for a condition / Функция для проверки каждого элемента на условие</param>
        /// <param name="orderBy">A function to order elements / Функция для сортировки элементов</param>
        /// <param name="include">A function to include navigation properties / Функция для включения свойств навигации</param>
        /// <returns></returns>
        public async Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
                                                                    Expression<Func<TEntity, bool>> predicate = null,
                                                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                                    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = GetQuery();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = orderBy(query);

            if (orderBy != null)
                return await orderBy(query).Select(selector).FirstOrDefaultAsync();

            return await query.Select(selector).FirstOrDefaultAsync();
        }

        private void SetCreateDate(TEntity entity)
        {
            if (entity.Created == null)
                entity.Created = entity.Updated = DateTime.Now;
            else
                entity.Updated = entity.Created;
        }
        private void SetUpdataDate(TEntity entity)
        {
            entity.Updated = DateTime.Now;
        }
        private void SetIsDelete(TEntity entity)
        {
            entity.IsDelete = true;
            entity.Deleted = DateTime.Now;
        }
    }
}
