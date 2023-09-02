using DMSAPI.Entities;
using DMSAPI.Interfaces;
using DMSAPI.Interfaces.Common;
using DMSAPI.Repositories.Common;
using System.Text;

namespace DMSAPI.Repositories
{
    public class PurchaseOrderRepository : GenericRepository<PurchaseOrder>, IPurchaseOrderRepository
    {

        public PurchaseOrderRepository(IDBManager dbManager) : base(dbManager)
        {
        }

        public async Task<PurchaseOrder> GetPurchaseOrderById(string poId)
        {
            string query = $"SELECT EMPLOYEE_ID,FIRST_NAME,LAST_NAME,EMAIL FROM EMPLOYEE WHERE EMPLOYEE_ID = {poId}";
            return await GetByIdAsync(query);
        }

        public async Task<List<PurchaseOrder>> GetPurchaseOrderList(String requisitionId)
        {
            StringBuilder sQuery = new StringBuilder();
            sQuery.Append("SELECT EMPLOYEE_ID,FIRST_NAME,LAST_NAME,EMAIL FROM EMPLOYEE   ");
            if (!String.IsNullOrEmpty(requisitionId))
            {
                sQuery.Append("WHERE EMPLOYEE_ID LIKE '%'" + requisitionId + "'%'");
            }

            return await GetAllAsync(sQuery.ToString());
        }
    }
}
