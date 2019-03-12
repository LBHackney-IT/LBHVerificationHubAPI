using FluentValidation;

namespace LBHVerificationHubAPI.UseCases.V1.Search.Models
{
    public class ParkingPermitVerificationRequestRequestValidator : AbstractValidator<ParkingPermitVerificationRequest>
    {
        public ParkingPermitVerificationRequestRequestValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.ForeName).NotEmpty();
            RuleFor(x => x.UPRN).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
        }
    }
}