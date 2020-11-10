using API.Core.DbModels;
using API.Core.Interfaces;
using API.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Infrastructure.Implements
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get Id Product List
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p=>p.ProductBrand)
                .Include(p=>p.ProductType)
                .FirstOrDefaultAsync(p=>p.Id == id);
        }

        /// <summary>
        /// Get All Product List
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<Product>> GetProductAsync()
        {
            return await _context.Products
                .Include(p => p.ProductBrand)
                .Include(p=>p.ProductType)
                .ToListAsync();
        }

        /// <summary>
        /// Get All Product Type List
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        /// <summary>
        /// Get All Product Brand List
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }


        //Dependency Injection
        //Somutluktan uzaklasıp işi soyutlaştırmak için bize yaklaşımı sağlıyacak bir özellik.

    }
}
