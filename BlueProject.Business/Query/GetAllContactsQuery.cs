using BlueProject.Business.Dto;
using BlueProject.Business.Response;
using MediatR;

namespace BlueProject.Business.Query
{
    public class GetAllContactsQuery : IRequest<ApiResponse<List<ContactDto>>>
    {
    }
}
