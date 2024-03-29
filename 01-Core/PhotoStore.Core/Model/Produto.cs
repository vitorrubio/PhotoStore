﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PhotoStore.Core.Model
{
    public class Produto : Entidade
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Display(Name ="Id")]
        public override int Id { get; set; }

		[MaxLength(200, ErrorMessage = "O nome deve ter no máximo 200 caracteres")]
		[Required (ErrorMessage = "O nome é obrigatório")]
		[Index(IsUnique = true)]
		[Display(Name = "Nome")]
		public virtual string Nome { get; set; }

		[MaxLength(1000, ErrorMessage = "A descrição deve ter no máximo 1000 caracteres")]
		[Display(Name = "Descrição")]
		public virtual string Descricao { get; set; }

		[Display(Name = "Tipo")]
		public virtual TipoProduto Tipo { get; set; }

		[ForeignKey("Tipo")]
		[Display(Name = "Tipo")]
		public virtual int IdTipoProduto { get; set; }

		[Required(ErrorMessage = "O preço é obrigatório")]
		[Display(Name = "Preço")]
		public virtual decimal Preco { get; set; }

    }
}