using AutoMapper;
using BlueProject.Business.Dto;
using BlueProject.Business.Query;
using BlueProject.Business.Response;
using BlueProject.Infra.Interfaces;
using MediatR;

namespace BlueProject.Business.Handler
{
    public class GetAllContactsHandler : IRequestHandler<GetAllContactsQuery, ApiResponse<List<ContactDto>>>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public GetAllContactsHandler(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<ContactDto>>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _contactRepository.GetAllContactsAsync();
            var contactDtos = _mapper.Map<List<ContactDto>>(contacts);

            return new ApiResponse<List<ContactDto>>(contactDtos);
        }
    }
}
