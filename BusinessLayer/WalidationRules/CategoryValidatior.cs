using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.WalidationRules
{
   public class CategoryValidatior:AbstractValidator<Category>
   {
        public CategoryValidatior()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklamayı Boş Geçemezsiniz.");
            RuleFor(X => X.CategoryName).MinimumLength(3).WithMessage("Lütfen En Az Üç Karakter Girişi Yapın");
            RuleFor(X => X.CategoryName).MaximumLength(20).WithMessage("Lütfen En Fazla 20 Karakter Giriniz");
        }
   }
}
