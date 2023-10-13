﻿using cineflex.Application;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cineflex.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected readonly CinemaMovieDbContext _dbContext;

        public GenericRepository(CinemaMovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }



        public async Task<bool> Exists(int id)
        {
            var entity = await GetById(id);
            return entity != null;
        }


        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

 

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);

        }

  

        public async Task Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
