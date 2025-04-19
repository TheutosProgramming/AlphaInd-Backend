﻿using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class Status
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string StatusName { get; set; } = null!;
}
