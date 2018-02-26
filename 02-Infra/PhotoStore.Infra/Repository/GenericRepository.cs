using PhotoStore.Core.Model;
using PhotoStore.Infra.DbContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStore.Infra.Repository
{

    /// <summary>
    /// Classe de repositório generico seguindo as idéias de 
    /// https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
    /// http://appetere.com/post/passing-include-statements-into-a-repository
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : Entidade
    {

        private ApplicationDbContext _db;
        private DbSet<T> _dbSet;


        public GenericRepository(ApplicationDbContext ctx)
        {
            this._db = ctx;
            this._dbSet = _db.Set<T>();
        }

        /// <summary>
        /// obtém um elemento pelo seu id
        /// </summary>
        /// <param name="id">int - o id da entidade </param>
        /// <returns>T - objeto encontrado</returns>
        public virtual T GetById(int id, params Expression<Func<T, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                var set = includeExpressions
                  .Aggregate<Expression<Func<T, object>>, IQueryable<T>>
                    (_dbSet, (current, expression) => current.Include(expression));

                return set.SingleOrDefault(s => s.Id == id);
            }

            return _dbSet.Find(id);
        }

        /// <summary>
        /// obtém todos os objetos da base
        /// </summary>
        /// <returns>List de T</returns>
        public virtual IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions)
        {
            return includeExpressions
                  .Aggregate<Expression<Func<T, object>>, IQueryable<T>>
                    (_dbSet, (current, expression) => current.Include(expression));
        }

        /// <summary>
        /// salva ou atualiza um objeto na base
        /// </summary>
        /// <param name="ent">T - objeto a ser salvo</param>
        public virtual void Save(T ent)
        {
            if ((ent.Id == 0) || (!_dbSet.Any(x => x.Id == ent.Id)))
            {
				ent.Ativo = true;
                _dbSet.Add(ent);
            }
			else
			{
				_db.Entry(ent).State = EntityState.Modified;
			}

			_db.SaveChanges();
        }


        /// <summary>
        /// exclui um objeto da base
        /// </summary>
        /// <param name="ent">T - objeto a ser excluído</param>
        public virtual void Delete(T ent)
        {
            if ((ent != null) && (_dbSet.Any(x => x.Id == ent.Id)))
            {
                var deletando =  _dbSet.Find(ent.Id);
                if (deletando != null)
                {
                    _dbSet.Remove(deletando);
                    _db.SaveChanges();
                }
            }
        }


        /// <summary>
        /// exclui um objeto da base
        /// Assíncrono
        /// </summary>
        /// <param name="id">int - id da entidade a ser excluida</param>
        /// <returns></returns>
        public virtual void Delete(int id)
        {
            if (( _dbSet.Any(x => x.Id == id)))
            {
                var deletando =  _dbSet.Find(id);
                if (deletando != null)
                {
                    _dbSet.Remove(deletando);
                    _db.SaveChanges();
                }
            }
        }


        /// <summary>
        /// obtém um elemento pelo seu id
        /// Assíncrono
        /// </summary>
        /// <param name="id">int - o id da entidade </param>
        /// <returns>Task de T - o bojeto retornado do banco, assíncrono</returns>
        public virtual async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                var set = includeExpressions
                  .Aggregate<Expression<Func<T, object>>, IQueryable<T>>
                    (_dbSet, (current, expression) => current.Include(expression));

                return await set.SingleOrDefaultAsync(s => s.Id == id);
            }

            return await _dbSet.FindAsync(id);
        }



        /// <summary>
        /// salva ou atualiza um objeto na base
        /// Assíncrono
        /// </summary>
        /// <param name="ent">T - objeto a ser salvo</param>
        /// <returns>Task</returns>
        public virtual async Task SaveAsync(T ent)
        {
            if ((ent.Id == 0) || (!await _dbSet.AnyAsync(x => x.Id == ent.Id)))
            {
				ent.Ativo = true;
				_dbSet.Add(ent);
            }
			else
			{
				_db.Entry(ent).State = EntityState.Modified;
			}

			await _db.SaveChangesAsync();
        }


        /// <summary>
        /// exclui um objeto da base
        /// Assíncrono
        /// </summary>
        /// <param name="ent">T - objeto a ser excluído</param>
        /// <returns>Task</returns>
        public virtual async Task DeleteAsync(T ent)
        {
            if ((ent != null) && (await _dbSet.AnyAsync(x => x.Id == ent.Id)))
            {
                var deletando = await _dbSet.FindAsync(ent.Id);
                if (deletando != null)
                {
                    _dbSet.Remove(deletando);
                    await _db.SaveChangesAsync();
                }
            }
        }



        /// <summary>
        /// exclui um objeto da base
        /// Assíncrono
        /// </summary>
        /// <param name="id">int - id da entidade a ser excluida</param>
        /// <returns>Task</returns>
        public virtual async Task DeleteAsync(int id)
        {
            if ((await _dbSet.AnyAsync(x => x.Id == id)))
            {
                var deletando = await _dbSet.FindAsync(id);
                if (deletando != null)
                {
                    _dbSet.Remove(deletando);
                    await _db.SaveChangesAsync();
                }
            }
        }

    }
}
