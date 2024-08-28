using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.Queries.Departments;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Queries.Designations
{
    public class GetDesignationByFilterHandler : IRequestHandler<GetDesignationByFilterQuery, PagingModel<DesignationVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetDesignationByFilterHandler> _logger;

        public GetDesignationByFilterHandler(IUnitofWork unitofWork, ILogger<GetDesignationByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<DesignationVM>> Handle(GetDesignationByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.Designations.GetByPaging(request);
            return new PagingModel<DesignationVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault().TotalRecord : 0);
        }
    }
}
