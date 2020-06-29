using System;

namespace Penguin.Json.Abstractions.Attributes
{
    public abstract class ConditionalValue
    {
        protected object ovalue;

        private bool shouldSerialize = true;

        public Type ObjectType { get; private set; }

        public bool ShouldSerialize
        {
            get
            {
                return ShouldSerializeFunc?.Invoke() ?? shouldSerialize;
            }
            set
            {
                shouldSerialize = value;
            }
        }

        protected Func<object> GetValueFunc { get; set; }

        protected Func<bool> ShouldSerializeFunc { get; set; }

        public ConditionalValue(Type objectType)
        {
            ObjectType = objectType;
        }

        public T GetValue<T>() => (T)ovalue;

        public object GetValue() => GetValueFunc?.Invoke() ?? ovalue;

        public override string ToString()
        {
            return ovalue?.ToString();
        }
    }
}