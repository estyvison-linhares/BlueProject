using AutoMapper;
using BlueProject.Business.Dto;
using BlueProject.Business.Query;
using BlueProject.Business.Response;
using BlueProject.Infra.Interfaces;
using MediatR;

namespace BlueProject.Business.Handler
{
    public class GetContactByIdHandler : IRequestHandler<GetContactByIdQuery, ApiResponse<ContactDto>>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public GetContactByIdHandler(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ContactDto>> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.GetContactByIdAsync(request.Id);

            if (contact == null)
            {
                return new ApiResponse<ContactDto>("Contact not found.");
            }

            var contactDto = _mapper.Map<ContactDto>(contact);
            return new ApiResponse<ContactDto>(contactDto);
        }
    }
}
