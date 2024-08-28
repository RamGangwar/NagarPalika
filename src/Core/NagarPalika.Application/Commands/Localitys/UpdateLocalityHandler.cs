using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.Commands.Organization;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.Localitys
{
    public class UpdateLocalityHandler : IRequestHandler<UpdateLocalityCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateLocalityHandler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateLocalityHandler(IUnitofWork unitofWork, ILogger<UpdateLocalityHandler> logger, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel> Handle(UpdateLocalityCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var query = new { LocalityName = request.LocalityName, LocalityId_neq = request.LocalityId };
            var duplicate = await _unitofWork.Locality.GetByClause(query);
            if (duplicate != null)
            {
                return new ResponseModel { Message = "Locality Already Exists", Succeeded=false };
            }
            var dept = await _unitofWork.Locality.GetById(request.LocalityId);
            if (dept != null && dept.LocalityId > 0)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");

                dept = request.Adapt<Locality>();
                dept.ModifyBy = Convert.ToInt32(empId);
                dept.ModifyOn = DateTime.Now;

                var result = await _unitofWork.Locality.Update(dept);
                if (result)
                {
                    return new ResponseModel { Message = "Updated Successfully", Succeeded=true };
                }
            }
            return new ResponseModel { Message = "Failed to update", Succeeded=false };
        }
    }
}
