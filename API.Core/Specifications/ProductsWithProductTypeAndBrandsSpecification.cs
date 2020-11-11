using API.Core.DbModels;

namespace API.Core.Specifications
{
    public class ProductsWithProductTypeAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithProductTypeAndBrandsSpecification(string sort, int? brandId, int? typeId) : base(x =>
            (!brandId.HasValue || x.ProductBrandId == brandId)
        &&
        (!typeId.HasValue || x.ProductTypeId == typeId)
        )
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);

            if (!string.IsNullOrWhiteSpace(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }

        public ProductsWithProductTypeAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}
