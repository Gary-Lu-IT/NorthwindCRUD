using NorthwindControl.Models.ClientModel;
using NorthwindControl.Models.DBEntity;

namespace NorthwindControl.Services
{
    /// <summary>供應商存取服務</summary>
    public class SvcSupplier
    {
        /// <summary>新增供應商</summary>
        /// <param name="supplier">供應商</param>
        public void AddSupplier(ClsSupplier supplier)
        {
            NorthwindContext db = new();
            db.Suppliers.Add(new Suppliers
            {
                CompanyName = supplier.Name,
                ContactName = supplier.ContactName,
                ContactTitle = supplier.ContactTitle,
                City = supplier.City,
                Region = supplier.Region,
                Address = supplier.Address,
                Country = supplier.Country,
                PostalCode = supplier.PostalCode,
                Phone = supplier.Phone,
                Fax = supplier.Fax,
                HomePage = supplier.Homepage
            });
            db.SaveChanges();
        }
        /// <summary>查詢供應商</summary>
        /// <param name="cond">條件</param>
        /// <returns></returns>
        public List<ClsSupplier> QuerySupplier(ClsSupplier cond)
        {
            NorthwindContext db = new();
            IQueryable<Suppliers> query = db.Suppliers.AsQueryable();
            if (!string.IsNullOrEmpty(cond.Name))
            {
                query = query.Where(x => x.CompanyName.Contains(cond.Name));
            }
            if (!string.IsNullOrEmpty(cond.ContactName))
            {
                query = query.Where(x => x.ContactName != null && x.ContactName.Contains(cond.ContactName));
            }
            if (!string.IsNullOrEmpty(cond.ContactTitle))
            {
                query = query.Where(x => x.ContactTitle != null && x.ContactTitle.Contains(cond.ContactTitle));
            }
            if (!string.IsNullOrEmpty(cond.City))
            {
                query = query.Where(x => x.City == cond.City);
            }
            if (!string.IsNullOrEmpty(cond.Country))
            {
                query = query.Where(x => x.Country == cond.Country);
            }
            if (!string.IsNullOrEmpty(cond.Region))
            {
                query = query.Where(x => x.Region == cond.Region);
            }
            return query.Select(x => new ClsSupplier
            {
                id = x.SupplierID,
                Name = x.CompanyName,
                ContactName = x.ContactName,
                ContactTitle = x.ContactTitle,
                Country = x.Country,
                City = x.City,
                Region = x.Region,
                Address = x.Address,
                Fax = x.Fax,
                Phone = x.Phone,
                PostalCode = x.PostalCode,
                Homepage = x.HomePage
            }).ToList();
        }
        /// <summary>由供應商編號取得資料</summary>
        /// <param name="SupplierId"></param>
        /// <returns></returns>
        public ClsSupplier? GetSupplier(int SupplierId)
        {
            NorthwindContext db = new();
            return db.Suppliers.Where(x => x.SupplierID == SupplierId).Select(x => new ClsSupplier
            {
                id = x.SupplierID,
                Name = x.CompanyName,
                ContactName = x.ContactName,
                ContactTitle = x.ContactTitle,
                Country = x.Country,
                City = x.City,
                Region = x.Region,
                Address = x.Address,
                Fax = x.Fax,
                Phone = x.Phone,
                PostalCode = x.PostalCode,
                Homepage = x.HomePage
            }).FirstOrDefault();
        }
        /// <summary>更新供應商</summary>
        /// <param name="supplier"></param>
        public void UpdateSupplier(ClsSupplier supplier)
        {
            NorthwindContext db = new();
            Suppliers? s = db.Suppliers.Where(x => x.SupplierID == supplier.id).FirstOrDefault();
            if (s != null)
            {
                s.CompanyName = supplier.Name;
                s.ContactName = supplier.ContactName;
                s.ContactTitle = supplier.ContactTitle;
                s.Country = supplier.Country;
                s.City = supplier.City;
                s.Region = supplier.Region;
                s.Address = supplier.Address;
                s.Fax = supplier.Fax;
                s.Phone = supplier.Phone;
                s.PostalCode = supplier.PostalCode;
                s.HomePage = supplier.Homepage;
                db.SaveChanges();
            }
            else
            {
                throw new ArgumentException("供應商編號(" + supplier.id.ToString() + ")不存在");
            }
        }
        /// <summary>刪除供應商</summary>
        /// <param name="supplierid"></param>
        public void DeleteSupplier(int supplierid)
        {
            NorthwindContext db = new();
            Suppliers? s = db.Suppliers.Where(x => x.SupplierID == supplierid).FirstOrDefault();
            if (s != null)
            {
                db.Suppliers.Remove(s);
                db.SaveChanges();
            }
            else
            {
                throw new ArgumentException("供應商編號(" + supplierid.ToString() + ")不存在");
            }
        }
    }
}
