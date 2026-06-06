using aspnet_domain.Entities;
using idobrin_aspnet_logic.DTOs;
using idobrin_aspnet_logic.DTOs.Address;
using idobrin_aspnet_logic.DTOs.Cart;
using idobrin_aspnet_logic.DTOs.Category;
using idobrin_aspnet_logic.DTOs.Country;
using idobrin_aspnet_logic.DTOs.Item;
using idobrin_aspnet_logic.DTOs.Municipality;
using idobrin_aspnet_logic.DTOs.Products;
using idobrin_aspnet_logic.DTOs.User;
using idobrin_aspnet_logic.DTOs.Wishlist;

namespace idobrin_aspnet_logic.Extensions;

public static class Dto2EntityMapping
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

    public static CountryWithMunicipalityReturn ToCountryWithMunicipalitiesEntity(this Country country)
    {
        return new CountryWithMunicipalityReturn(country.Id, country.Name, country.Municipalities.ToDtoList());
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

    #region Item
    
    public static ItemReturn ToDto(this Item item)
    {
        return new ItemReturn(item.Id, item.Quantity, item.TotalPrice, item.Product.ToDto());
    }
    
    public static IEnumerable<ItemReturn> ToDtoList(this IEnumerable<Item> items)
    {
        return items.Select(e => e.ToDto());
    }

    public static Item ToEntity(this ItemCreate item)
    {
        return new Item
        {
            ProductId = item.ProductId,
            Quantity = item.quantity,
            TotalPrice = item.TotalPrice
        };
    }
    
    #endregion

    #region Cart
    
    public static CartReturn ToDto(this Cart cart)
    {
        return new CartReturn(cart.Id, cart.TotalPrice, cart.UserId, cart.CartItems?.Select(e => e.Item?.ToDto()));
    }

    public static IEnumerable<CartReturn> ToDtoList(this IEnumerable<Cart> carts)
    {
        return carts.Select(e => e.ToDto());
    }

    public static Cart ToReturnEntity(this CartReturn cart)
    {
        return new Cart
        {
            UserId = cart.UserId,
            TotalPrice = cart.TotalPrice,
        };
    }

    public static Cart ToEntity(this CartCreate cart)
    {
        return new Cart()
        {
            UserId = cart.UserId
        };
    }
    
    #endregion

    #region User

    public static UserReturn ToDto(this User user)
    {
        return new UserReturn(user.Id, user.Username, user.PwdSalt, user.PwdHash, user.FirstName, user.LastName, user.Email, user.PhoneNumber);
    }

    public static IEnumerable<UserReturn> ToDtoList(this IEnumerable<User> users)
    {
        return users.Select(e => e.ToDto());
    }

    public static UserWithCartReturn ToUserWithCartDto(this User user)
    {
        return new UserWithCartReturn(user.Id, user.Cart?.ToDto());
    }

    public static UserWithWishlistReturn ToUserWithWishlistDto(this User user)
    {
        return new UserWithWishlistReturn(user.Id, user.Wishlist?.ToDto());
    }

    public static User ToEntity(this UserCreate user)
    {
        return new User
        {
            Username = user.Username,
            PwdSalt = user.PwdSalt,
            PwdHash = user.PwdHash,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            Email = user.Email,
        };
    }

    public static UserCreate ToCreateDto(this UserRegister user, string pwdSalt, string pwdHash)
    {
        return new UserCreate(user.Username, pwdSalt, pwdHash, user.FirstName, user.LastName, user.Email, user.PhoneNumber);
    }

    #endregion

    #region Address

    public static AddressReturn ToDto(this Address address)
    {
        return new AddressReturn(address.Id, address.AddressLine, address.PostalCode, address.MunicipalityId);
    }

    public static IEnumerable<AddressReturn> ToDtoList(this IEnumerable<Address> addresses)
    {
        return addresses.Select(e => e.ToDto());
    }

    public static Address ToEntity(this AddressCreate address)
    {
        return new Address
        {
            AddressLine = address.AddressLine,
            PostalCode = address.PostalCode,
            MunicipalityId = address.MunicipalityId,
            UserId = address.UserId,
        };
    }

    #endregion

    #region Wishlist

    public static WishlistReturn ToDto(this Wishlist wishlist)
    {
        return new WishlistReturn(wishlist.Id, wishlist.UserId, wishlist.WishlistProducts.Select(e => e.Product.ToDto()));
    }

    public static Wishlist ToEntity(this WishlistReturn wishlist)
    {
        return new Wishlist
        {
            Id = wishlist.Id,
            UserId = wishlist.UserId
        };
    }

    #endregion
}