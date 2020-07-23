using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class Login : Controller
    {

        private IConfiguration _iconfiguration;
        public Login(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ActivateSuccess()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult NewPassword(UserLogin userForm)
        {
            Boolean successPass = false;
            MySqlDatabase msDB = new MySqlDatabase();
            ClaimsPrincipal cp = this.User;

            String cpMail = cp.FindFirst(ClaimTypes.Email).Value;
            String cpPass = userForm.Password;

            successPass = msDB.NewPassword(cpMail, cpPass);
            if(successPass)
            {
                TempData["newPassInfo"] = "success";
                return View("Index");
            }
            else
            {
                TempData["newPassInfo"] = "error";
                return View("Index");

            }
            return View();
        }

        public IActionResult ActivateAccount()
        {
            /*ClaimsPrincipal cp = this.User;
            String cDisplayName = cp.FindFirst(ClaimTypes.Email).Value;*/
            return View();
        }

        public IActionResult UserVerification(string GetCrypto,string M)
        {
            string decryptedstring = SimplerAES.Decrypt(GetCrypto);
            if (decryptedstring == M)
            {
                var userClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, M)
                };

                var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("ActivateAccount", "Login");
            }
            else

                return View("Index");
        }

        public IActionResult SendMail(MailData em)
        {
            // Mail send section
            string to = em.To;
            string subject = em.Subject;
            MailMessage mm = new MailMessage();

            StringBuilder mailBody = new StringBuilder();
            ListDictionary replacements = new ListDictionary();

            replacements.Add("{hashlink}", GetHashString(to));

            string encryptedstring = SimplerAES.Encrypt(to);

            string appUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            string verifyUrl = appUrl + "/Login/UserVerification?GetCrypto="+ encryptedstring + "&M="+to;

            string body = "<div style='font-family:Arial,sans-serif;height:100%;margin:0;padding:0;min-width:100%;width:100%!important;word-break:break-word;background-color:#ffffff'>" +
                "<center style='font-family:Arial,sans-serif'>" +
                "<img src='./Fwd_ Welcome to STC Digital Securities Transfer Platform - uguraras24@gmail.com - Gmail_files/bhEjQ3CuIzwtd2NcRgHo6egDVx84yjhji4_XmrJd_4UKMeRSYSlUXEpxRA8IOzSNaL6s7CrVEJQQ1ztfFGsVG4KYqQE4aw=s0-d-e1-ft' alt='STC Digital Securities' style='font-family:Arial,sans-serif;border:0;border-radius:0.2em;width:10%;min-width:40px;max-width:80px class='CToWUd'>" +
                "<table style='font-family:Arial,sans-serif;width:98%;background-color:#ffffff;border:0.05em #dce1e6 solid;border-bottom:0;border-radius:0.2em;border-spacing:0;margin:1%;padding:2%;max-width:800px;min-width:320px'>" +
                "<tbody>" +
                "<tr style='padding:0'>" +
                "<td align='center' style = 'font-family:Arial,sans-serif;padding:1.3em .65em'>" +
                "<table cellpadding='0' cellspacing='0' border='0' style='font-family:Arial,sans-serif;width:100%'>" +
                "<tbody>" +
                "<tr style='padding:0'>" +
                "<td align='center' style='font-family:Arial,sans-serif;padding:1.3em .65em'>" +
                "<h1 style='font-family:Arial,sans-serif;font-size:2em;font-weight:normal;color:#021d49'>Verify your email address</h1>" +
                "<h1 style='font-family:Arial,sans-serif;font-size:2em;font-weight:normal;color:#021d49'>Dear {email}</h1>" +
                "<hr style='font-family:Arial,sans-serif;border:0.03em #b8c2cc solid;max-width:50%'>" +
                "</td></tr></tbody></table>" +
                "<p style='font-family:Arial,sans-serif;font-size:1em;font-weight:normal;line-height:2em;color:#021d49'>" +
                "In order to get started, you need to verify your email address.<br>" +
                "Please click the button below to activate your account." +
                "</p><table cellpadding='0' cellspacing='0' border='0' style='font-family:Arial,sans-serif;width:100%'>" +
                "<tbody><tr style='padding:0'>" +
                "<td align='center' style='font-family:Arial,sans-serif;padding:1.3em .65em'>" +
                "<a href='"+ verifyUrl + "' style='font-family:Arial,sans-serif;padding:0.8em;border:0;border-radius:0.15em;color:#dde5ed;font-size:1.2em;font-weight:bold;display:inline-block;text-decoration:none;background-color:#753bbd' target='_blank' data-saferedirecturl='https://www.google.com/url?q=https://u6499205.ct.sendgrid.net/ls/click?upn%3DVUi6vtiYq6Dke21-2BFPsFP-2F0H1DarKXFNoBO3yxpk-2FutF-2FA0aFvaXu2VN8DX-2FfiEyrxjCHmfo9qPNVstwcb84hgsjdVvV2cYFTqhmh8k2uCzGiA2j7T3yv0fClUoTU4-2FKHWVY-2F1R-2BmMPK6TeLu2bLxw-3D-3Dc2Y3_p3SVlCDbKSLRLli1GKmEeVVMyM0p8JQlVUwTygYVI-2Fi29ZjgcvOzCoDXzTKic-2F92zaNoixbOAYj9pkKW8piaz8nU3fVvPwxsGyBRsRIm4uwBIzZjKicUYgKN0vFSqBnssNebBc3Cksd5YVE-2B-2BkqH2m6F7ZrX4As-2B-2BYB-2BSeq38jJ08clcMSvF4akmCHjz5Ci866MJCw2AKMDgHORAEilcFkIgo7M-2BiPQU7N0-2B63M-2Bp8c-3D&amp;source=gmail&amp;ust=1594995475240000&amp;usg=AFQjCNFuHxCWBKEGDICZZyCROI6SFxkf3w'>Verify my email address</a>" +
                "</td></tr></tbody></table>" +
                "<hr style='font-family:Arial,sans-serif;border:0.03em #b8c2cc solid;max-width:50%'>" +
                "<br><strong style='font-family:Arial,sans-serif;font-size:1em;font-weight:bold;color:#021d49'>Your verification key is</strong>" +
                "<table width='100%' cellpadding='0' cellspacing='0'style='font-family:Arial,sans-serif;width:100%;background-color:#dce1e6'><tbody><tr style='padding:0'>" +
                "<td align='center' style='font-family:Arial,sans-serif;padding:0'>" +
                "<p style='font-family:Arial,sans-serif;background-color:#dce1e6'></p>" +
                "<p style='font-family:Arial,sans-serif'>{hashlink}</p>" +
                "</td></tr></tbody></table>" +
                "<table cellpadding='0' cellspacing='0' border='0' style='font-family:Arial,sans-serif;width:100%'><tbody><tr style='padding:0'>" +
                "<td align='center' style='font-family:Arial,sans-serif;padding:1.3em .65em'>" +
                "<p style='font-family:Arial,sans-serif'><em style='font-family:Arial,sans-serif;font-size:0.8em;font-weight:normal;line-height:1.6em;color:#697080;font-style:normal'>If you did not sign up for this account<br>you can ignore this email and the account will be deleted.</em></p>" +
                "</td></tr></tbody></table>" +
                "<table cellpadding='0' cellspacing='0' bordVerier='0' style='font-family:Arial,sans-serif;width:100%'><tbody><tr style='padding:0'>" +
                "<td align='center' style='font-family:Arial,sans-serif;padding:1.3em .65em'>" +
                "<em style='font-family:Arial,sans-serif;font-size:0.8em;font-weight:normal;line-height:1.6em;color:#697080;font-style:normal'><a href='https://mail.google.com/mail/u/0/#m_3102665213440501867_m_-2437924468448491603_' style='font-family:Arial,sans-serif;font-size:1em;color:#753bbd;text-decoration:none'>STC Digital Securities</a><br>2901 N Dallas Parkway Suite 380<br>Plano, Texas 75093</em>" +
                "</td></tr></tbody></table>" +
                "<table cellpadding='0' cellspacing='0' border='0' style='font-family:Arial,sans-serif;width:100%'><tbody><tr style='padding:0'><td align='center' style='font-family:Arial,sans-serif;padding:1.3em .65em'>" +
                "<span style='font-family:Arial,sans-serif;color:#28334a;font-size:1.3em'>ℹ</span><em style='font-family:Arial,sans-serif;font-size:0.8em;font-weight:normal;line-height:1.6em;color:#697080;font-style:normal'>&nbsp;This email and any files and info transmitted with it are confidential and intended solely for the use of the individual or entity to whom they are addressed. Please notify the sender immediately if you have received this e-mail by mistake, then delete it.</em>" +
                "</td></tr></tbody></table></td></tr>" +
                "</tbody>" +
                "</table>" +
                "</center>" +
                "<img src='./Fwd_ Welcome to STC Digital Securities Transfer Platform - uguraras24@gmail.com - Gmail_files/unnamed.gif' alt='' width='1' height='1' border='0' style='height:1px!important;width:1px!important;border-width:0!important;margin-top:0!important;margin-bottom:0!important;margin-right:0!important;margin-left:0!important;padding-top:0!important;padding-bottom:0!important;padding-right:0!important;padding-left:0!important' class='CToWUd'></div><div class='yj6qo'></div><div class='adL'>" +
                "</div>";




            // string body = "<div><a href=''https://localhost:44321/'>https://creosafedemo/dcdsccsdvcs {hashlink}</a></div>";

            body = body.Replace("{hashlink}", GetHashString(to));
            body = body.Replace("{email}", to);



            mm.To.Add(to);
            mm.Body = body;
            mm.From = new MailAddress("uguraras24@gmail.com");
            mm.IsBodyHtml = true;
            mm.Subject = "Creosafe Mail Aktivasyonu";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("uguraras24@gmail.com", "19982929291903");
            smtp.Send(mm);
            ViewBag.message = "Bu maili " + em.To + "gönderdi  ";
            //hash1 = GetHashString(to);
            //mail1 = to;
            return View();
        }
        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }
        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        public IActionResult UserControl(UserLogin userForm)
        {
            MySqlDatabase msDB = new MySqlDatabase();
            UserLogin uLogin = msDB.userControl(userForm.Email, userForm.Password);
            msDB.Dispose();
            if (uLogin != null) 
            {
                var userClaims = new List<Claim> { };
                if (uLogin.AccountInfoEx)
                {
                    userClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, uLogin.Id.ToString()),
                        new Claim(ClaimTypes.Name, uLogin.DisplayName),
                        new Claim(ClaimTypes.Email, uLogin.Email)
                    };
                }
                else
                {
                    userClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, uLogin.Id.ToString()),
                        new Claim(ClaimTypes.Email, uLogin.Email)
                    };
                }
                
                var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                HttpContext.SignInAsync(userPrincipal);
                if(uLogin.AccountInfoEx)
                    return RedirectToAction("Index", "Home");
                else
                    return RedirectToAction("Index", "AccountInfo");
            }
            else
                return RedirectToAction("Index", "Login");

        }
    }
}
