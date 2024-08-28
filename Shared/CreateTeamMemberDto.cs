﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class CreateTeamMemberDto
    {
        public required string Name { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required double HoursPerWeek { get; set; }
        public required string Role { get; set; }
        public required string Status { get; set; }
    }
}
