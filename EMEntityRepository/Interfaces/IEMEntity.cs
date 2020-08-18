using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMEntityRepository.Interfaces
{
    /// <summary>
    /// Interface with base properties for new table / Интерфейс с базовыми свойствами для новой таблицы
    /// </summary>
    /// <typeparam name="TKey">Primary key's type / Тип первичного ключа</typeparam>
    public interface IEMEntity<TKey>
    {
        /// <summary>
        /// Primary Key / Первичный ключ
        /// </summary>
        public TKey Id { get; set; }

        /// <summary>
        /// Deletion status entry / Запись о статусе удаления
        /// </summary>
        [BindNever]
        public bool IsDelete { get; set; }

        /// <summary>
        /// Date created entry / Дата создания записи
        /// </summary>
        [BindNever]
        public DateTime Created { get; set; }

        /// <summary>
        /// Date modified entry / Дата изменения записи
        /// </summary>
        [BindNever]
        public DateTime Updated { get; set; }

        /// <summary>
        /// Date modified entry / Дата изменения записи
        /// </summary>
        [BindNever]
        public DateTime? Deleted { get; set; }
    }
}
