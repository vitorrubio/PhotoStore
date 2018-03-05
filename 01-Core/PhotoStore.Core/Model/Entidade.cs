using System;


namespace PhotoStore.Core.Model
{
    public class Entidade
    {

		#region constructors

		public Entidade()
		{
			this.Ativo = true;
		}

		#endregion

		#region propriedades públicas


		/// <summary>
		///O Id da tabela.
		/// </summary>
		public virtual int Id { get; set; }

		/// <summary>
		/// Indica se o item está ativo ou não
		/// </summary>
		public virtual bool Ativo { get; set; }


        /// <summary>
        /// login do usuário que fez a inclusão
        /// </summary>
        public virtual string UsuarioInclusao { get; set; }

        /// <summary>
        /// data da inclusão
        /// </summary>
        public virtual DateTime? MomentoInclusao { get; set; }

        /// <summary>
        /// login do usuário que fez alteração
        /// </summary>
        public virtual string UsuarioEdicao { get; set; }

        /// <summary>
        /// data da alteração
        /// </summary>
        public virtual DateTime? MomentoEdicao { get; set; }


        #endregion


        #region metodos sobrecarregados padrão object


        /// <summary>
        /// Verifica se dois objetos são iguais através de um campo que os identifique, para poder fazer ordenações e distinct
        /// </summary>
        /// <param name="obj">objeto a ser comparado</param>
        /// <returns>bool - True se forem iguais</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (object.ReferenceEquals(this, obj))
                return true;

            if (!(obj is Entidade))
                return false;

            return this.Id.Equals((obj as Entidade).Id);
        }

        /// <summary>
        /// Verifica se dois objetos são iguais através de um campo que os identifique, para poder fazer ordenações e distinct
        /// igual o objeto acima, mas tipado, por performance
        /// </summary>
        /// <param name="ent">Entity a ser comparada</param>
        /// <returns>bool - True se forem iguais</returns>
        public virtual bool Equals(Entidade ent)
        {
            if (ent == null)
                return false;

            if (object.ReferenceEquals(this, ent))
                return true;

            return this.Id.Equals(ent.Id);
        }


        /// <summary>
        /// Chama o hashcode da propriedade usada como Id para comparações
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }


        #endregion


        #region operator overloading

        /// <summary>
        /// usa o método Equals para verificar se dois objetos são iguais e sobrecarregar a ação do operador de igualdade
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>bool</returns>
        public static bool operator ==(Entidade x, Entidade y)
        {
            if (((object)x == null) && ((object)y == null))
            {
                return true;
            }

            if (((object)x == null) || ((object)y == null))
            {
                return false;
            }

            return x.Equals(y);
        }

        /// <summary>
        /// usa o método Equals para verificar se dois objetos são iguais e sobrecarregar a ação do operador de desigualdade
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator !=(Entidade x, Entidade y)
        {
            return !(x == y);
        }

        #endregion
    }
}