﻿namespace ThirdSemesterProject.WebAPI.DTOs;

public class PersonDTO
{
    public int PersonId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNO { get; set; }
    public string PasswordHash { get; set; }
    public string PersonType { get; set; }
}
