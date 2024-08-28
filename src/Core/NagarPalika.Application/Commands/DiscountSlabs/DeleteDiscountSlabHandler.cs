using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.DiscountSlabs
{
    public class DeleteDiscountSlabHandler : IRequestHandler<DeleteDiscountSlabCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeleteDiscountSlabHandler> _logger;
        private readonly IMediator _mediator;

        public DeleteDiscountSlabHandler(IUnitofWork unitofWork, ILogger<DeleteDiscountSlabHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel> Handle(DeleteDiscountSlabCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var dept = await _unitofWork.DiscountSlab.GetById(request.DiscountSlabId);
            if (dept != null && dept.DiscountSlabId > 0)
            {
                var res = await _unitofWork.DiscountSlab.Delete(dept);
                return new ResponseModel { Message = "Delete Successfully", Succeeded=true };
            }
            return new ResponseModel { Message = "Discount Slab Not Found", Succeeded=false };
        }
}
}
