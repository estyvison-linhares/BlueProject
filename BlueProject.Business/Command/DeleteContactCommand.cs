using BlueProject.Business.Response;
using MediatR;

namespace BlueProject.Business.Command
{
    public class DeleteContactCommand : IRequest<ApiResponse<bool>>
    {
        public int Id { get; set; }

        public DeleteContactCommand(int id)
        {
            Id = id;
        }
    }
}
