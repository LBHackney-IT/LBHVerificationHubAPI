using FluentValidation;

namespace LBHVerificationHubAPI.UseCases.V1.Search.Models
{
    public class GetRequestValidator : AbstractValidator<GetRequest>
    {
        public GetRequestValidator()
        {
            RuleFor(x => x).NotNull();

        }
    }
}