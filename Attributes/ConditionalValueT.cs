using System;

namespace Penguin.Json.Abstractions.Attributes
{
    public class ConditionalValue<T> : ConditionalValue
    {
        public T Value
        {
            get => this.GetValue<T>();
            set => this.Ovalue = value;
        }

        public ConditionalValue(T value, Func<bool> shouldSerializeFunc) : base(typeof(T))
        {
            this.Value = value;
            this.ShouldSerializeFunc = shouldSerializeFunc;
        }

        public ConditionalValue(T value) : this(value, null)
        {
        }

        public ConditionalValue(Func<bool> shouldSerializeFunc = null) : base(typeof(T))
        {
            this.ShouldSerializeFunc = shouldSerializeFunc;
        }

        public ConditionalValue(Func<T> getValue, Func<bool> shouldSerializeFunc = null) : this(shouldSerializeFunc)
        {
            this.ShouldSerializeFunc = shouldSerializeFunc;
            this.GetValueFunc = () => getValue;
        }

        public static implicit operator ConditionalValue<T>(T b) => new ConditionalValue<T>(b);

        public static implicit operator T(ConditionalValue<T> d)
        {
            if (d is null)
            {
                throw new ArgumentNullException(nameof(d));
            }

            return d.Value;
        }
    }
}