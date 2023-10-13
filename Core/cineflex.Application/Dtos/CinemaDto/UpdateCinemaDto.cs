﻿using cineflex.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cineflex.Application.Dtos.CinemaDto
{
    public class UpdateCinemaDto :BaseDto, ICinemaDto
    {

        public string Name { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
    }
}
