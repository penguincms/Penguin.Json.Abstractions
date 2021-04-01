using System.Collections.Generic;

namespace Penguin.Json.Abstractions.Interfaces
{
    public interface IJsonPopulatedObject
    {
        string RawJson { get; set; }
    }
}