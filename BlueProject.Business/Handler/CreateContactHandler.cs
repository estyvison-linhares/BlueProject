using AutoMapper;
using BlueProject.Business.Command;
using BlueProject.Business.Dto;
using BlueProject.Business.Response;
using BlueProject.Domain.Entities;
using BlueProject.Infra.Interfaces;
using MediatR;

namespace BlueProject.Business.Handler
{
    public class CreateContactHandler : IRequestHandler<CreateContactCommand, ApiResponse<ContactDto>>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        public CreateContactHandler(IMapper mapper, IContactRepository contactRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        public async Task<ApiResponse<ContactDto>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = _mapper.Map<Contact>(request);

            try
            {
                var createdContact = await _contactRepository.AddContactAsync(contact);
                var contactDto = _mapper.Map<ContactDto>(createdContact);

                return new ApiResponse<ContactDto>(contactDto);
            }
            catch (Exception ex)
            {
                return new ApiResponse<ContactDto>($"Failed to create contact: {ex.Message}");
            }
        }
    }
}
