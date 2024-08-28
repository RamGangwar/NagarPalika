using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.OtherRepository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.PropertyTypes
{
    public class DeletePropertyTypeHandler : IRequestHandler<DeletePropertyTypeCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeletePropertyTypeHandler> _logger;
        private readonly IMediator _mediator;
        private readonly ICommonMethod _commanMethod;
        public DeletePropertyTypeHandler(IUnitofWork unitofWork, ILogger<DeletePropertyTypeHandler> logger, IMediator mediator, ICommonMethod commanMethod)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _commanMethod = commanMethod;
        }

        public async Task<ResponseModel> Handle(DeletePropertyTypeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var dept = await _unitofWork.PropertyType.GetById(request.PropertyTypeId);
            if (dept != null && dept.PropertyTypeId > 0)
            {
                if (!string.IsNullOrEmpty(dept.IconUrl))
                {
                    var delres = _commanMethod.DeleteAttachment(dept.IconUrl);
                }
                var res = await _unitofWork.PropertyType.Delete(dept);
                return new ResponseModel { Message = "Delete Successfully", Succeeded=true };
            }
            return new ResponseModel { Message = "Property Type Not Found", Succeeded=false };
        }
}
}
