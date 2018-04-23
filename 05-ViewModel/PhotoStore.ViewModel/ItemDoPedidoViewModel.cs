using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PhotoStore.ViewModel
{
    public class ItemDoPedidoViewModel
	{

        public virtual int Id { get; set; }

        [Display(Name = "Produto")]
		[Required]
        public virtual ProdutoViewModel Produto { get; set; }

		[Display(Name = "Produto")]
		[Required]
		public virtual FotoViewModel Foto { get; set; }

        [Display(Name = "Pedido")]
		[Required]
		public virtual PedidoViewModel Pedido { get; set; }

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