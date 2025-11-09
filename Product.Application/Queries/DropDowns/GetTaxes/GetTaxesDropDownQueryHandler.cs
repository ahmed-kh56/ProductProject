using MediatR;
using OutcomeOf;
using Product.Application.Common.DataReadingModels.DropDown;
using Product.Application.Common.Interfaces;
using Product.Domain.Taxes;
using System.ComponentModel.DataAnnotations;

namespace Product.Application.Queries.DropDowns.GetTaxes
{
    public class GetTaxesDropDownQueryHandler 
        (ITaxesReadRepository _taxesReadRepository)
        : IRequestHandler<GetTaxesDropDownQuery, OutcomeOf<IEnumerable<TaxDropDownForm>>>
    {
        public async Task<OutcomeOf<IEnumerable<TaxDropDownForm>>> Handle(GetTaxesDropDownQuery request, CancellationToken cancellationToken)
        {
            try
            {
                
                if(request.TaxType =="All")
                {
                    var allTaxes = await _taxesReadRepository.GetTaxesDropDownForm();
                    if (allTaxes.Count()==0)
                        if (allTaxes is null || !allTaxes.Any())
                        {
                            return Error.NotFound(description: "no taxes was found with this type");
                        }
                    return allTaxes.ToOutcomeOf();

                }
                else
                {
                    var type = (TaxType)Enum.Parse(typeof(TaxType), request.TaxType,true);
                    var taxes = await _taxesReadRepository.GetTaxesDropDownForm(type);

                    if (taxes is null || !taxes.Any())
                    {
                        return Error.NotFound(description: "no taxes was found with this type");
                    }
                    return taxes.ToOutcomeOf();


                }

            }
            catch(Exception ex)
            {
                return Error.Failure(description: ex.Message);
            }
        }
    }
}
