using System.Reflection;
using Domain.ValueObject;

namespace Domain.Primitives;

 public class FullName : BaseValueObject
    {
        public FullName(string firstName, string? lastName, string? middleName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; } = null;
        /// <summary>
        /// Реализация DeepCompare с рефлексией
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool DeepCompare(FullName other)
        {
            if (other == null)
                return false;

            // получаем все свойства объекта текущего экземпляра 
            PropertyInfo[] properties = typeof(FullName).GetProperties();

            // проходимся по каждому свойству
            foreach (var property in properties)
            {
                // получаем значения свойств для текущего экземпляра (this) и для другого объекта (other)
                var thisValue = property.GetValue(this);
                var otherValue = property.GetValue(other);

                // сравниваем значения свойств
                if (!Equals(thisValue, otherValue))
                    return false;
            }

            // если все свойства эквивалентны
            return true;
        }
        /// <summary>
        /// Реализация DeepClone для FullName
        /// </summary>
        /// <returns></returns>
        public FullName DeepClone()
        {
            return new FullName(FirstName, LastName, MiddleName);
        }

        public FullName Update(string? firstName, string? lastName, string? middleName)
        {
            if (firstName is not null)
            {
                FirstName = firstName;
            }
            if (lastName is not null)
            {
                LastName = lastName;
            }
            if (middleName is not null)
            {
                MiddleName = middleName;
            }
            return this;
        }
    }
