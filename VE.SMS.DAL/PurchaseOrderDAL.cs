using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class PurchaseOrderDAL : BaseDAL
    {
        public void Delete(int id)
        {
            var po = GetPOById(id); ;
            po.IsActive = false;
            Save();
        }

        public PurchaseOrder GetPOById(int id)
        {
            return Db.PurchaseOrder.SingleOrDefault(p => p.Purchase_Id == id);
        }

        public PurchaseOrder GetPOByNo(string no)
        {
            return Db.PurchaseOrder.SingleOrDefault(p => p.Purchase_No == no);
        }

        public void AddPO(PurchaseOrder po)
        {
            po.IsActive = true;
            Db.PurchaseOrder.AddObject(po);
        }

        public List<PurchaseOrder> GetPOBySource(string sourceType, string sourceNo)
        {
            return Db.PurchaseOrder.Where(p => p.SourceType == sourceType && p.SourceNo == sourceNo && p.IsActive == true).ToList();
        }

        public List<PurchaseOrder> SearchPO(string poNo,
            string status,
            string enqOrdMan,
            string machCreateMan,
            string purchaseMan,
            string applyPurchaseMan,
            string machTableMan,
            string approveMan,
            DateTime beginDate,
            DateTime endDate)
        {
            var result = from p in Db.PurchaseOrder
                         where
                         (
                         p.Purchase_No == poNo
                         ||
                         string.IsNullOrEmpty(poNo)
                         )
                         &&
                         (
                         p.Status == status
                         ||
                         string.IsNullOrEmpty(status)
                         )
                         &&
                         (
                         p.EnqOrdMan == enqOrdMan
                         ||
                         string.IsNullOrEmpty(enqOrdMan)
                         )
                         &&
                         (
                         p.MachiningCreateMan == machCreateMan
                         ||
                         string.IsNullOrEmpty(machCreateMan)
                         )
                         &&
                         (
                         p.PurchaseMan == purchaseMan
                         ||
                         string.IsNullOrEmpty(purchaseMan)
                         )
                         &&
                         (
                         p.PurchaseApplyMan == applyPurchaseMan
                         ||
                         string.IsNullOrEmpty(applyPurchaseMan)
                         )
                         &&
                         (
                         p.MachTableCreateMan == machTableMan
                         ||
                         string.IsNullOrEmpty(machTableMan)
                         )
                         &&
                         (
                         p.ApproveMan == approveMan
                         ||
                         string.IsNullOrEmpty(approveMan)
                         )
                        &&
                         (
                         p.CreatedDate >= beginDate
                         &&
                         p.CreatedDate <= endDate
                         )
                         &&
                         p.IsActive == true
                         select p;
            return result.ToList();
        }
    }
}
