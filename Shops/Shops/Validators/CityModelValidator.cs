using FluentValidation;
using SuperMegaHyperPuperShop.Models;

namespace Shops.Validators
{
    public class CityModelValidator : AbstractValidator<CategoryModel>
    {
        public CityModelValidator()
        {
            RuleFor(x => x.Name).NotNull().MinimumLength(3);
        }
    }
}
