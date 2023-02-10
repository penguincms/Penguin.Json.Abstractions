using System;

namespace Penguin.Json.Abstractions.Attributes
{
    public abstract class ConditionalValue
    {
        private bool shouldSerialize = true;

        public Type ObjectType { get; private set; }

        public bool ShouldSerialize
        {
            get => ShouldSerializeFunc?.Invoke() ?? shouldSerialize;
            set => shouldSerialize = value;
        }

        protected Func<object> GetValueFunc { get; set; }

        protected object Ovalue { get; set; }

        protected Func<bool> ShouldSerializeFunc { get; set; }

        protected ConditionalValue(Type objectType)
        {
            ObjectType = objectType;
        }

        public T GetValue<T>()
        {
            return (T)Ovalue;
        }

        public object GetValue()
        {
            return GetValueFunc?.Invoke() ?? Ovalue;
        }

        public override string ToString()
        {
            return Ovalue?.ToString();
        }
    }
}