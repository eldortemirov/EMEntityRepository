using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMEntityRepository.Interfaces
{
    /// <summary>
    /// An abstract class with basic properties for the new table (If the model (table class) class inherits from the EMEntity class, it is not necessary to implement the IEMEntity interface) / Абстрактный класс с базовыми свойствами для новой таблицы (Если наследует модел(класс таблицы) класс от абсрактного класса EMEntity, не требуется реализовать(имплементировать) интерфейс IEMEntity)
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public abstract class EMEntity<TKey> : IEMEntity<TKey>
    {
        /// <summary>
        /// Key property
        /// </summary>
        [Key]
        [Column("id")]
        public TKey Id { get ; set; }

        /// <summary>
        /// Delete status
        /// </summary>
        [Column("is_delete")]
        public bool IsDelete { get; set; }

        /// <summary>
        /// Create Date
        /// </summary>
        [Column("created")]
        public DateTime Created { get; set; }
        
        /// <summary>
        /// Update Date
        /// </summary>
        [Column("updated")]
        public DateTime Updated { get; set; }

        /// <summary>
        /// Delete Date
        /// </summary>
        [Column("deleted")]
        public DateTime? Deleted { get; set; }
    }
}
