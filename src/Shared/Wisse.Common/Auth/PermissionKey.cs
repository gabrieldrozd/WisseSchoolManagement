namespace Wisse.Common.Auth;

public enum PermissionKey
{
    /// <summary>
    /// Permission to create a resource.
    /// <remarks>Allows the user to create new data or resources within the application.</remarks>
    /// </summary>
    Create,

    /// <summary>
    /// Permission to read a resource.
    /// <remarks>Allows the user to view data or resources within the application.</remarks>
    /// </summary>
    Read,

    /// <summary>
    /// Permission to update a resource.
    /// <remarks>Allows the user to modify existing data or resources within the application.</remarks>
    /// </summary>
    Update,

    /// <summary>
    /// Permission to delete a resource.
    /// <remarks>Allows the user to remove data or resources within the application.</remarks>
    /// </summary>
    Delete,

    /// <summary>
    /// Permission to publish a resource.
    /// <remarks>Allows the user to publish data or resources within the application, making them visible to others.</remarks>
    /// </summary>
    Publish,

    /// <summary>
    /// Permission to manage a resource.
    /// <remarks>Allows the user to manage data or resources within the application, including approving, denying etc.</remarks>
    /// </summary>
    Manage,

    /// <summary>
    /// Permission to execute a resource.
    /// <remarks>Allows the user to perform specific actions within the application, such as running a test.</remarks>
    /// </summary>
    Execute,

    /// <summary>
    /// Permission to administer a resource.
    /// <remarks>Allows the user to manage the permissions of other users within the application,
    /// including granting and revoking permissions.</remarks>
    /// </summary>
    Administer
}