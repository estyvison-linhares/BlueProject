using BlueProject.Business.Dto;
using BlueProject.Business.Response;
using MediatR;

namespace BlueProject.Business.Command
{
    public class UpdateContactBaseCommand : IRequest<ApiResponse<ContactDto>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public UpdateContactBaseCommand(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }
    }
}
