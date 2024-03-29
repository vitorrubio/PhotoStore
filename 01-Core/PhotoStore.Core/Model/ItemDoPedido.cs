﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PhotoStore.Core.Model
{
    public class ItemDoPedido : Entidade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Display(Name = "Produto")]
		[Required]
        public virtual Produto Produto { get; set; }

		[Display(Name = "Produto")]
		[Required]
		public virtual Foto Foto { get; set; }

        [Display(Name = "Pedido")]
		[Required]
		public virtual Pedido Pedido { get; set; }

        [Display(Name = "Quantidade")]
        public virtual int Quantidade { get; set; }

        [Display(Name = "Preço")]
        public virtual decimal Preco { get; set; }

        [Display(Name = "Sub Total")]
        public virtual decimal SubTotal { get; set; }


        public virtual decimal CalculaSubtotal()
        {
            this.Preco = this.Produto?.Preco ?? 0;
            this.SubTotal = (this.Quantidade > 0 ? this.Quantidade * this.Preco : this.Preco);
            return this.SubTotal;
        }
    }
}