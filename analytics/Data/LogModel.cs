using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Analytics.Portal.Data.Models;

[Table("Log", Schema = "dbo" )]
public class LogModel 
{
    [Key]
    [Column("Id")]
    public long? Id { get; set; }

    [Column("Date")]
    public DateTime? DataOcorrenia { get; set; }

    [Column("MethodName")]
    public string? Metodo { get; set; }

    [Column("Parameters")]
    public string? Json { get; set; }

    [Column("Result")]
    public string? Resultado { get; set; }

    [Column("Success")]
    public bool? Sucesso { get; set; }

    [Column("ErrorCode")]
    public int? CodigoDoErro { get; set; }
}