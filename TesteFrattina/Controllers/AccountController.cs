using Microsoft.AspNetCore.Mvc;
using TesteFrattina.Models;
using System.Text.RegularExpressions;

namespace TesteFrattina.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public ActionResult<ValidationResult> ValidatePassword(PasswordRequest passwordrequest)
        {
            //Verificador de senha não nula
            var validationResult = new ValidationResult();  

            if (passwordrequest.password == null) { 
                validationResult.MensagemErro = "Senha não pode estar em branco para ser verificada";
                validationResult.IsValid = false;

                validationResult.Errors.Add(validationResult.MensagemErro);
                passwordrequest.errors = validationResult.Errors.ToArray();
                return RedirectToAction("ValidacaoResult", "Home", passwordrequest);
            }
            // Verificar se a senha possui pelo menos 9 caracteres
            if (passwordrequest.password.Length < 9)
            {
                validationResult.MensagemErro = "A senha deve ter pelo menos 9 caracteres.";
                validationResult.IsValid = false;
                validationResult.Errors.Add("A senha deve ter pelo menos 9 caracteres.");
            }

            // Verificar se a senha contém pelo menos um dígito
            if (!passwordrequest.password.Any(char.IsDigit))
            {
                validationResult.IsValid = false;
                validationResult.Errors.Add("A senha deve conter pelo menos um dígito.");
            }

            // Verificar se a senha contém pelo menos uma letra minúscula
            if (!passwordrequest.password.Any(char.IsLower))
            {
                validationResult.IsValid = false;
                validationResult.Errors.Add("A senha deve conter pelo menos uma letra minúscula.");
            }

            // Verificar se a senha contém pelo menos uma letra maiúscula
            if (!passwordrequest.password.Any(char.IsUpper))
            {
                validationResult.IsValid = false;
                validationResult.Errors.Add("A senha deve conter pelo menos uma letra maiúscula.");
            }

            // Verificar se a senha contém pelo menos um caractere especial
            var specialCharacters = new Regex(@"[!@#$%^&*()-+]");
            if (!specialCharacters.IsMatch(passwordrequest.password))
            {
                validationResult.IsValid = false;
                validationResult.Errors.Add("A senha deve conter pelo menos um caractere especial: !@#$%^&*()-+");
            }
            if (passwordrequest.password.Contains(" ")/*||passwordrequest.password.().*/)
            {
                validationResult.IsValid = false;
                validationResult.Errors.Add("A senha não pode conter espaços em branco");
            }
            // Verificar se a senha não possui caracteres repetidos dentro do conjunto
            if (passwordrequest.password.Distinct().Count() != passwordrequest.password.Length)
            {
                validationResult.IsValid = false;
                validationResult.Errors.Add("A senha não pode conter caracteres repetidos.");
            }
            passwordrequest.errors = validationResult.Errors.ToArray();

            if (validationResult.IsValid)
            {
                passwordrequest.SuccessMessage = ("Senha verificada com sucesso");
            }
           

            return RedirectToAction("ValidacaoResult", "Home", passwordrequest );              
        }
    }
}
