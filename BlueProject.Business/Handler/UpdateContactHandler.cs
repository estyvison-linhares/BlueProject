using AutoMapper;
using BlueProject.Business.Command;
using BlueProject.Business.Dto;
using BlueProject.Business.Response;
using BlueProject.Infra.Interfaces;
using MediatR;

namespace BlueProject.Business.Handler
{
    public class UpdateContactHandler : IRequestHandler<UpdateContactCommand, ApiResponse<ContactDto>>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        public UpdateContactHandler(IMapper mapper, IContactRepository contactRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
        }

        public async Task<ApiResponse<ContactDto>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var existingContact = await _contactRepository.GetContactByIdAsync(request.Id);

            if (existingContact == null)
            {
                return new ApiResponse<ContactDto>("Contact not found.");
            }

            existingContact.SetName(request.Name);
            existingContact.SetEmail(request.Email);
            existingContact.SetPhone(request.Phone);

            try
            {
                var updatedContact = await _contactRepository.UpdateContactAsync(existingContact);
                var contactDto = _mapper.Map<ContactDto>(updatedContact);
                return new ApiResponse<ContactDto>(contactDto);
            }
            catch (Exception ex)
            {
                return new ApiResponse<ContactDto>($"Failed to update contact: {ex.Message}");
            }
        }
    }
}
