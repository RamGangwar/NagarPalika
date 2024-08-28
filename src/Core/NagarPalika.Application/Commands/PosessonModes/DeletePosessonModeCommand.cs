using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.PosessonModes {
 public class DeletePosessonModeCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "PosessonModeId is required")] public int PosessonModeId {get; set;}
}
}
