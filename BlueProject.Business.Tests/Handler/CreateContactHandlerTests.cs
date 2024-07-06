using AutoMapper;
using BlueProject.Business.Command;
using BlueProject.Business.Dto;
using BlueProject.Business.Handler;
using BlueProject.Domain.Entities;
using BlueProject.Infra.Interfaces;
using Moq;

namespace BlueProject.Business.Tests.Handler
{
    public class CreateContactHandlerTests
    {
        [Fact]
        public async Task Handle_CreateContactCommand_Success()
        {
            var mockMapper = new Mock<IMapper>();
            var mockRepository = new Mock<IContactRepository>();
            var handler = new CreateContactHandler(mockMapper.Object, mockRepository.Object);
            var command = new CreateContactCommand("Tito", "titotest@example.com", "123456789");
            var cancellationToken = CancellationToken.None;

            var contact = new Contact(command.Name, command.Email, command.Phone);

            var contactDto = new ContactDto
            {
                Id = 1,
                Name = command.Name,
                Email = command.Email,
                Phone = command.Phone
            };

            mockMapper
                .Setup(mapper => mapper.Map<Contact>(command))
                .Returns(contact);

            mockMapper
                .Setup(mapper => mapper.Map<ContactDto>(contact))
                .Returns(contactDto);

            mockRepository
                .Setup(repo => repo.AddContactAsync(It.IsAny<Contact>()))
                .ReturnsAsync(contact);

            var result = await handler.Handle(command, cancellationToken);

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.NotNull(result.Data);
            Assert.Equal(command.Name, result.Data.Name);
            Assert.Equal(command.Email, result.Data.Email);
            Assert.Equal(command.Phone, result.Data.Phone);
            Assert.Null(result.ErrorMessage);
        }
    }
}
