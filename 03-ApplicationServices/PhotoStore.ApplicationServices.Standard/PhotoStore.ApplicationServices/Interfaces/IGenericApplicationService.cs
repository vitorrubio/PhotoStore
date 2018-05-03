using PhotoStore.Core.Model;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PhotoStore.ApplicationServices.Interfaces
{
    /// <summary>
    /// Interfce de app service genérico
    /// 
    /// seguindo as idéias de 
	/// http://www.eduardopires.net.br/2014/10/tutorial-asp-net-mvc-5-ddd-ef-automapper-ioc-dicas-e-truques/
	/// https://www.youtube.com/watch?time_continue=37&v=i9Il79a2uBU
    /// </summary>
    public interface IGenericApplicationService<T> where T : Entidade
    {
        /// <summary>
        /// obtém um elemento pelo seu id
        /// </summary>
        /// <param name="id">int - o id da entidade </param>
        /// <returns>T - objeto encontrado</returns>
        T GetById(int id,  params Expression<Func<T, object>>[] includeExpressions);

        /// <summary>
        /// obtém todos os objetos da base
        /// </summary>
        /// <returns>List de T</returns>
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions);

		/// <summary>
		/// obtém todos os objetos da base sem lazy load
		/// </summary>
		/// <returns>List de T</returns>
		IQueryable<T> GetAllDetached(params Expression<Func<T, object>>[] includeExpressions);

		/// <summary>
		/// salva ou atualiza um objeto na base
		/// </summary>
		/// <param name="ent">T - objeto a ser salvo</param>
		void Save(T ent);


        /// <summary>
        /// exclui um objeto da base
        /// </summary>
        /// <param name="ent">T - objeto a ser excluído</param>
        void Delete(T ent);


        /// <summary>
        /// exclui um objeto da base pelo seu id
        /// </summary>
        /// <param name="id">int - id da entidade</param>
        void Delete(int id);


        /// <summary>
        /// obtém um elemento pelo seu id
        /// Assíncrono
        /// </summary>
        /// <param name="id">int - o id da entidade </param>
        /// <returns>Task de T - o bojeto retornado do banco, assíncrono</returns>
        Task<T> GetByIdAsync(int id,  params Expression<Func<T, object>>[] includeExpressions);


        /// <summary>
        /// salva ou atualiza um objeto na base
        /// Assíncrono
        /// </summary>
        /// <param name="ent">T - objeto a ser salvo</param>
        /// <returns>Task</returns>
        Task SaveAsync(T ent);


        /// <summary>
        /// exclui um objeto da base
        /// Assíncrono
        /// </summary>
        /// <param name="ent">T - objeto a ser excluído</param>
        /// <returns>Task</returns>
        Task DeleteAsync(T ent);


        /// <summary>
        /// exclui um objeto da base pelo seu id
        /// </summary>
        /// <param name="id">int - id da entidade</param>
        Task DeleteAsync(int id);

    }
}
