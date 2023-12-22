using FreeSql.DataAnnotations;

namespace TokenGpt.Rcl.Model;

public class ApplicationEntity
{
    [Column(IsIdentity = true)]
    public int Id { get; set; }
    
    public string Name { get; set; }

    public string Icon { get; set; }

    public string Description { get; set; }

    public string Model { get; set; }

    public string Prologue { get; set; }
}