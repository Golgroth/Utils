using System;
using System.Text.Json.Serialization;

namespace Modcomposer
{
    [Serializable]
    internal class Mod
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("ModPath")]
        public string Path { get; set; }
        [JsonPropertyName("Enabled")]
        public bool IsEnabled { get; set; }
    }
}
