using System.Text.Json.Serialization;

namespace CoreFlex.Razor.JsInterop.Dto;

/// <summary>
/// Location Dto
/// </summary>
public class LocationDto
{
    [JsonPropertyName("hash")]
    public string Hash { get; set; }

    [JsonPropertyName("host")]
    public string Host { get; set; }

    [JsonPropertyName("hostname")]
    public string Hostname { get; set; }

    [JsonPropertyName("href")]
    public string Href { get; set; }
    
    [JsonPropertyName("origin")]
    public string Origin { get; set; }
    
    [JsonPropertyName("pathname")]
    public string Pathname { get; set; }
    
    [JsonPropertyName("port")]
    public string Port { get; set; }
    
    [JsonPropertyName("protocol")]
    public string Protocol { get; set; }
    
    [JsonPropertyName("search")]
    public string Search { get; set; }
}