using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;


namespace OSRRKAYP.WebApplication.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        public async Task<IActionResult> CerrarSesion(string? pReturnUrl = null)
        {
            await HttpContext.SignOutAsync
                (CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login
            (GetUserAuthenticatedQuery getUserAuthenticatedQuery)
        {
            try
            {
                var userResponse = await _mediator
                    .Send(getUserAuthenticatedQuery);

                if (userResponse != null &&
                    userResponse.UserNickname ==
                    getUserAuthenticatedQuery.UserName)
                {
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name,
                            userResponse.UserName),
                        new Claim("Id", userResponse.UserId.ToString())
                    };

                    var identity = new ClaimsIdentity
                        (claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync
                    (
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(identity),
                        new AuthenticationProperties
                        {
                            IsPersistent = true
                        }
                    );

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    throw new Exception("Credenciales incorrectas");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(getUserAuthenticatedQuery);
            }
        }

        public async Task<IActionResult> Index()
        {
            var users = await _mediator.Send(new GetUsersQuery());
            return View(users);
        }

        public async Task<IActionResult> Create()
        {
            var roles = await _mediator.Send(new GetRolesQuery());

            ViewData["RolId"] =
                new SelectList(roles, "RolId", "RolName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create
            (CreateUserRequest createUserRequest)
        {
            try
            {
                var result = await _mediator
                    .Send(new CreateUserCommand(createUserRequest));

                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    throw new Exception
                        ("Sucedió un error al guardar el usuario");
                }
            }
            catch (Exception ex)
            {
                var roles = await _mediator.Send(new GetRolesQuery());

                ViewData["RolId"] =
                    new SelectList(roles, "RolId", "RolName");

                ModelState.AddModelError("", ex.Message);

                return View(createUserRequest);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var user = await _mediator.Send(new GetUserQuery(id));

            var roles = await _mediator.Send(new GetRolesQuery());

            ViewData["RolId"] =
                new SelectList(roles, "RolId", "RolName", user.RolId);

            return View(user.Adapt(new UpdateUserRequest()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit
            (UpdateUserRequest updateUserRequest)
        {
            try
            {
                var result = await _mediator
                    .Send(new UpdateUserCommand(updateUserRequest));

                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    throw new Exception
                        ("Sucedió un error al editar el usuario");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                var roles = await _mediator.Send(new GetRolesQuery());

                ViewData["RolId"] =
                    new SelectList
                    (
                        roles,
                        "RolId",
                        "RolName",
                        updateUserRequest.RolId
                    );

                return View(updateUserRequest);
            }
        }
    }
}