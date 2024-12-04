﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdSemesterProject.APIClient.DTOs;

public class AddressDTO
{
    public string RoadName { get; set; }
    public string HouseNo { get; set; }
    public string City { get; set; }
    public int Zip { get; set; }

    public AddressDTO()
    {
    }
}