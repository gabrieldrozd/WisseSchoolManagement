using Wisse.Base.Types;

namespace Wisse.Common.Auth;

public class UserPermission : PairEnumeration<UserPermission>
{
    /// <summary>
    /// Permission to create a resource.
    /// <remarks>Allows the user to create new data or resources within the application.</remarks>
    /// </summary>
    public static readonly UserPermission Create = CreatePermission();

    /// <summary>
    /// Permission to read a resource.
    /// <remarks>Allows the user to view data or resources within the application.</remarks>
    /// </summary>
    public static readonly UserPermission Read = ReadPermission();

    /// <summary>
    /// Permission to update a resource.
    /// <remarks>Allows the user to modify existing data or resources within the application.</remarks>
    /// </summary>
    public static readonly UserPermission Update = UpdatePermission();

    /// <summary>
    /// Permission to delete a resource.
    /// <remarks>Allows the user to remove data or resources within the application.</remarks>
    /// </summary>
    public static readonly UserPermission Delete = DeletePermission();

    /// <summary>
    /// Permission to publish a resource.
    /// <remarks>Allows the user to publish data or resources within the application, making them visible to others.</remarks>
    /// </summary>
    public static readonly UserPermission Publish = PublishPermission();

    /// <summary>
    /// Permission to manage a resource.
    /// <remarks>Allows the user to manage data or resources within the application, including approving, denying etc.</remarks>
    /// </summary>
    public static readonly UserPermission Manage = ManagePermission();

    /// <summary>
    /// Permission to execute a resource.
    /// <remarks>Allows the user to perform specific actions within the application, such as running a test.</remarks>
    /// </summary>
    public static readonly UserPermission Execute = ExecutePermission();

    /// <summary>
    /// Permission to administer a resource.
    /// <remarks>Allows the user to manage the permissions of other users within the application,
    /// including granting and revoking permissions.</remarks>
    /// </summary>
    public static readonly UserPermission Administer = AdministerPermission();

    /// <summary>
    /// Standard permissions for an Admin.
    /// <remarks></remarks>
    /// </summary>
    public static readonly UserPermission[] AdminPermissions = { Create, Read, Update, Delete, Publish, Manage, Execute, Administer };

    /// <summary>
    /// Standard permissions for a Student.
    /// <remarks></remarks>
    /// </summary>
    public static readonly UserPermission[] StudentPermissions = { Create, Read, Update, Execute };

    /// <summary>
    /// Standard permissions for a Teacher.
    /// <remarks></remarks>
    /// </summary>
    public static readonly UserPermission[] TeacherPermissions = { Create, Read, Update, Delete, Publish, Execute };

    private UserPermission(string key, string name) : base(key, name)
    {
    }

    public static UserPermission TryGetPermission(string value)
    {
        UserPermission permission;

        if (FromKey(value) is not null)
        {
            permission = FromKey(value);
        }
        else if (FromName(value) is not null)
        {
            permission = FromName(value);
        }
        else
        {
            return null;
        }

        return permission;
    }

    private static UserPermission CreatePermission() => new("create", "CREATE");

    private static UserPermission ReadPermission() => new("read", "READ");

    private static UserPermission UpdatePermission() => new("update", "UPDATE");

    private static UserPermission DeletePermission() => new("delete", "DELETE");

    private static UserPermission PublishPermission() => new("publish", "PUBLISH");

    private static UserPermission ManagePermission() => new("manage", "MANAGE");

    private static UserPermission ExecutePermission() => new("execute", "EXECUTE");

    private static UserPermission AdministerPermission() => new("administer", "ADMINISTER");
}