namespace TokenGpt.Contract.Services.Dto;

public class ApplicationInput
{
    public string Name { get; set; }

    public string Icon { get; set; }

    public string Description { get; set; }
    
    public string Model { get; set; }

    public string Prologue { get; set; }
}