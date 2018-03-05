using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PhotoStore.Core.Model
{
    public class Pedido : Entidade
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public virtual string Email { get; set; }

        [Required]
        [Display(Name = "CPF")]
        public virtual string CPF { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public virtual string Nome { get; set; }

        [Required]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\([0-9]{2}\))\s([0-9]{4})-([0-9]{4,5})$", ErrorMessage = "Celular Inválido")]
        [Display(Name = "Celular")]
        public virtual string Celular { get; set; }

        [Display(Name = "Data do Pedido")]
        public virtual DateTime DataPedido { get; set; }

        [Display(Name = "Itens do Pedido")]
        public virtual ICollection<ItemDoPedido> Itens { get; set; }

		public virtual StatusPedido Status { get; set; }

		public virtual DateTime? ValidoAte { get; set; }

		public virtual void AddItem(ItemDoPedido item)
		{
			item.Pedido = this;
			item.CalculaSubtotal();
			this.Itens.Add(item);
		}

    }
}