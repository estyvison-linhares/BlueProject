using AutoMapper;
using BlueProject.Business.Command;
using BlueProject.Business.Dto;
using BlueProject.Business.Handler;
using BlueProject.Domain.Entities;
using BlueProject.Infra.Interfaces;
using Moq;

namespace BlueProject.Business.Tests.Handler
{
    public class UpdateContactHandlerTests
    {
        [Fact]
        public async Task Handle_UpdateContactCommand_Success()
        {
            var mockMapper = new Mock<IMapper>();
            var mockRepository = new Mock<IContactRepository>();
            var handler = new UpdateContactHandler(mockMapper.Object, mockRepository.Object);
            var command = new UpdateContactCommand("Updated Name", "updatedemail@example.com", "987654321");
            var cancellationToken = CancellationToken.None;

            var contact = new Contact("Original Name", "originalemail@example.com", "123456789");
            
            var updatedContactDto = new ContactDto
            {
                Id = command.Id,
                Name = command.Name,
                Email = command.Email,
                Phone = command.Phone
            };

            mockRepository
                .Setup(repo => repo.GetContactByIdAsync(command.Id))
                .ReturnsAsync(contact);

            mockRepository
                .Setup(repo => repo.UpdateContactAsync(It.IsAny<Contact>()))
                .ReturnsAsync(contact);

            mockMapper
                .Setup(mapper => mapper.Map<ContactDto>(contact))
                .Returns(updatedContactDto);

            var result = await handler.Handle(command, cancellationToken);

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.NotNull(result.Data);
            Assert.Equal(command.Name, result.Data.Name);
            Assert.Equal(command.Email, result.Data.Email);
            Assert.Equal(command.Phone, result.Data.Phone);
            Assert.Null(result.ErrorMessage);
        }

        [Fact]
        public async Task Handle_UpdateContactCommand_ContactNotFound()
        {
            var mockMapper = new Mock<IMapper>();
            var mockRepository = new Mock<IContactRepository>();
            var handler = new UpdateContactHandler(mockMapper.Object, mockRepository.Object);
            var command = new UpdateContactCommand("Updated Name", "updatedemail@example.com", "987654321");
            var cancellationToken = CancellationToken.None;

            mockRepository
                .Setup(repo => repo.GetContactByIdAsync(command.Id))
                .ReturnsAsync((Contact) null);

            var result = await handler.Handle(command, cancellationToken);

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.Null(result.Data);
            Assert.Equal($"Contact with ID '{command.Id}' not found.", result.ErrorMessage);
        }
    }
}
