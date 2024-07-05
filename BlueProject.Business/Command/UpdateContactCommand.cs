using BlueProject.Business.Dto;
using BlueProject.Business.Response;
using MediatR;

namespace BlueProject.Business.Command
{
    public class UpdateContactCommand : IRequest<ApiResponse<ContactDto>>
    {
        public UpdateContactCommand(int id, string name, string email, string phone)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; } 
    }
}
