using BlueProject.Business.Dto;
using BlueProject.Business.Response;
using MediatR;

namespace BlueProject.Business.Command
{
    public class CreateContactCommand : IRequest<ApiResponse<ContactDto>>
    {
        public CreateContactCommand(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
