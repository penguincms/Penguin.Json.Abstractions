﻿using System;

namespace Penguin.Json.Abstractions.Attributes
{
    public class ConditionalValue<T> : ConditionalValue
    {
        public T Value
        {
            get => GetValue<T>();
            set => Ovalue = value;
        }

        public ConditionalValue(T value, Func<bool> shouldSerializeFunc) : base(typeof(T))
        {
            Value = value;
            ShouldSerializeFunc = shouldSerializeFunc;
        }

        public ConditionalValue(T value) : this(value, null)
        {
        }

        public ConditionalValue(Func<bool> shouldSerializeFunc = null) : base(typeof(T))
        {
            ShouldSerializeFunc = shouldSerializeFunc;
        }

        public ConditionalValue(Func<T> getValue, Func<bool> shouldSerializeFunc = null) : this(shouldSerializeFunc)
        {
            ShouldSerializeFunc = shouldSerializeFunc;
            GetValueFunc = () => getValue;
        }

        public static implicit operator ConditionalValue<T>(T b)
        {
            return new ConditionalValue<T>(b);
        }

        public static implicit operator T(ConditionalValue<T> d)
        {
            return d is null ? throw new ArgumentNullException(nameof(d)) : d.Value;
        }

        public ConditionalValue<T> ToConditionalValue()
        {
            throw new NotImplementedException();
        }

        public T ToT()
        {
            throw new NotImplementedException();
        }
    }
}