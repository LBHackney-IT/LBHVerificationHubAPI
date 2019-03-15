# LBHVerificationHubAPI (In development)

The Verification Hub provides integration with the council master data system ClearCore. 

It allows us to try to verify whether a person lives at an address they claim to live at by comparing to various different council datasets.

## Stack

- .NET Core as a web framework.
- xUnit as a test framework.

## Dependencies

- ClearCore

## Development practices

We employ a variant of Clean Architecture, borrowing from [Made Tech Flavoured Clean Architecture][mt-ca] and Made Tech's [.NET Clean Architecture library][dotnet-ca].

## Contributing
[TBC]
### Setup
[TBC]
### Development
[TBC]
### Release

We use a pull request workflow, where changes are made on a branch and approved by one or more other maintainers before the developer can merge into `master`.

Then we have an automated four step deployment process, which runs in CircleCI.

1. Automated tests (xUnit) are run to ensure the release is of good quality.
2. The app is deployed to staging automatically, where we check our latest changes work well.
3. We manually confirm a production deployment in the CircleCI workflow once we're happy with our changes in staging.
4. The app is deployed to production.

## Contacts

### Active Maintainers

- **Matthew Keyworth**, Lead Developer at London Borough of Hackney (matthew.keyworth@hackney.gov.uk)

### Other Contacts

[docker-download]: https://www.docker.com/products/docker-desktop
[mt-ca]: https://github.com/madetech/clean-architecture
[made-tech]: https://madetech.com/
[dotnet-ca]: https://github.com/madetech/dotnet-ca
