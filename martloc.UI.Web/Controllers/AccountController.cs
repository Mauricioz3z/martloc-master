
using martloc.ApplicationCore.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace martloc.UI.Web.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<Usuario> _userManager { get; }
        private SignInManager<Usuario> _signInManager { get; }
        private readonly IEmailSender _emailSender;

        public AccountController(UserManager<Usuario> UserManager, SignInManager<Usuario> SignInManager, IEmailSender EmailSender)
        {
            _userManager = UserManager;
            _signInManager = SignInManager;
            _emailSender = EmailSender;

        }


        [BindProperty]
        public InputModel Input { get; set; }

        [BindProperty]
        public InputModelLogin InputLogin { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Informe o campo E-mail")]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Informe o campo senha")]
            [StringLength(100, ErrorMessage = "O campo {0} deve ter ao menos {2} e no máximo  {1} characteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Senha")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirme a Senha")]
            [Compare("Password", ErrorMessage = "As senhas não combinam.")]
            public string ConfirmPassword { get; set; }
        }


        public class InputModelLogin
        {
            [Required(ErrorMessage = "Informe o campo E-mail")]
            [EmailAddress]
         
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Informe o campo senha")]
            [DataType(DataType.Password)]
            [Display(Name = "Senha")]
            public string Password { get; set; }


        }



        [HttpGet]
        public IActionResult Register() {


            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(string returnUrl)
        {
         
            returnUrl ??= Url.Content("~/");
           
            if (ModelState.IsValid)
            {
                var user = new Usuario { UserName = Input.Email, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> Login(string returnUrl)
        {




            ModelState.Clear();


            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(InputLogin.Email, InputLogin.Password, false, false);


                if (result.Succeeded)
                {
                    if (returnUrl == null)
                        return LocalRedirect("/Home");
                    else
                        return LocalRedirect(returnUrl);
                }
                else
                {
                    ViewBag.Email = InputLogin.Email;
                    ModelState.AddModelError("erro", "Usuário ou senha incorretos!");
                   
                }
            }
            return View();




          

        }



        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Proibido()
        {

            return View();
        }


       

        public IActionResult Logout()
        {


            _signInManager.SignOutAsync();
            return LocalRedirect("/Home");
        }

    }
}