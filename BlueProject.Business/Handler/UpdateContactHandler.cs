using AutoMapper;
using BlueProject.Business.Command;
using BlueProject.Business.Dto;
using BlueProject.Business.Response;
using BlueProject.Domain.Exceptions;
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
            try
            {
                var existingContact = await _contactRepository.GetContactByIdAsync(request.Id);

                if (existingContact == null)
                {
                    throw new NotFoundException("Contact", request.Id);
                }

                existingContact.SetName(request.Name);
                existingContact.SetEmail(request.Email);
                existingContact.SetPhone(request.Phone);

                var updatedContact = await _contactRepository.UpdateContactAsync(existingContact);
                var contactDto = _mapper.Map<ContactDto>(updatedContact);
                return new ApiResponse<ContactDto>(contactDto);
            }
            catch (NotFoundException ex)
            {
                return ApiResponse<ContactDto>.FromException(ex);
            }
            catch (Exception ex)
            {
                return ApiResponse<ContactDto>.FromException(ex);
            }
        }
    }
}
