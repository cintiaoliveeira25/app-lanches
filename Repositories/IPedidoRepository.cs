using App_Lanches.Models;

namespace App_Lanches.Repositories.Interface
{
    public interface IPedidoRepository
    {
        void CriarPedido(Pedido pedido);
    }
}
