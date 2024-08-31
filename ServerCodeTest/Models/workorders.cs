using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerCodeTest.Models;

public class _dbo_workorders
{
    [Key]
    public int wonum { get; set; }

    [Column(TypeName = "VARCHAR")]
    [StringLength(50)]
    public string? email { get; set; }

    [Column(TypeName = "VARCHAR")]
    [StringLength(20)]
    public string? status { get; set; } = "Open";
    public DateTime? datereceived { get; set; } = DateTime.Now;
    public DateTime? dateassigned { get; set; }
    public DateTime? datecomplete { get; set; }
    [Column(TypeName = "VARCHAR")]
    [StringLength(50)]
    public string? contactname { get; set; }

    public string? techniciancomments { get; set; }

    [Column(TypeName = "VARCHAR")]
    [StringLength(25)]
    public string? contactnumber { get; set; }

    public int? technicianid { get; set; }
    public string? problem { get; set; }
}


public class CreateWorkOrder
{
    public string? problem { get; set; }
    public string? contactnumber { get; set; }
    public string? contactname { get; set; }
    public string? email { get; set; }
    public int? technicianid { get; set; }
}