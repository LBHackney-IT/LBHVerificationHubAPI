using FluentValidation;

namespace LBHVerificationHubAPI.UseCases.V1.Search.Models
{
    public class ParkingPermitVerificationRequestRequestValidator : AbstractValidator<ParkingPermitVerificationCreateRequest>
    {
        public ParkingPermitVerificationRequestRequestValidator()
        {
            RuleFor(x => x).NotNull();

        }
    }
}