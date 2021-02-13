using System.Collections.Generic;

namespace Penguin.Json.Abstractions.Interfaces
{
    public interface IJsonPopulatedObject
    {
        IEnumerable<string> Properties { get; }
        string RawJson { get; set; }

        object GetProperty(string propertyName);
    }
}