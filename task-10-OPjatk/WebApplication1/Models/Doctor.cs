﻿using System.Text.Json.Serialization;

namespace WebApplication1.Models;

public class Doctor
{
    public int IdDoctor { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    
    [JsonIgnore]
    public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

}