﻿namespace Kol2.DTOs;

public class PlayerDto
{
    public int PlayerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public ICollection<Matches> Matches { get; set; }
}