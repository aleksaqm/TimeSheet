﻿using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public ClientRepository(RepositoryDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            var clients = await _dbContext.Clients.ToArrayAsync();
            return clients;
        }

        public async Task<Client?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Clients.FindAsync(id);
        }

        public async Task AddAsync(Client client)
        {
            await _dbContext.Clients.AddAsync(client);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existingClient = await _dbContext.Clients.FindAsync(id);
            if (existingClient is null)
            {
                return false;
            }
            _dbContext.Clients.Remove(existingClient);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
