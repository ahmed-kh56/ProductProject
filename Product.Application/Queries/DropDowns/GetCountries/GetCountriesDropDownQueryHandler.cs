using MediatR;
using OutcomeOf;
using Product.Application.Common.DataReadingModels.DropDown;
using Product.Application.Common.Interfaces;

namespace Product.Application.Queries.DropDowns.GetCountries
{
    public class GetCountriesDropDownQueryHandler 
        (ICountryOfOriginReadRepository _countryOfOriginRepository)
        : IRequestHandler<GetCountriesDropDownQuery, OutcomeOf<IEnumerable<CountryOfOriginDropDownListForm>>>
    {
        public async Task<OutcomeOf<IEnumerable<CountryOfOriginDropDownListForm>>> Handle(GetCountriesDropDownQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var countries = await _countryOfOriginRepository.GetCountryOfOriginAsDropDownFormAsync();
                if (countries == null)
                {
                    return Error.NotFound(description: "No countries found.");
                }
                return countries.ToOutcomeOf();
            }
            catch (Exception ex)
            {
                return Error.Failure(description: ex.Message);
            }

        }
    }
}
