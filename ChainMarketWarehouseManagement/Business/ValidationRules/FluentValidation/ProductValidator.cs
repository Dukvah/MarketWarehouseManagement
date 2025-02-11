using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<AddProductDto>
    {
        public ProductValidator() 
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Ürün ismi boş bırakılamaz");
            RuleFor(p => p.Name).Length(2, 30).WithMessage("Ürün ismi minimum 2, maksimum 30 karakter olmalıdır.");
            RuleFor(p => p.Price).NotEmpty();
            RuleFor(p => p.Price).GreaterThanOrEqualTo(1);
            RuleFor(p => p.ProductCategoryId).GreaterThanOrEqualTo(0);
        }
    }
}
