﻿namespace Shared
{
    public class ProjectUpdateDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required Guid CustomerId { get; set; }
        public required Guid LeadId { get; set; }
        public required string Status { get; set; }
    }
}
