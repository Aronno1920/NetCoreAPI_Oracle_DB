using DMSAPI.Entities;

namespace DMSAPI.Interfaces
{
    public interface IPurchaseOrderRepository
    {
        Task<List<PurchaseOrder>> GetPurchaseOrderList(String reqIds);

        Task<PurchaseOrder> GetPurchaseOrderById(String poId);
    }
}
