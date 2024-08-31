﻿using Domain.Entities;
using Domain.Helpers;
using Domain.QueryStrings;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public ProjectRepository(RepositoryDbContext context)
        {
            _dbContext = context;
        }

        public async Task<PaginatedList<Project>> GetAllAsync(QueryStringParameters parameters)
        {
            var allProjects = await _dbContext.Projects
                .Where(a => a.Name.StartsWith(parameters.FirstLetter) && a.Name.Contains(parameters.SearchText))
                .Include(t => t.Status)
                .Include(t => t.Customer)
                .Include(t => t.Lead)
                .ToListAsync();
            var allProjectsQuarriable = allProjects.AsQueryable();
            var projects = PaginatedList<Project>.ToPagedList(allProjectsQuarriable, parameters.PageNumber, parameters.PageSize);
            return projects;
        }

        public async Task<Project?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Projects
                .Include(t => t.Status)
                .Include(t => t.Customer)
                .Include(t => t.Lead)
                .SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Project>> GetByStatus(string status)
        {
            var projects = await _dbContext.Projects
                .Where(t => t.Status.StatusName == status)
                .Include(t => t.Status)
                .Include(t => t.Customer)
                .Include(t => t.Lead)
                .ToArrayAsync();
            return projects;
        }

        public async Task AddAsync(Project project)
        {
            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existingProject = await _dbContext.Projects.FindAsync(id);
            if (existingProject is null) 
            {
                return false;
            };
            _dbContext.Projects.Remove(existingProject);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        
    }
}
