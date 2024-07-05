using BlueProject.Business.Command;
using BlueProject.Business.Response;
using BlueProject.Infra.Interfaces;
using MediatR;

namespace BlueProject.Business.Handler
{
    public class DeleteContactHandler : IRequestHandler<DeleteContactCommand, ApiResponse<bool>>
    {
        private readonly IContactRepository _contactRepository;

        public DeleteContactHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
        }

        public async Task<ApiResponse<bool>> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var existingContact = await _contactRepository.GetContactByIdAsync(request.Id);

            if (existingContact == null)
            {
                return new ApiResponse<bool>("Contact not found.");
            }

            try
            {
                await _contactRepository.DeleteContactAsync(existingContact.Id);
                return new ApiResponse<bool>(true);
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>($"Failed to delete contact: {ex.Message}");
            }
        }
    }
}
