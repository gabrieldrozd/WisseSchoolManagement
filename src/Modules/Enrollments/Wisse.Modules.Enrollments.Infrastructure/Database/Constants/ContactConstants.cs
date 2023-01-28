using Wisse.Modules.Enrollments.Domain.Entities;

namespace Wisse.Modules.Enrollments.Infrastructure.Database.Constants;

internal static class ContactConstants
{
    public const string ContactTableName = $"{nameof(Contact)}s";

    public const int EmailMaxLength = 100;
    public const int PhoneMaxLength = 20;
    public const int ZipCodeMaxLength = 20;
    public const int ZipCodeCityMaxLength = 100;
    public const int StateMaxLength = 100;
    public const int CityMaxLength = 100;
    public const int StreetMaxLength = 150;
    public const int HouseNumberMaxLength = 50;
}