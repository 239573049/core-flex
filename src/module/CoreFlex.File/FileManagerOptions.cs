namespace CoreFlex.File;

public class FileManagerOptions
{
    public int DayMaxCount { get; set; } = 100;
    
    public int MaxSize { get; set; } = 1024 * 1024 * 10;
    
}