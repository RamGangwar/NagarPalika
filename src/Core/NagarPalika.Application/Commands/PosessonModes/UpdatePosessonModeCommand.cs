using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.PosessonModes {
 public class UpdatePosessonModeCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "PosessonModeId is required")] public int PosessonModeId {get; set;}
[Required(ErrorMessage = "PosessonModeName is required")] public string PosessonModeName {get; set;}
[Required(ErrorMessage = "IsActive is required")] public bool IsActive {get; set;}
}
}
