using AutoMapper;

namespace BlueProject.Business.Tests.Mapping
{
    public class MappingTests
    {
        private readonly IMapper _mapper;

        public MappingTests()
        {
            // Configurar o AutoMapper para usar o perfil de mapeamento de teste
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TestMappingProfile>(); // Adicione o perfil de mapeamento de teste
            });

            // Criar um IMapper que pode ser injetado nos testes
            _mapper = configuration.CreateMapper();
        }
    }
}
