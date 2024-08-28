using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.SessionMasters

{
    public class UpdateSessionMasterCommand : IRequest<ResponseModel>
    {
        [Required(ErrorMessage = "SessionMasterId is required")] public int SessionMasterId { get; set; }
        [Required(ErrorMessage = "StartDate is required")] public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "EndDate is required")] public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "SessionName is required")] public string SessionName { get; set; }
        [Required(ErrorMessage = "IsActive is required")] public bool IsActive { get; set; }
    }
}
