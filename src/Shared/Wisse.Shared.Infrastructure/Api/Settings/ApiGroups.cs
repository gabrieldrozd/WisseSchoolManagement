namespace Wisse.Shared.Infrastructure.Api.Settings;

public static class ApiGroups
{
    public const string Enrollments = "enrollments-module";
    public const string Users = "users-module";

    public static IDictionary<string, string> GetNameValueDictionary()
    {
        var nameValue = new Dictionary<string, string>();

        object structValue = default(ApiGroups);

        foreach (var group in typeof(ApiGroups).GetFields())
        {
            var value = group.GetValue(structValue).ToString();
            var name = group.Name;
            nameValue.Add(name, value);
        }

        return nameValue;
    }
}
