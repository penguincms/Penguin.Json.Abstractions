using System;

namespace Penguin.Json.Abstractions.Attributes
{
    public abstract class ConditionalValue
    {
        private bool shouldSerialize = true;
        public Type ObjectType { get; private set; }

        public bool ShouldSerialize
        {
            get => this.ShouldSerializeFunc?.Invoke() ?? this.shouldSerialize;
            set => this.shouldSerialize = value;
        }

        protected Func<object> GetValueFunc { get; set; }
        protected object Ovalue { get; set; }
        protected Func<bool> ShouldSerializeFunc { get; set; }

        public ConditionalValue(Type objectType) => this.ObjectType = objectType;

        public T GetValue<T>() => (T)this.Ovalue;

        public object GetValue() => this.GetValueFunc?.Invoke() ?? this.Ovalue;

        public override string ToString() => this.Ovalue?.ToString();
    }
}