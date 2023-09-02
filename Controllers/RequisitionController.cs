using DMSAPI.Entities;
using DMSAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DMSAPI.Repositories;

namespace DMSAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class RequisitionController : ControllerBase
    {
        private readonly IRequisitionRepository _requisitionRepository;

        public RequisitionController(IRequisitionRepository requisitionRepository)
        {
            _requisitionRepository = requisitionRepository;
        }

        [HttpGet]
        public async Task<List<Requisition>> GetAll()
        {
            List<Requisition> requisitions = await _requisitionRepository.GetRequisitionList();
            return requisitions;
        }

        [HttpGet]
        public async Task<Requisition> GetById(String reqId)
        {
            Requisition requisition = await _requisitionRepository.GetRequisitionById(reqId);
            return requisition;
        }
    }
}
