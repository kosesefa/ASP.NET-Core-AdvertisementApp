using AdvertisementApp.UI.Models;
using FluentValidation;

namespace AdvertisementApp.UI.ValidationRules
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {
        public UserCreateModelValidator()
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş olamaz.");
            RuleFor(x => x.Password).MinimumLength(3).WithMessage("Şifre minimum 3 karakter olmalıdır.");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Şifreler eşleşmiyor.");
            RuleFor(x => x.Firstname).NotEmpty().WithMessage("Ad kısmı boş bırakılamaz.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad kısmı boş bırakılamaz."); 
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı kısmı boş bırakılamaz.");
            RuleFor(x => x.Username).MinimumLength(3).WithMessage("Kullanıcı adı minimum 3 karakter olmalıdır.");
            RuleFor(x => new
            {
                x.Username,
                x.Firstname
            }).Must(x => CanNotFirstname(x.Username, x.Firstname)).WithMessage("Kullanıcı adında adınız bulunmamalıdır.").When(x => x.Username != null && x.Firstname != null);
            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Cinsiyet seçimi zorunludur."); 

        }
        private bool CanNotFirstname(string username, string firstname)
        {
            return !username.Contains(firstname);
        }
    }
}
