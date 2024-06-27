namespace Domain.Entities
{
    /// <summary>
    /// Базовый класс для сущностей
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Индетификатор сущности
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Дата создания сущности
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Сравнение сущностей по Id
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj is not BaseEntity entity) return false;

            if (ReferenceEquals(this, entity)) return true;

            return Id == entity.Id;
        }
    }
}