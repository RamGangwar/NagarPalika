using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.FineCriterias
{
    public class DeleteFineCriteriaHandler : IRequestHandler<DeleteFineCriteriaCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeleteFineCriteriaHandler> _logger;
        private readonly IMediator _mediator;

        public DeleteFineCriteriaHandler(IUnitofWork unitofWork, ILogger<DeleteFineCriteriaHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel> Handle(DeleteFineCriteriaCommand request, CancellationToken cancellationToken)
        {
            var dept = await _unitofWork.FineCriteria.GetById(request.FineCriteriaId);
            if (dept != null && dept.FineCriteriaId > 0)
            {
                var res = await _unitofWork.FineCriteria.Delete(dept);
                return new ResponseModel { Message = "Delete Successfully", Succeeded=true };
            }
            return new ResponseModel { Message = "Fine Criteria Not Found", Succeeded=false };
        }
}
}
