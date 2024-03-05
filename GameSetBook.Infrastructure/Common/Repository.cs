﻿using GameSetBook.Infrastructure.Data;
using GameSetBook.Infrastructure.Models.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSetBook.Infrastructure.Common
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Provides gi given type DbSet
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>DbSet<T></returns>
        private DbSet<T> DbSet<T>() where T : class => dbContext.Set<T>();

        /// <summary>
        /// Add given entity to the DbSet
        /// </summary>
        /// <typeparam name="T">Type of element</typeparam>
        /// <param name="entity">element</param>
        /// <returns></returns>
        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }

        /// <summary>
        /// Get all elements
        /// </summary>
        /// <typeparam name="T">Type of element</typeparam>
        /// <returns>IQueryable<T></returns>
        public IQueryable<T> GetAll<T>() where T : class
        {
            return DbSet<T>();
        }

        /// <summary>
        /// Get all elements only for reading
        /// </summary>
        /// <typeparam name="T">Type of element</typeparam>
        /// <returns>IQueryable<T></returns>
        public IQueryable<T> GetAllReadOnly<T>() where T : class
        {
            return DbSet<T>().AsNoTracking();
        }

        /// <summary>
        /// Save changes into the database
        /// </summary>
        /// <returns>int number of items affected</returns>
        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete item from database
        /// </summary>
        /// <typeparam name="T">type of item</typeparam>
        /// <param name="entity">item</param>
        /// <returns></returns>
        public void Delete<T>(T entity) where T : class, IDeletable
        {
            entity.IsDeleted = false;
            entity.DeletedOn = DateTime.UtcNow;
        }

        /// <summary>
        /// Get all elements including deleted items
        /// </summary>
        /// <typeparam name="T">Type of items</typeparam>
        /// <returns>IQueryable<T></returns>
        public IQueryable<T> GetAllWithDeleted<T>() where T : class, IDeletable
        {        
            return DbSet<T>().IgnoreQueryFilters().IgnoreQueryFilters();
        }

        /// <summary>
        /// Get all elements including deleted items only for reading
        /// </summary>
        /// <typeparam name="T">Type of items</typeparam>
        /// <returns>IQueryable<T></returns>
        public IQueryable<T> GetAllWithDeletedReadOnly<T>() where T : class, IDeletable
        {
            return DbSet<T>().AsNoTracking().IgnoreQueryFilters();
        }

        /// <summary>
        /// Returns item with given id
        /// </summary>
        /// <typeparam name="T">type of item</typeparam>
        /// <param name="id">item identifier</param>
        /// <returns></returns>
        public async Task<T?> GetByIdAsync<T>(int id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }

        /// <summary>
        /// Returns item with given id
        /// </summary>
        /// <typeparam name="T">type of item</typeparam>
        /// <param name="id">item identifier</param>
        /// <returns></returns>
        public async Task<T?> GetByIdAsync<T>(string id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }
    }
}
