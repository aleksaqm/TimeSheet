﻿namespace Shared
{
    public class TeamMemberCreateDto
    {
        public required string Name { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required double HoursPerWeek { get; set; }
        public required string Role { get; set; }
        public required string Status { get; set; }
    }
}
