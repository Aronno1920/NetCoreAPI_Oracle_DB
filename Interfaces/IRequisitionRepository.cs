using DMSAPI.Entities;

namespace DMSAPI.Interfaces
{
    public interface IRequisitionRepository
    {
        public Task<List<Requisition>> GetRequisitionList();

        public Task<Requisition> GetRequisitionById(String reqId);
    }
}
