using MediatR;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.Localitys
{
    public class DeleteLocalityHandler : IRequestHandler<DeleteLocalityCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        public DeleteLocalityHandler(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public async Task<ResponseModel> Handle(DeleteLocalityCommand request, CancellationToken cancellationToken)
        {
            var employee = await _unitofWork.Locality.GetById(request.LocalityId);
            if (employee != null && employee.LocalityId > 0)
            {
                var res = await _unitofWork.Locality.Delete(employee);
                if (res)
                {
                    return new ResponseModel { Message = "Deleted successfully", Succeeded=true };
                }
            }
            return new ResponseModel { Message = "Invalid Employee", Succeeded=false};
        }
    }
}
