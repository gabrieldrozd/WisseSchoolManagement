using Microsoft.AspNetCore.Mvc;
using Wisse.Common.Controllers;

namespace Wisse.Modules.Users.Api.Controllers.Base;

[ApiExplorerSettings(GroupName = UsersModule.BasePath)]
[Route(UsersModule.BasePath + "/[controller]")]
internal class ModuleController : BaseController
{
}