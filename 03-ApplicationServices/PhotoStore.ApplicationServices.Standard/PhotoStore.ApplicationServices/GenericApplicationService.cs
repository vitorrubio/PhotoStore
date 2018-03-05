using PhotoStore.ApplicationServices.Interfaces;
using PhotoStore.Core.Interfaces.Services;
using PhotoStore.Core.Model;
using PhotoStore.Infra.DbContext;
using PhotoStore.Infra.Repository;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PhotoStore.ApplicationServices
{

    public class GenericApplicationService<T> : IGenericApplicationService<T> where T:Entidade
    {
        private IGenericService<T> _genericService;


		public GenericApplicationService(IGenericService<T> svc)
        {
			this._genericService = svc;
        }



		/// <summary>
		/// obtém um elemento pelo seu id
		/// </summary>
		/// <param name="id">int - o id da entidade </param>
		/// <returns>T - objeto encontrado</returns>
		public virtual T GetById(int id, params Expression<Func<T, object>>[] includeExpressions)
        {
            return this._genericService.GetById(id, includeExpressions);
        }

        /// <summary>
        /// obtém todos os objetos da base
        /// </summary>
        /// <returns>List de T</returns>
        public virtual IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions)
        {
            return this._genericService.GetAll(includeExpressions);
        }

        /// <summary>
        /// salva ou atualiza um objeto na base
        /// </summary>
        /// <param name="ent">T - objeto a ser salvo</param>
        public virtual void Save(T ent)
        {
			this._genericService.Save(ent);
        }


        /// <summary>
        /// exclui um objeto da base
        /// </summary>
        /// <param name="ent">T - objeto a ser excluído</param>
        public virtual void Delete(T ent)
        {
			this._genericService.Delete(ent);
        }


        /// <summary>
        /// exclui um objeto da base
        /// </summary>
        /// <param name="id">int - id do objeto a ser excluído</param>
        public virtual void Delete(int id)
        {
			this._genericService.Delete(id);
        }



        /// <summary>
        /// obtém um elemento pelo seu id
        /// Assíncrono
        /// </summary>
        /// <param name="id">int - o id da entidade </param>
        /// <returns>Task de T - o bojeto retornado do banco, assíncrono</returns>
        public virtual async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeExpressions)
        {
            return await this._genericService.GetByIdAsync(id, includeExpressions);
        }



        /// <summary>
        /// salva ou atualiza um objeto na base
        /// Assíncrono
        /// </summary>
        /// <param name="ent">T - objeto a ser salvo</param>
        /// <returns>Task</returns>
        public virtual async Task SaveAsync(T ent)
        {
            await this._genericService.SaveAsync(ent); 
        }


        /// <summary>
        /// exclui um objeto da base
        /// Assíncrono
        /// </summary>
        /// <param name="ent">T - objeto a ser excluído</param>
        /// <returns>Task</returns>
        public virtual async Task DeleteAsync(T ent)
        {
            await this._genericService.DeleteAsync(ent);
        }


        /// <summary>
        /// exclui um objeto da base
        /// Assíncrono
        /// </summary>
        /// <param name="id">int - id objeto a ser excluído</param>
        /// <returns>Task</returns>
        public virtual async Task DeleteAsync(int id)
        {
            await this._genericService.DeleteAsync(id);
        }
    }
}
