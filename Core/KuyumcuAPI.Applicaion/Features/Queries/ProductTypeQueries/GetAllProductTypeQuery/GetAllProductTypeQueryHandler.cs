using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Domain.ApiResult;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Queries.ProductTypeQueries.GetAllProductTypeQuery
{
    public class GetAllProductTypeQueryHandler : IRequestHandler<GetAllProductTypeQueryRequest, KuyumcuSystemResult<IList<GetAllProductTypeQueryResponse>>>
    {
        private readonly IProductTypeService productTypeService;

        public GetAllProductTypeQueryHandler(IProductTypeService productTypeService)
        {
            this.productTypeService = productTypeService;
        }
        public async Task<KuyumcuSystemResult<IList<GetAllProductTypeQueryResponse>>> Handle(GetAllProductTypeQueryRequest request, CancellationToken cancellationToken)
        {
            return await productTypeService.GetAllProductType(request);
        }
    }
}
