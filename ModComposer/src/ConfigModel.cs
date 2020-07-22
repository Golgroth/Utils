using System;
using System.Text.Json.Serialization;

namespace Modcomposer
{
    [Serializable]
    internal class ConfigModel
    {
        [JsonPropertyName("Version")]
        public string Version { get; set; }
        [JsonPropertyName("ModContainerPath")]
        public string ModPath { get; set; }
        [JsonPropertyName("ServerPath")]
        public string ServerPath { get; set; }
        [JsonPropertyName("Mods")]
        public Mod[] Mods { get; set; }
    }
}
