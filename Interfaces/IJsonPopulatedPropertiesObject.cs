using System;
using System.Collections.Generic;
using System.Text;

namespace Penguin.Json.Abstractions.Interfaces
{
    public interface IJsonPopulatedPropertiesObject : IJsonPopulatedObject
    {
        IEnumerable<string> Properties { get; }
        object GetProperty(string propertyName);
    }
}
