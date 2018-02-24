using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhotoStore.Core.Model
{
    public class ItemDoPedido : Entidade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Display(Name = "Produto")]
        public virtual Produto Produto { get; set; }

        [Display(Name = "Pedido")]
        public virtual Pedido Pedido { get; set; }

        [Display(Name = "Quantidade")]
        public virtual int Quantidade { get; set; }

        [Display(Name = "Preço")]
        public virtual decimal Preco { get; set; }

        [Display(Name = "Sub Total")]
        public virtual decimal SubTotal { get; set; }


        public virtual decimal CalculaSubtotal()
        {
            this.Preco = this.Produto?.Tipo?.Preco ?? 0;
            this.SubTotal = (this.Quantidade > 0 ? this.Quantidade + this.Preco : this.Preco);
            return this.SubTotal;
        }
    }
}