using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class SupplierDAL : BaseDAL
    {
        public void AddSupplier(Supplier s)
        {
            Db.Supplier.AddObject(s);
            Save();
        }

        public List<Supplier> GetSupplierList()
        {
            return Db.Supplier.ToList();
        }

        public void DeleteSupplier(int id)
        {
            var sp = Db.Supplier.SingleOrDefault(s => s.Supplier_Id == id);
            Db.Supplier.DeleteObject(sp);
            Save();
        }

        public Supplier GetSupplierById(int id)
        {
            return Db.Supplier.SingleOrDefault(s => s.Supplier_Id == id);
        }
    }
}
