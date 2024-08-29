﻿using Domain.Entities;

namespace Domain.Repositories
{
    public interface ITeamMemberRepository
    {
        Task<TeamMember?> GetByIdAsync(Guid id);
        Task<IEnumerable<TeamMember>> GetAllAsync();
        Task AddAsync(TeamMember member);
        Task UpdateAsync();
        Task<bool> DeleteAsync(Guid id);
    }
}
