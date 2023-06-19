using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TechStore.UI.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public void OnGet()
        {
            ReturnUrl = Url.Content("~/");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ReturnUrl = Url.Content("~/");

            if (ModelState.IsValid)
            {
                var identity = new IdentityUser { UserName = Input.Email, Email = Input.Email };
                var result = await _userManager.CreateAsync(identity, Input.Password);
                var confirmPass = await _userManager.CheckPasswordAsync(identity, Input.ConfirmPassword);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(identity, "User");

                    if (identity.Email.StartsWith("admin"))
                        await _userManager.AddToRoleAsync(identity, "Admin");

                    await _signInManager.SignInAsync(identity, isPersistent: false);

                    return LocalRedirect(ReturnUrl);
                }
            }

            return Page();
        }

        public class InputModel
        {
            [Required(ErrorMessage = "Enter your E-mail address")]
            [EmailAddress]
            public string Email { get; set; }

            [Required(ErrorMessage = "Choose your password")]
            [MinLength(4, ErrorMessage = "Password must be at least 4 digits")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [Compare("Password", ErrorMessage = "Passwords must match")]
            [Display(Name = "Confirm Password")]
            [DataType(DataType.Password)]
            public string ConfirmPassword { get; set; }
        }
    }
}