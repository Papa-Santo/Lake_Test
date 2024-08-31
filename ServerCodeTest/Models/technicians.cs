using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerCodeTest.Models;

public class _dbo_technicians
{
    [Key]
    public int technicianid { get; set; }

    [Column(TypeName = "VARCHAR")]
    [StringLength(30)]
    public required string technicianname { get; set; }

    [Column(TypeName = "VARCHAR")]
    [StringLength(50)]
    public required string? technicianemail { get; set; }
}