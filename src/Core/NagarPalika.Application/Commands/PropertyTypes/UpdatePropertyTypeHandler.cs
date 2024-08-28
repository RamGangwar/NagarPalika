using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.OtherRepository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
using System.Reflection;

namespace NagarPalika.Application.Commands.PropertyTypes
{
    public class UpdatePropertyTypeHandler : IRequestHandler<UpdatePropertyTypeCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdatePropertyTypeHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICommonMethod _commanMethod;
        public UpdatePropertyTypeHandler(IUnitofWork unitofWork, ILogger<UpdatePropertyTypeHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor, ICommonMethod commanMethod)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
            _commanMethod = commanMethod;
        }

        public async Task<ResponseModel> Handle(UpdatePropertyTypeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var query = new { PropertyTypeName = request.PropertyTypeName, PropertyTypeId_neq = request.PropertyTypeId };
            var deptDuplicate = await _unitofWork.PropertyType.GetByClause(query);
            if (deptDuplicate != null)
            {
                return new ResponseModel { Message = "Property Type Already Exists", Succeeded = false };
            }
            var dept = await _unitofWork.PropertyType.GetById(request.PropertyTypeId);
            if (dept != null && dept.PropertyTypeId > 0)
            {
                if (request.IconUrl?.Length > 0)
                {
                    if (!string.IsNullOrEmpty(dept.IconUrl))
                    {
                        var delres = _commanMethod.DeleteAttachment(dept.IconUrl);
                    }
                    var ress = await _commanMethod.SaveAttachment(dept.PropertyTypeId, "PropertyType", request.IconUrl);
                    if (!string.IsNullOrEmpty(ress))
                    {
                        dept.IconUrl = ress;
                    }
                }
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");

                dept = request.Adapt<PropertyType>();
                dept.ModifyBy = Convert.ToInt32(empId);
                dept.ModifyOn = DateTime.Now;
                dept.PropertyTypeId = dept.PropertyTypeId;
                var result = await _unitofWork.PropertyType.Update(dept);
                if (result)
                {

                    return new ResponseModel { Message = "Updated Successfully", Succeeded = true };
                }
            }
            return new ResponseModel { Message = "Failed to update", Succeeded = false };
        }
    }
}
