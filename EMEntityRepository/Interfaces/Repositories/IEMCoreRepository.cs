using EMEntityRepository.ResultModels;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EMEntityRepository.Interfaces.Repositories
{
    /// <summary>
    /// Interface with base events. (Contains all methods for performing basic database functions).
    /// Интерфейс с базовыми событиями. (Содержит все методы для выполнения основных функций базы данных).
    /// <list type="bullet">
    /// <item>
    /// <term><c>Add</c></term>
    /// <description>Add TEntity to table - Добавить TEntity запись в таблицу</description>
    /// </item>
    /// <item>
    /// <term><c>AddAsync</c></term>
    /// <description>Add asynchronously TEntity to table - Добавить асинхронно TEntity запись в таблицу</description>
    /// </item>
    /// <item>
    /// <term><c>Update</c></term>
    /// <description>Update TEntity to table - Изменить TEntity запись в таблицу</description>
    /// </item>
    /// <item>
    /// <term><c>UpdateAsync</c></term>
    /// <description>Update asynchronously TEntity to table - Изменить асинхронно TEntity запись в таблицу</description>
    /// </item>
    /// <item>
    /// <term><c>Delete</c></term>
    /// <description>Delete TEntity to table - Удалить TEntity запись из таблицы</description>
    /// </item>
    /// <item>
    /// <term><c>DeleteAsync</c></term>
    /// <description>Delete asynchronously TEntity to table - Удалить асинхронно TEntity запись из таблицы</description>
    /// </item>
    /// <item>
    /// <term><c>GetAllAsEnumerable</c></term>
    /// <description>Get all entries - Получить все записи. (IEnumarable)</description>
    /// </item>
    /// <item>
    /// <term><c>GetAllAsEnumerableAsync</c></term>
    /// <description>Get asynchronously all entries - Получить все записи асинхронно. (IEnumarable)</description>
    /// </item>
    /// <item>
    /// <term><c>GetAllAsQueryable</c></term>
    /// <description>Get all queries - Получить все запросы. (IQueryable)</description>
    /// </item>
    /// <item>
    /// <term><c>GetAllAsQueryableAsync</c></term>
    /// <description>Get asynchronously all queries - Получить все запросы асинхронно. (IQueryable)</description>
    /// </item>
    /// <item>
    /// <term><c>GetAllAsAsyncEnumerableAsync</c></term>
    /// <description>Get asynchronously all entries - Получить все записи асинхронно. (IAsyncEnumarable)</description>
    /// </item>
    /// <item>
    /// <term><c>ToPagedList</c></term>
    /// <description>Get result from database with pagination - Получить результат из базы данных с нумерацией страниц. (pageIndex = 0; pageSize = 10; isDelete = false)</description>
    /// </item>
    /// <item>
    /// <term><c>ToPagedListAsync</c></term>
    /// <description>Get asynchronously result from database with pagination - Получить результат асинхронно из базы данных с нумерацией страниц. (pageIndex = 0; pageSize = 10; isDelete = false)</description>
    /// </item>
    /// </list>
    /// </summary>
    public interface IEMCoreRepository<TEntity, TKey> where TEntity : class, IEMEntity<TKey>
    {
        /// <summary>
        /// Get all entries, that property IsDelete = false (IEnumarable<TEntity>) / Получить все записи, где свойство IsDelete = false (IEnumarable<TEntity>)
        /// </summary>
        /// <returns>Get all entries, that property IsDelete = false (IEnumarable<TEntity>) / Получить все записи, где свойство IsDelete = false (IEnumarable<TEntity>)</returns>
        IEnumerable<TEntity> GetAllAsEnumerable();

        /// <summary>
        /// Get all entries, by param IsDelete (IEnumarable<TEntity>) / Получить все записи по параметру IsDelete (IEnumarable <TEntity>)
        /// </summary>
        /// <param name="isDelete">Статус удаления записи. (false = не удаленная запись, true = удаленная запись). По умолчанию false</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAllAsEnumerable(bool isDelete = false);

        /// <summary>
        /// Get asynchronously all entries, that property IsDelete = false (IEnumarable<TEntity>) / Получить асинхронно все записи, где свойство IsDelete = false (IEnumarable<TEntity>)
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsEnumerableAsync();

        /// <summary>
        /// Get asynchronously all entries, by param IsDelete (IEnumarable<TEntity>) / Получить асинхронно все записи по параметру IsDelete (IEnumarable <TEntity>)
        /// </summary>
        /// <param name="isDelete">Статус удаления записи. (false = не удаленная запись, true = удаленная запись). По умолчанию false</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsEnumerableAsync(bool isDelete = false);


        Task<IEnumerable<TEntity>> GetAllAsEnumerableAsync(Expression<Func<TEntity, bool>> predicate = null, bool isDelete = false);


        Task<IEnumerable<TEntity>> GetAllAsEnumerableAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Expression<Func<TEntity, bool>> predicate = null, bool isDelete = false);

        /// <summary>
        /// Get asynchronously all entries, that property IsDelete = false (IAsyncEnumerable<TEntity>) / Получить асинхронно все записи, где свойство IsDelete = false (IAsyncEnumerable<TEntity>)
        /// </summary>
        /// <returns></returns>
        Task<IAsyncEnumerable<TEntity>> GetAllAsAsyncEnumerableAsync();

        /// <summary>
        /// Get asynchronously all entries, by param IsDelete (IAsyncEnumerable<TEntity>) / Получить асинхронно все записи по параметру IsDelete (IAsyncEnumerable <TEntity>)
        /// </summary>
        /// <param name="isDelete">Статус удаления записи. (false = не удаленная запись, true = удаленная запись). По умолчанию false</param>
        /// <returns></returns>
        Task<IAsyncEnumerable<TEntity>> GetAllAsAsyncEnumerableAsync(bool isDelete = false);

        /// <summary>
        /// Get all queries, that property IsDelete = false (IQueryable<TEntity>) / Получить все запросы, где свойство IsDelete = false (IQueryable<TEntity>)
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAllAsQueryable();

        /// <summary>
        /// Get asynchronously all queries, by param IsDelete (IQueryable<TEntity>) / Получить асинхронно все запросы по параметру IsDelete (IQueryable <TEntity>)
        /// </summary>
        /// <param name="isDelete">Статус удаления записи. (false = не удаленная запись, true = удаленная запись). По умолчанию false</param>
        /// <returns></returns>
        IQueryable<TEntity> GetAllAsQueryable(bool isDelete = false);

        /// <summary>
        /// Get asynchronously all queries, by params Predicate, IsDelete (IQueryable<TEntity>) / Получить асинхронно все запросы по параметру Predicate, IsDelete (IQueryable <TEntity>)
        /// </summary>
        /// <param name="predicate">Функция для проверки каждого элемента на условие</param>
        /// <param name="isDelete">Статус удаления записи. (false = не удаленная запись, true = удаленная запись). По умолчанию false</param>
        /// <returns></returns>
        IQueryable<TEntity> GetAllAsQueryable(Expression<Func<TEntity, bool>> predicate = null, bool isDelete = false);

        /// <summary>
        /// Get asynchronously all queries, by params Predicate, Include, IsDelete (IQueryable<TEntity>) / Получить асинхронно все запросы по параметру Predicate, Include, IsDelete (IQueryable <TEntity>)
        /// </summary>
        /// <param name="include">Функция для включения свойств навигации</param>
        /// <param name="predicate">Функция для проверки каждого элемента на условие</param>
        /// <param name="isDelete">Статус удаления записи. (false = не удаленная запись, true = удаленная запись). По умолчанию false</param>
        /// <returns></returns>
        IQueryable<TEntity> GetAllAsQueryable(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Expression<Func<TEntity, bool>> predicate = null, bool isDelete = false);

        /// <summary>
        /// Get asynchronously all queries, that property IsDelete = false (IQueryableAsync<TEntity>) / Получить асинхронно все запросы, где свойство IsDelete = false (IQueryableAsync<TEntity>)
        /// </summary>
        /// <returns></returns>
        Task<IQueryable<TEntity>> GetAllAsQueryableAsync();

        /// <summary>
        /// Get asynchronously all queries, by param IsDelete (IQueryableAsync<TEntity>) / Получить асинхронно все запросы по параметру IsDelete (IQueryableAsync<TEntity>) 
        /// </summary>
        /// <returns></returns>
        Task<IQueryable<TEntity>> GetAllAsQueryableAsync(bool isDelete = false);

        /// <summary>
        /// Get asynchronously all queries, by params Predicate, IsDelete (IQueryableAsync<TEntity>) / Получить асинхронно все запросы по параметру Predicate, IsDelete (IQueryableAsync<TEntity>)
        /// </summary>
        /// <param name="predicate">Функция для проверки каждого элемента на условие</param>
        /// <param name="isDelete">Статус удаления записи. (false = не удаленная запись, true = удаленная запись). По умолчанию false</param>
        /// <returns></returns>
        Task<IQueryable<TEntity>> GetAllAsQueryableAsync(Expression<Func<TEntity, bool>> predicate = null, bool isDelete = false);

        /// <summary>
        /// Get asynchronously all queries, by params Include, Predicate, IsDelete (IQueryableAsync<TEntity>) / Получить асинхронно все запросы по параметру Include, Predicate, IsDelete (IQueryableAsync<TEntity>)
        /// </summary>
        /// <param name="include">Функция для включения свойств навигации</param>
        /// <param name="predicate">Функция для проверки каждого элемента на условие</param>
        /// <param name="isDelete">Статус удаления записи. (false = не удаленная запись, true = удаленная запись). По умолчанию false</param>
        /// <returns></returns>
        Task<IQueryable<TEntity>> GetAllAsQueryableAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Expression < Func<TEntity, bool>> predicate = null, bool isDelete = false);

        /// <summary>
        /// Get result from database with pagination (pageIndex = 0; pageSize = 10; isDelete = false) / Получить результат из базы данных с нумерацией страниц (pageIndex = 0; pageSize = 10; isDelete = false)
        /// </summary>
        /// <returns></returns>
        PagedResult<TEntity> ToPagedList();

        /// <summary>
        /// Get result from database with pagination (pageIndex = 0; pageSize = 10) / Получить результат из базы данных с нумерацией страниц (pageIndex = 0; pageSize = 10)
        /// </summary>
        /// <param name="isDelete">Статус удаления записи. (false = не удаленная запись, true = удаленная запись). По умолчанию false</param>
        /// <returns></returns>
        PagedResult<TEntity> ToPagedList(bool isDelete = false);

        /// <summary>
        /// Get result from database with pagination / Получить результат из базы данных с нумерацией страниц
        /// </summary>
        /// <param name="pageIndex">page index. default 0 / Индекс страницы. По умолчанию 0</param>
        /// <param name="pageSize">get rows count in request. default 10 / получаемые кол-во записи по запросу. По умолчанию 0</param>
        /// <param name="isDelete">>Статус удаления записи. (false = не удаленная запись, true = удаленная запись). По умолчанию false</param>
        /// <returns></returns>
        PagedResult<TEntity> ToPagedList(int pageIndex = 0, int pageSize = 10, bool isDelete = false);

        /// <summary>
        /// Get async result from database with pagination (pageIndex = 0; pageSize = 10; isDelete = false) / Получить результат асинхронно из базы данных с нумерацией страниц (pageIndex = 0; pageSize = 10; isDelete = false)
        /// </summary>
        /// <returns></returns>
        Task<PagedResult<TEntity>> ToPagedListAsync();

        /// <summary>
        /// Get async result from database with pagination (pageIndex = 0; pageSize = 10) / Получить результат асинхронно из базы данных с нумерацией страниц (pageIndex = 0; pageSize = 10)
        /// </summary>
        /// <param name="isDelete">>Статус удаления записи. (false = не удаленная запись, true = удаленная запись). По умолчанию false</param>
        /// <returns></returns>
        Task<PagedResult<TEntity>> ToPagedListAsync(bool isDelete = false);

        /// <summary>
        /// Get result from database with pagination / Получить результат из базы данных с нумерацией страниц
        /// </summary>
        /// <param name="pageIndex">page index. default 0 / Индекс страницы. По умолчанию 0</param>
        /// <param name="pageSize">get rows count in request. default 10 / получаемые кол-во записи по запросу. По умолчанию 0</param>
        /// <param name="isDelete">>Статус удаления записи. (false = не удаленная запись, true = удаленная запись). По умолчанию false</param>
        /// <returns></returns>
        Task<PagedResult<TEntity>> ToPagedListAsync(int pageIndex = 0, int pageSize = 10, bool isDelete = false);

        /// <summary>
        /// Get result from database with pagination / Получить результат из базы данных с нумерацией страниц
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition / Функция для проверки каждого элемента на условие</param>
        /// <param name="pageIndex">page index. default 0 / Индекс страницы. По умолчанию 0</param>
        /// <param name="pageSize">get rows count in request. default 10 / получаемые кол-во записи по запросу. По умолчанию 0</param>
        /// <param name="isDelete">Статус удаления записи. (false = не удаленная запись, true = удаленная запись). По умолчанию false></param>
        /// <returns></returns>
        PagedResult<TEntity> ToPagedList(Expression<Func<TEntity, bool>> predicate = null, int pageIndex = 0, int pageSize = 10, bool isDelete = false);


        /// <summary>
        /// Get result from database with pagination / Получить результат из базы данных с нумерацией страниц
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition / Функция для проверки каждого элемента на условие</param>
        /// <param name="pageIndex">page index. default 0 / Индекс страницы. По умолчанию 0</param>
        /// <param name="pageSize">get rows count in request. default 10 / получаемые кол-во записи по запросу. По умолчанию 0</param>
        /// <param name="isDelete"></param>
        /// <returns></returns>
        Task<PagedResult<TEntity>> ToPagedListAsync(Expression<Func<TEntity, bool>> predicate = null, int pageIndex = 0, int pageSize = 10, bool isDelete = false);

        /// <summary>
        /// Add TEntity to table / Добавить TEntity запись в таблицу
        /// </summary>
        /// <param name="entity">Модель таблицы</param>
        /// <returns></returns>
        TEntity Add(TEntity entity);

        /// <summary>
        /// AddAsync TEntity to table / Добавить асинхронно TEntity запись в таблицу
        /// </summary>
        /// <param name="entity">Модель таблицы</param>
        /// <returns></returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// AddRange List<TEntity> to table / Добавить лист List<TEntity> записи в таблицу
        /// </summary>
        /// <param name="entities">Список модели таблицы</param>
        /// <returns></returns>
        List<TEntity> AddRange(List<TEntity> entities);

        /// <summary>
        /// AddRangeAsync List<TEntity> to table / Добавить лист асинхронно List<TEntity> записи в таблицу
        /// </summary>
        /// <param name="entities">Список модели таблицы</param>
        /// <returns></returns>
        Task<List<TEntity>> AddRangeAsync(List<TEntity> entities);

        /// <summary>
        /// Update TEntity to table / Изменить TEntity запись в таблицу
        /// </summary>
        /// <param name="entity">Модель таблицы</param>
        /// <returns></returns>
        TEntity Update(TEntity entity);

        /// <summary>
        /// UpdateAsync TEntity to table / Изменить асинхронно TEntity запись в таблицу
        /// </summary>
        /// <param name="entity">Модель таблицы</param>
        /// <returns></returns>
        Task<TEntity> UpdateAsync(TEntity entity);

        /// <summary>
        /// UpdateRange List<TEntity> to table / Изменить List<TEntity> записи в таблицу
        /// </summary>
        /// <param name="entities">Список модели таблицы</param>
        /// <returns></returns>
        List<TEntity> UpdateRange(List<TEntity> entities);

        /// <summary>
        /// UpdateRangeAsync List<TEntity> to table / Изменить асинхронно List<TEntity> записи в таблицу
        /// </summary>
        /// <param name="entities">Список модели таблицы</param>
        /// <returns></returns>
        Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entities);

        /// <summary>
        /// Delete Id from table / Удалить Id запись из таблицы
        /// </summary>
        /// <param name="id">Id записи</param>
        /// <returns></returns>
        bool Delete(TKey id);

        /// <summary>
        /// DeleteAsync Id from table / Удалить асинхронно Id запись из таблицы
        /// </summary>
        /// <param name="id">Id записи</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(TKey id);

        /// <summary>
        /// Delete TEntity from table / Удалить TEntity запись из таблицы
        /// </summary>
        /// <param name="entity">Модель таблицы</param>
        /// <returns></returns>
        bool Delete(TEntity entity);

        /// <summary>
        /// DeleteAsync TEntity from table / Удалить асинхронно TEntity запись из таблицы
        /// </summary>
        /// <param name="entity">Модель таблицы</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(TEntity entity);

        /// <summary>
        /// DeleteRange List<TEntity> from table / Удалить список List<TEntity> записи из таблицы
        /// </summary>
        /// <param name="entities">Список модели таблицы</param>
        /// <returns></returns>
        bool DeleteRange(List<TEntity> entities);

        /// <summary>
        /// DeleteRangeAsync List<TEntity> from table / Удалить асинхронно список List<TEntity> записи из таблицы
        /// </summary>
        /// <param name="entities">Список модели таблицы</param>
        /// <returns></returns>
        Task<bool> DeleteRangeAsync(List<TEntity> entities);

        /// <summary>
        /// DeleteRange List<TKey> from table / Удалить список List<TKey> записи из таблицы
        /// </summary>
        /// <param name="idList">Лист Id записи</param>
        /// <returns></returns>
        bool DeleteRange(List<TKey> idList);

        /// <summary>
        /// DeleteRangeAsync List<TKey> from table / Удалить асинхронно список List<TKey> записи из таблицы
        /// </summary>
        /// <param name="idList">Лист Id записи</param>
        /// <returns></returns>
        Task<bool> DeleteRangeAsync(List<TKey> idList);

        /// <summary>
        /// Gets the first or default entity based / Получает первый объект или объект по умолчанию
        /// </summary>
        /// <returns></returns>
        TEntity GetFirstOrDefault();

        /// <summary>
        /// Gets the first or default entity based / Получает первый объект или объект по умолчанию
        /// </summary>
        /// <typeparam name="TResult">Return type / Возвращаемый тип</typeparam>
        /// <param name="selector">Selection properties for return / Выбор свойств для возврата</param>
        /// <returns></returns>
        TResult GetFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> selector);

        /// <summary>
        /// Gets the first or default entity based / Получает первый объект или объект по умолчанию
        /// </summary>
        /// <returns></returns>
        Task<TEntity> GetFirstOrDefaultAsync();

        /// <summary>
        /// Gets the first or default entity based / Получает первый объект или объект по умолчанию
        /// </summary>
        /// <typeparam name="TResult">Return type / Возвращаемый тип</typeparam>
        /// <param name="selector">Selection properties for return / Выбор свойств для возврата</param>
        /// <returns></returns>
        Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector);

        /// <summary>
        /// Gets the first or default entity based on a predicate / Получает первый объект или объект по умолчанию на основе фильтра
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition / Функция для проверки каждого элемента на условие</param>
        /// <returns></returns>
        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// Gets the first or default entity based on a predicate / Получает первый объект или объект по умолчанию на основе фильтра
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition / Функция для проверки каждого элемента на условие</param>
        /// <returns></returns>
        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// Gets the first or default entity based on a predicate / Получает первый объект или объект по умолчанию на основе фильтра
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition / Функция для проверки каждого элемента на условие</param>
        /// <param name="include">A function to include navigation properties / Функция для включения свойств навигации (Include())</param>
        /// <returns></returns>
        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate = null,
                                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        /// <summary>
        /// Gets the first or default entity based on a predicate / Получает первый объект или объект по умолчанию на основе фильтра
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition / Функция для проверки каждого элемента на условие</param>
        /// <param name="include">A function to include navigation properties / Функция для включения свойств навигации (Include())</param>
        /// <returns></returns>
        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null,
                                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        /// <summary>
        /// Gets the first or default entity based on a predicate / Получает первый объект или объект по умолчанию на основе фильтра
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition / Функция для проверки каждого элемента на условие</param>
        /// <param name="orderBy">A function to order elements / Функция для сортировки элементов</param>
        /// <param name="include">A function to include navigation properties / Функция для включения свойств навигации</param>
        /// <returns></returns>
        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate = null,
                                           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        /// <summary>
        /// Gets the first or default entity based on a predicate / Получает первый объект или объект по умолчанию на основе фильтра
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition / Функция для проверки каждого элемента на условие</param>
        /// <param name="orderBy">A function to order elements / Функция для сортировки элементов</param>
        /// <param name="include">A function to include navigation properties / Функция для включения свойств навигации</param>
        /// <returns></returns>
        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null,
                                           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);


        /// <summary>
        /// Gets the first or default entity based on a predicate / Получает первый объект или объект по умолчанию на основе фильтра
        /// </summary>
        /// <typeparam name="TResult">Return type / Возвращаемый тип</typeparam>
        /// <param name="selector">Selection properties for return / Выбор свойств для возврата</param>
        /// <param name="predicate">A function to test each element for a condition / Функция для проверки каждого элемента на условие</param>
        /// <param name="orderBy">A function to order elements / Функция для сортировки элементов</param>
        /// <param name="include">A function to include navigation properties / Функция для включения свойств навигации</param>
        /// <returns></returns>
        TResult GetFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> selector,
                                           Expression<Func<TEntity, bool>> predicate = null,
                                           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        /// <summary>
        /// Gets the first or default asynchronously entity based on a predicate  / Получает первый или заданный по умолчанию асинхронный объект на основе фильтра
        /// </summary>
        /// <typeparam name="TResult">Return type / Возвращаемый тип</typeparam>
        /// <param name="selector">Selection properties for return / Выбор свойств для возврата</param>
        /// <param name="predicate">A function to test each element for a condition / Функция для проверки каждого элемента на условие</param>
        /// <param name="orderBy">A function to order elements / Функция для сортировки элементов</param>
        /// <param name="include">A function to include navigation properties / Функция для включения свойств навигации</param>
        /// <returns></returns>
        Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
                                                       Expression<Func<TEntity, bool>> predicate = null,
                                                       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                       Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, bool>> predicate,
                                                                    Expression<Func<TEntity, TResult>> selector,
                                                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                                    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
    }
}
