using aspnet_domain.Interfaces;
using idobrin_aspnet_api.Security;
using idobrin_aspnet_logic.DTOs.User;
using idobrin_aspnet_logic.Extensions;
using idobrin_aspnet_logic.Interfaces;
using NSubstitute;

namespace idobrin_aspnet_test;

public class Tests
{
    private IUserService mockUserService;
    
    [SetUp]
    public void Setup()
    {
        // Arrange
        mockUserService = Substitute.For<IUserService>();
    }

    // [Test]
    // public async Task CheckPassword_ShouldNotBeEmpty()
    // {
    //     // Assert
    //     var username = Guid.NewGuid().ToString();
    //     var testUser = new UserRegister
    //     {
    //         Username = username,
    //         Password = "",
    //         FirstName = "FirstName",
    //         LastName = "LastName",
    //         PhoneNumber = "",
    //         Email = "",
    //     };
    //     
    //     // Act
    //     var b64salt = PasswordHashProvider.GetSalt();
    //     var b64hash = PasswordHashProvider.GetHash(testUser.Password, b64salt);
    //
    //     // Create user
    //     var entity = testUser.ToCreateDto(b64salt, b64hash, 1);
    //     var result = await mockUserService.CreateAsync(entity);
    //     
    //     // Assert
    //     Assert.That(result, Is.Not.EqualTo(null));
    // }
    
    [Test]
    public void CheckUsername_ShouldReturnNull_WhenUsernameIsEmpty()
    {
        // ### Arrange ###
        var password = Guid.NewGuid().ToString();
        var testUser = new UserRegister
        {
            Username = "",
            Password = password,
            FirstName = "FirstName",
            LastName = "LastName",
            PhoneNumber = "",
            Email = "",
        };
        
        // Hash the password
        var b64salt = PasswordHashProvider.GetSalt();
        var b64hash = PasswordHashProvider.GetHash(testUser.Password, b64salt);

        // Create user
        var entity = testUser.ToCreateDto(b64salt, b64hash, 1);
        
        // ### Act ###
        var result = mockUserService.CreateAsync(entity).Result;
        
        // ### Assert ###
        Assert.That(result, Is.EqualTo(null));
    }

    [Test]
    public void CheckUsername_ShouldReturnNull_WhenUsernameIsTaken()
    {
        // ### Arrange ###
        // User 'johnny' exists, attempt to add a new one
        var password = Guid.NewGuid().ToString();
        var testUser = new UserRegister
        {
            Username = "johnny",
            Password = password,
            FirstName = "FirstName",
            LastName = "LastName",
            PhoneNumber = "",
            Email = "",
        };
        
        // Hash the password
        var b64salt = PasswordHashProvider.GetSalt();
        var b64hash = PasswordHashProvider.GetHash(testUser.Password, b64salt);

        // Create user
        var entity = testUser.ToCreateDto(b64salt, b64hash, 1);
        
        // ### Act ###
        var result = mockUserService.CreateAsync(entity).Result;
        
        // ### Assert ###
        Assert.That(result, Is.EqualTo(null));
    }
    
    [Test]
    public void CheckUsername_ShouldReturnFalse_WhenUsernameIsTaken()
    {
        // ### Arrange ###
        // User 'johnny1234', id 3 should not be able to update their username to 'johnny', id 2
        var testUser = new UserUpdate(3, "johnny", "FirstName", "LastName", "", "");
        
        // ## Act ###
        var result = mockUserService.UpdateAsync(testUser.Id, testUser).Result;
        
        // ### Assert ###
        Assert.That(result, Is.False);
    }
}