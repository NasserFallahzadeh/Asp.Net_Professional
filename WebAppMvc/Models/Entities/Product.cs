﻿using System.ComponentModel.DataAnnotations;

namespace WebAppMvc.Models.Entities;

public class Product
{
    public long Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    public int Price { get; set; }
}