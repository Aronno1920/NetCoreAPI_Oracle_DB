using System.Data;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using DMSAPI.Entities;
using DMSAPI.Interfaces;
using System.Data.Common;
using DMSAPI.Repositories.Common;
using DMSAPI.Interfaces.Common;

namespace DMSAPI.Repositories
{
    public class RequisitionRepository : GenericRepository<Requisition>, IRequisitionRepository
    {
        public RequisitionRepository(IDBManager dbManager) : base(dbManager)
        {
        }

        public async Task<List<Requisition>> GetRequisitionList()
        {
            string query = "SELECT EMPLOYEE_ID,FIRST_NAME,LAST_NAME,EMAIL FROM EMPLOYEE";
            return await GetAllAsync(query);
        }

        public async Task<Requisition> GetRequisitionById(String reqId)
        {
            string query = $"SELECT EMPLOYEE_ID,FIRST_NAME,LAST_NAME,EMAIL FROM EMPLOYEE WHERE EMPLOYEE_ID = {reqId}";
            return await GetByIdAsync(query);
        }
    }
}
