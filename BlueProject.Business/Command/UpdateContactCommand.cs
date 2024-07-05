using BlueProject.Business.Dto;
using BlueProject.Business.Response;
using MediatR;

namespace BlueProject.Business.Command
{
    public class UpdateContactCommand : UpdateContactBaseCommand
    {
        public int Id { get; set; }
        public UpdateContactCommand(string name, string email, string phone) : base(name, email, phone)
        {
        }
    }
}
