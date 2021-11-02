using System.ComponentModel.DataAnnotations;

namespace App_Lanches.Models
{
    //representa um lanche selecionado
    public class CarrinhoCompraItem
    {
        public int CarrinhoCompraItemId { get; set; }
        public Lanche Lanche { get; set; }
        public int Quantidade { get; set; }
        [StringLength(200)]
        public string CarrinhoCompraId { get; set; }
        // permite criar um relacionamento em a entidade CarrinhoCompraItem e entidade CarrinhoCompra
    }
}