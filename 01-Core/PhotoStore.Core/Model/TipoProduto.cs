﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PhotoStore.Core.Model
{
    public class TipoProduto : Entidade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres")]
        [Display(Name = "Nome")]
        public virtual string Nome { get; set; }
		 
        [Required]
        [MaxLength(2000, ErrorMessage = "a Descricao deve ter no máximo 80 caracteres")]
        [Display(Name = "Descrição")]
        public virtual string Descricao { get; set; }

        [Display(Name = "Preço Sugerido")]
        public virtual decimal PrecoSugerido { get; set; }

		public virtual ICollection<Produto> Produtos { get; set; }

	}
}