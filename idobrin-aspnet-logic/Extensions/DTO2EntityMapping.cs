using aspnet_domain.Entities;
using idobrin_aspnet_logic.DTOs.Category;
using idobrin_aspnet_logic.DTOs.Country;
using idobrin_aspnet_logic.DTOs.Municipality;
using idobrin_aspnet_logic.DTOs.Products;

namespace idobrin_aspnet_logic.Extensions;

public static class DTO2EntityMapping
{
    #region Country
    public static CountryReturn ToDto(this Country country)
    {
        return country == null ? null : new CountryReturn(country.Id, country.Name);
    }

    public static IEnumerable<CountryReturn> ToDtoList(this IEnumerable<Country> countries)
    {
        return countries.Select(country => country.ToDto());
    }

    public static Country ToEntity(this CountryCreate country)
    {
        return new Country { Name = country.Name };
    }
    #endregion

    #region Municipality
    public static MunicipalityReturn ToDto(this Municipality municipality)
    {
        return new MunicipalityReturn(municipality.Id, municipality.Name);
    }

    public static MunicipalityReturnIncludeCountry toMunicipalityWithCountryDto(this Municipality municipality)
    {
        return new MunicipalityReturnIncludeCountry(municipality.Id, municipality.Name, municipality.Country.ToDto());
    }
    
    public static IEnumerable<MunicipalityReturn> ToDtoList(this IEnumerable<Municipality> municipalities)
    {
        return municipalities.Select(e => e.ToDto());
    }

    public static Municipality ToEntity(this MunicipalityCreate municipality)
    {
        return new Municipality { Name = municipality.Name, CountryId = municipality.CountryId };
    }
    #endregion
    
    #region Category

    public static CategoryReturn ToDto(this Category category)
    {
        return category == null ? null : new CategoryReturn(category.Id, category.Name);
    }
    
    public static IEnumerable<CategoryReturn> ToDtoList(this IEnumerable<Category> categories)
    {
        return categories == null ? null : categories.Select(e => e.ToDto());
    }

    public static CategoryWithProductsReturn ToCategoryWithProductsDto(this Category category)
    {
        var products = category.CategoryProducts?.Select(e => e.Product.ToDto());
        return category == null ? null : new CategoryWithProductsReturn(category.Id, category.Name, products);
    }

    public static Category ToEntity(this CategoryCreate category)
    {
        return new Category
        {
            Name = category.Name
        };
    }
    #endregion

    #region Product

    public static ProductReturn ToDto(this Product product)
    {
        return product == null ? null : new ProductReturn(product.Id, product.Name, product.Price);
    }
    
    public static IEnumerable<ProductReturn> ToDtoList(this IEnumerable<Product> products)
    {
        return products == null ? null : products.Select(e => e.ToDto());
    }

    public static ProductWithCategoriesReturn ToProductWithCategoriesDto(this Product product)
    {
        var categories = product.CategoryProducts?.Select(e => e.Category.ToDto());
        return product == null ? null : new ProductWithCategoriesReturn(product.Id, product.Name, product.Price, categories);
    }

    public static Product ToEntity(this ProductCreate product)
    {
        return new Product
        {
            Name = product.Name,
            Price = product.Price
        };
    }
    #endregion
}