using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ui.EmailService;
using Microsoft.AspNetCore.Mvc;
using business.Abstract;
using ui.Extensions;
using ui.Identity;
using ui.Models;
using Newtonsoft.Json;

namespace ui.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
         private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private IEmailSender _emailSender;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }
        public IActionResult Register()
        {
            ViewBag.register = "active";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            ViewBag.register = "active";
            if (!ModelState.IsValid || !model.emailValidate() )
            {
                ModelState.AddModelError("", "Girdiğiniz bilgiler kriterlere uymuyor!");
                return View(model);
            }

            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user,"Müşteri");
                // generate token
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Action("ConfirmEmail", "Account", new
                {
                    userId = user.Id,
                    token = code
                });

                // send email
                try
                {
                    await _emailSender.SendEmailAsync(model.Email, "Hesabınızı Onaylayınız.", $"Lütfen email hesabınızı onaylamak için linke <a href='http://localhost:5000{callbackUrl}'>tıklayınız.</a>");
                    TempData.Put("message",new AlertType(){
                        Title = "Kayıt başarılı.Hesabınızı Onaylayınız",
                        Message = "Eposta adrenize gelen link ile hesabınızı onaylayınız",
                        Alert="success"
                    }
                    );
                    return RedirectToAction("Login", "Account");
                }
                catch (System.Exception)
                {
                     TempData.Put("message",new AlertType(){
                        Title = "Email adresi hatalı!",
                        Message = "Bu email adresi yanlış! Lütfen geçerli bir adres girin",
                        Alert="warning"
                    }
                    );

                    return View(model);
                    
                }
                
            }
            TempData.Put("message",new AlertType(){
                        Title = "Bir hata oluştu",
                        Message = "Girdiğiniz e-mail zaten kullanımda veya şifreniz kriterlere uymuyor olabilir!",
                        Alert="warning"
                    }
                );
            return View(model);
        }


        public IActionResult Login(string ReturnUrl = null)
        {
            ViewBag.login  = "active";
            return View(new LoginModel()
            {
                ReturnUrl = ReturnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            ViewBag.login  = "active";
            if (!ModelState.IsValid)
            {
                TempData.Put("message",new AlertType(){
                        Title = "Bilgiler Hatalı!",
                        Alert="warning"
                    }
                );
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null )
            {
                TempData.Put("message",new AlertType(){
                        Title = "Email adresi hatalı!",
                        Message = "Bu email adresi yanlış! Lütfen geçerli bir adres girin",
                        Alert="warning"
                    }
                );
                return View(model);
            }

            /*if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                TempData.Put("message",new AlertType(){
                        Title = "Hesabınız henüz onaylanmamış!",
                        Message = "Bu hesap henüz onaylanmadı! Lütfen emailinizi kontrol ediniz",
                        Alert="warning"
                    }
                );
                return View(model);
            }*/


            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

            if (result.Succeeded)
            {
                TempData.Put("message",new AlertType(){
                        Title = "Hoşgeldiniz",
                        Alert="success"
                    }
                );
                return Redirect(model.ReturnUrl ?? "~/");
            }

            ModelState.AddModelError("", "Parola yanlış!");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData.Put("message",new AlertType(){
                        Title = "Oturumunuz kapatıldı!",
                        Message = "Oturumunuz güvenli bir şekilde sonlandırıldı",
                        Alert="success"
                    }
                );
            return Redirect("~/");
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                TempData.Put("message",new AlertType(){
                        Title = "Hata!",
                        Message = "Bir hata oluştu.Hesap onayı yapılamıyor",
                        Alert="danger"
                    }
                );

                return Redirect("~/");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    TempData.Put("message",new AlertType(){
                        Title = "Hata!",
                        Message = "Hesabınız başarıyla onaylanmıştır.",
                        Alert="success"
                    }
                    );
                    return RedirectToAction("Login");
                }
            }
            TempData.Put("message",new AlertType(){
                Title = "Hata!",
                Message = "Hesabınız onaylanamadı.",
                Alert="danger"
                }
            );
            return View();
        }

        public IActionResult ForgotPassword()
        {
            ViewBag.login  = "active";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string Email)
        {
            ViewBag.login  = "active";
            if (string.IsNullOrEmpty(Email))
            {
                TempData.Put("message",new AlertType(){
                Title = "Hata!",
                Message = "Bilgileriniz Hatalı.",
                Alert="danger"
                }
            );
              
                return View();
            }

            var user = await _userManager.FindByEmailAsync(Email);

            if (user == null)
            {
                 TempData.Put("message",new AlertType(){
                    Title = "Hata!",
                    Message = "Bu e-posta adresi ile bir kullanıcı bulunamadı",
                    Alert="danger"
                    }
                );

                return View();
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var callbackUrl = Url.Action("ResetPassword", "Account", new
            {
                token = code
            });

            // send email
            await _emailSender.SendEmailAsync(Email, "Reset Password", $"Parolanızı yenilemek için linke <a href='http://localhost:5000{callbackUrl}'>tıklayınız.</a>");
             TempData.Put("message",new AlertType(){
                    Title = "Parola yenileme maili",
                    Message = "Parola yenilemek için hesabınıza mail gönderildi.Lütfen kontrol ediniz",
                    Alert="success"
                    }
                );
            return RedirectToAction("Login", "Account");
        }


        public IActionResult ResetPassword(string token)
        {
            ViewBag.login  = "active";
            if (token == null)
            {
                TempData.Put("message",new AlertType(){
                    Title = "Hata",
                    Message = "Bir hata oluştu! Tekrar deneyin.",
                    Alert="danger"
                    }
                );
                return RedirectToAction("Home", "Index");
            }
            var model = new ResetPasswordModel { Token = token };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            ViewBag.login  = "active";
            if (!ModelState.IsValid)
            {
                TempData.Put("message",new AlertType(){
                    Title = "Hata",
                    Message = "Girdiğiniz bilgiler kriterlere uymuyor!",
                    Alert="warning"
                    }
                );
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user==null)
            {
                 TempData.Put("message",new AlertType(){
                    Title = "Hata",
                    Message = "Bir hata oluştu! Tekrar deneyin.",
                    Alert="danger"
                    }
                );
                return RedirectToAction("Home", "Index");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

            if (result.Succeeded)
            {
                TempData.Put("message",new AlertType(){
                    Title = "Şifreniz başarıyla değiştirildi",
                    Message = "Şifreniz başarıyla değiştirildi. Lütfen yeniden giriş yapın.",
                    Alert="success"
                    }
                );
                return RedirectToAction("Login", "Account");
            }
            return View(model);
        }

        public IActionResult Accessdenied()
        {
            return View();
        }

    }
    
}