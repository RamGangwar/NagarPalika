using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.RecieptBookss

{
    public class CreateRecieptBooksCommand : IRequest<ResponseModel<RecieptBooksVM>>
    {
        public int RecieptBookId { get; set; }
        [Required(ErrorMessage = "RecieptBook is required")] 
        public string RecieptBook { get; set; }
        [Required(ErrorMessage = "StartSrNo is required")]
        public int StartSrNo { get; set; }
        [Required(ErrorMessage = "EndSrNo is required")] 
        public int EndSrNo { get; set; }
        [Required(ErrorMessage = "AllowcatedTo is required")] 
        public int AllowcatedTo { get; set; }
        
        [Required(ErrorMessage = "Type is required")]
        public string BookType { get; set; }
    }
}
