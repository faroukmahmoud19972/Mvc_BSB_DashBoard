using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcDemo4.BL.Models;
using MvcDemo4.DAL.Extend;

namespace MvcDemo4.Controllers
{
    public class AccountController : Controller
    {
        #region fields


        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;




        #endregion

        #region Constructor

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        #endregion

        #region Actions

        #region Index
        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region Registration (SignUp)
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser()
                    {
                        Email = model.Email,
                        UserName = model.Email,
                        IsAgree = model.IsAgree
                    };
                    var result = await userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");

                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);


                        }


                    }

                }
                return View(model);


            }
            catch (Exception ex)
            {

                return View(model);
            }

        }

        #endregion

        #region Login (Signin)
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid UserName Or Password");

                    }

                }
                return View(model);


            }
            catch (Exception ex)
            {

                return View(model);
            }

        }
        #endregion


        #region LogOff

        public async Task<IActionResult> LogOff()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }

        #endregion

        #region ForgetPassword
        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        //[HttpPost]
        //public async Task< IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            //get user
        //            var user = await userManager.FindByEmailAsync(model.Email);

        //            if (user != null)
        //            {
        //                // genrate token

        //                var token = await userManager.GeneratePasswordResetTokenAsync(user);

        //                //genrate reset linnk :

        //                var passwordResetLink = Url.Action("ResetPassword", "Account", new { Email = model.Email, Token = token }, Request.Scheme);

        //                MailSender.Mail("Password Reset", passwordResetLink);

        //                //logger.Log(LogLevel.Warning, passwordResetLink);

        //                return RedirectToAction("ConfirmForgetPassword");
        //            }

        //            return RedirectToAction("ConfirmForgetPassword");

        //        }
        //        return View(model);


        //    }
        //    catch (Exception ex)
        //    {

        //        return View(model);
        //    }
        //}

        #endregion

        #region ResetPassword
        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                }
                return View(model);


            }
            catch (Exception ex)
            {

                return View(model);
            }
        }

        #endregion

        #region ConfirmForgetPassword

        public IActionResult ConfirmForgetPassword()
        {
            return View();
        }

        #endregion

        #region ConfirmResetPassword

        public IActionResult ConfirmResetPassword()
        {
            return View();
        }

        #endregion

        #endregion

    }
}




