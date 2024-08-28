﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ModelBuilders
{
    internal class ActivityModelBuilder
    {
        private readonly ModelBuilder _modelBuilder;
        public ActivityModelBuilder(ModelBuilder builder)
        {
            _modelBuilder = builder;
        }

        public void OnModelCreating()
        {
            _modelBuilder.Entity<Activity>().HasKey(a => a.Id);
            _modelBuilder.Entity<Activity>()
                .Property(a => a.Date)
                .IsRequired();
            _modelBuilder.Entity<Activity>()
                .Property(a => a.Description)
                .IsRequired(false);
            _modelBuilder.Entity<Activity>()
                .Property(a => a.Overtime)
                .IsRequired(false);
            _modelBuilder.Entity<Activity>()
                .HasOne<Client>(a => a.Client)
                .WithMany()
                .HasForeignKey(a => a.ClientId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            _modelBuilder.Entity<Activity>()
                .HasOne<Category>(a => a.Category)
                .WithMany()
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            _modelBuilder.Entity<Activity>()
                .HasOne<Project>(a => a.Project)
                .WithMany()
                .HasForeignKey(a => a.ProjectId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            _modelBuilder.Entity<Activity>()
                .Property(a => a.Hours)
                .IsRequired();
            _modelBuilder.Entity<Activity>()
                .HasOne<TeamMember>(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
