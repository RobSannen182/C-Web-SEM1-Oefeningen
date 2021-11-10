using MVCSportStore.Data;
using MVCSportStore.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSportStore.Models
{
    public class ProductRepository
    {
        StoreDbContext _context;
        public ProductRepository(StoreDbContext context)
        {
            _context = context;
        }

        public ProductsList GetProductsList(int productPage, string category)
        {
            var pl = new ProductsList();
            pl.Products = GetProducts(productPage, category);
            pl.PagingInfo = GetPagingInfo(productPage, category);
            return pl;
        }

        private IEnumerable<Product> GetProducts(int productPage, string category)
        {
            return _context.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductId)
                .Skip((productPage - 1) * PagingSettings.ProductPagination)
                .Take(PagingSettings.ProductPagination);
        }

        private PagingInfo GetPagingInfo(int productPage, string category)
        {
            var pagingInfo = new PagingInfo();
            pagingInfo.CurrentPage = productPage;
            pagingInfo.ItemsPerPage = PagingSettings.ProductPagination;
            pagingInfo.totalItems = (category == null)
                ? _context.Products.Count()
                : _context.Products.Where(e => e.Category == category).Count();
            return pagingInfo;
        }
    }
}
