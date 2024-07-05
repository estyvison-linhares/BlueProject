using BlueProject.Business.Dto;
using BlueProject.Business.Response;
using MediatR;

namespace BlueProject.Business.Query
{
    public class GetContactByIdQuery : IRequest<ApiResponse<ContactDto>>
    {
        public GetContactByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
