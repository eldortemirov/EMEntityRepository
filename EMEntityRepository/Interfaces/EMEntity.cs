using System;
using System.Collections.Generic;
using System.Text;

namespace EMEntityRepository.Interfaces
{
    /// <summary>
    /// An abstract class with basic properties for the new table (If the model (table class) class inherits from the EMEntity class, it is not necessary to implement the IEMEntity interface) / Абстрактный класс с базовыми свойствами для новой таблицы (Если наследует модел(класс таблицы) класс от абсрактного класса EMEntity, не требуется реализовать(имплементировать) интерфейс IEMEntity)
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public abstract class EMEntity<TKey> : IEMEntity<TKey>
    {
        public TKey Id { get ; set; }
        public bool IsDelete { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
