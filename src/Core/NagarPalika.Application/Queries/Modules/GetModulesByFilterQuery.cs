using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.Modules
{
    public class GetModulesByFilterQuery : IRequest<List<ModulesVM>>
    {
        public int RoleId { get; set; }
        public int EmployeeId { get; set; }
        public bool IsPermission { get; set; } = false;
    }
}
