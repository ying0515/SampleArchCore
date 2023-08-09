using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SampleArch.Model.Database.POCO;

public partial class Country
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; }
}
