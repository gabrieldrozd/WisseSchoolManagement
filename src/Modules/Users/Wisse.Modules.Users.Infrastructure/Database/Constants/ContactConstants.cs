using Wisse.Modules.Users.Domain.Entities;

namespace Wisse.Modules.Users.Infrastructure.Database.Constants;

internal static class ContactConstants
{
    public const string ContactTableName = $"{nameof(Contact)}s";

    public const int ZipCodeMaxLength = 20;
    public const int ZipCodeCityMaxLength = 100;
    public const int StateMaxLength = 100;
    public const int CityMaxLength = 100;
    public const int StreetMaxLength = 150;
    public const int HouseNumberMaxLength = 50;
}