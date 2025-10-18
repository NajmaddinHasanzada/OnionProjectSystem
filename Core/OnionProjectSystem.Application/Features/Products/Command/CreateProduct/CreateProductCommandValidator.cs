using FluentValidation;

namespace OnionProjectSystem.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Title)
               .NotEmpty()
               .WithName("Title")
               .WithMessage("Title is required").MaximumLength(100)
               .WithMessage("Title maximum length is 100 characters");

            RuleFor(p => p.Description)
               .NotEmpty()
               .WithName("Description")
               .WithMessage("Description is required");

            RuleFor(p => p.BrandId)
                .GreaterThan(0)
                .WithName("Brand");

            RuleFor(p => p.Price)
                .GreaterThan(0)
                .WithName("Price")
                .WithMessage("Price must be greater than zero");

            RuleFor(p => p.Stock)
                .GreaterThanOrEqualTo(0)
                .WithName("Stock")
                .WithMessage("Stock must be greater than or equal to zero");

            RuleFor(d => d.Discount)
                .GreaterThanOrEqualTo(0)
                .WithName("Discount");

            RuleFor(x => x.CategoryIds)
                .NotEmpty()
                .Must(categories => categories.Any())
                .WithName("Categories");
        }
    }
}
