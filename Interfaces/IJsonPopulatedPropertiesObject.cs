using System.Collections.Generic;

namespace Penguin.Json.Abstractions.Interfaces
{
    public interface IJsonPopulatedPropertiesObject : IJsonPopulatedObject
    {
        IEnumerable<string> Properties { get; }
        object GetProperty(string propertyName);
    }
}
