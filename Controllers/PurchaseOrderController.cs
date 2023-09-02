using DMSAPI.Entities;
using DMSAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DMSAPI.Repositories;

namespace DMSAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class PurchaseOrderController : ControllerBase
    {
        private readonly IPurchaseOrderRepository _poRepository;

        public PurchaseOrderController(IPurchaseOrderRepository poRepository)
        {
            _poRepository = poRepository;
        }

        [HttpGet]
        public async Task<List<PurchaseOrder>> GetAll(String? requisitionId)
        {
            List<PurchaseOrder> requisitions = await _poRepository.GetPurchaseOrderList(requisitionId);
            return requisitions;
        }

        [HttpGet]
        public async Task<PurchaseOrder> GetById(String purchaseOrderId)
        {
            PurchaseOrder requisition = await _poRepository.GetPurchaseOrderById(purchaseOrderId);
            return requisition;
        }
    }
}
