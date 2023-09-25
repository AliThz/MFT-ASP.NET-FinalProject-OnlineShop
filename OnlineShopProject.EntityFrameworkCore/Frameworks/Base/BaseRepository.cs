using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.EntityFrameworkCore.Frameworks.Base
{
    public class BaseRepository<K_DbContext, T_Entity, U_PrimaryKey> : Domain.Contract.Abstracts.IRepository<T_Entity, U_PrimaryKey>
                                                                          where T_Entity : class
                                                                          where K_DbContext : IdentityDbContext<IdentityUser>
    {
        #region [ - Ctor - ]
        public BaseRepository(K_DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<T_Entity>();
        }
        #endregion

        #region [ - Props - ]
        public virtual K_DbContext DbContext { get; set; }
        public virtual DbSet<T_Entity> DbSet { get; set; }
        #endregion

        #region [ - Methods - ]

        #region [ - InsertAsync(T_Entity entity) - ]
        public virtual async Task InsertAsync(T_Entity entity)
        {
            using (DbContext)
            {
                DbSet.Add(entity);
                await SaveChanges();
            }
        }
        #endregion

        #region [ - UpdateAsync(T_Entity entity) - ]
        public virtual async Task UpdateAsync(T_Entity entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
        } 
        #endregion

        #region [ - DeleteAsync(U_PrimaryKey id) - ]
        public virtual async Task DeleteAsync(U_PrimaryKey id)
        {
            var entityToDelete = DbSet.Find(id);
            DbSet.Remove(entityToDelete);
            await SaveChanges();
        }
        #endregion

        #region [ - DeleteAsync(T_Entity entity) - ]
        public virtual async Task DeleteAsync(T_Entity entityToDelete)
        {
            if (DbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
            await SaveChanges();
        }
        #endregion

        #region [ - Select() - ]
        public virtual async Task<List<T_Entity>> SelectAsync()
        {
            var entityList = DbSet.AsNoTracking().ToListAsync();
            return await entityList;
        }
        #endregion

        #region [ - FindByIdAsync(U_PrimaryKey id) - ]
        public virtual async Task<T_Entity> FindByIdAsync(U_PrimaryKey id)
        {
            var requestedEntity = DbSet.FindAsync(id);
            return await requestedEntity;
        }
        #endregion

        #region [ - SaveChanges() - ]
        public async Task SaveChanges()
        {
            await DbContext.SaveChangesAsync();
        }
        #endregion

        #endregion
    }
}
