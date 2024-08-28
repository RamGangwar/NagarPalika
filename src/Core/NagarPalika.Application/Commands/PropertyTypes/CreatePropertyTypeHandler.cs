using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.OtherRepository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.PropertyTypes
{
    public class CreatePropertyTypeHandler : IRequestHandler<CreatePropertyTypeCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreatePropertyTypeHandler> _logger;
        private readonly IMediator _mediator;
        private readonly ICommonMethod _commanMethod;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreatePropertyTypeHandler(IUnitofWork unitofWork, ILogger<CreatePropertyTypeHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor, ICommonMethod commanMethod)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
            _commanMethod = commanMethod;
        }

        public async Task<ResponseModel> Handle(CreatePropertyTypeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            if (request.PropertyTypeId == 0)
            {
                var response = new ResponseModel();
                var query = new { PropertyTypeName = request.PropertyTypeName };
                var dept = await _unitofWork.PropertyType.GetByClause(query);
                if (dept == null)
                {
                    var userid = _httpContextAccessor.HttpContext.Session.GetString("UserId");

                    var model = request.Adapt<PropertyType>();
                    model.CreatedBy = Convert.ToInt32(userid);
                    model.CreatedOn = DateTime.Now;
                    var result = await _unitofWork.PropertyType.Add(model);
                    if (result > 0)
                    {
                        var res = await _unitofWork.PropertyType.GetById(result);
                        var respos = res.Adapt<PropertyTypeVM>();
                        if (res != null && request.IconUrl?.Length > 0)
                        {
                            var ress = await _commanMethod.SaveAttachment(res.PropertyTypeId, "PropertyType", request.IconUrl);
                            if (!string.IsNullOrEmpty(ress))
                            {
                                var prop = await _unitofWork.PropertyType.GetById(res.PropertyTypeId);
                                prop.IconUrl = ress;
                                var update = await _unitofWork.PropertyType.Update(prop);
                            }
                        }
                        response.Succeeded = true;
                        response.Message = "Saved Successfully.";
                        return response;
                    }
                    else
                    {
                        response.Succeeded = false;
                        response.Message = "Failed to save.";
                        return response;
                    }
                }
                else
                {
                    response.Succeeded = false;
                    response.Message = "Property Type Name Already Exists.";
                    return response;
                }
            }
            else
            {
                var query = new { PropertyTypeName = request.PropertyTypeName, PropertyTypeId_neq = request.PropertyTypeId };
                var deptDuplicate = await _unitofWork.PropertyType.GetByClause(query);
                if (deptDuplicate != null)
                {
                    return new ResponseModel { Message = "Property Type Already Exists", Succeeded = false };
                }
                var dept = await _unitofWork.PropertyType.GetById(request.PropertyTypeId);
                if (dept != null && dept.PropertyTypeId > 0)
                {
                    string uploadUrl = string.Empty;
                    if (request.IconUrl?.Length > 0)
                    {
                        if (!string.IsNullOrEmpty(dept.IconUrl))
                        {
                            var delres = _commanMethod.DeleteAttachment(dept.IconUrl);
                        }
                        uploadUrl = await _commanMethod.SaveAttachment(dept.PropertyTypeId, "PropertyType", request.IconUrl);
                        
                    }
                    var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");

                    if (!string.IsNullOrEmpty(uploadUrl))
                    {
                        dept.IconUrl = uploadUrl;
                    }
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
}
