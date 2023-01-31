using Microsoft.AspNetCore.Mvc;
using Wisse.Common.Controllers;

namespace Wisse.Modules.Enrollments.Api.Controllers.Base;

[ApiExplorerSettings(GroupName = EnrollmentsModule.BasePath)]
[Route(EnrollmentsModule.BasePath + "/[controller]")]
internal class ModuleController : BaseController
{
}