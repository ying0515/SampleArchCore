using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SampleArch.Model.Database.POCO;

public partial class Person
{
    [Key]
    public long Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; }

    [StringLength(20)]
    public string Phone { get; set; }

    [StringLength(100)]
    public string Address { get; set; }

    [StringLength(50)]
    public string State { get; set; }

    public int? CountryId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [StringLength(256)]
    public string CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    [StringLength(256)]
    public string UpdatedBy { get; set; }
}
