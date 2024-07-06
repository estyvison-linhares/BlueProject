using BlueProject.Business.Command;
using BlueProject.Business.Handler;
using BlueProject.Domain.Entities;
using BlueProject.Infra.Interfaces;
using Moq;

namespace BlueProject.Business.Tests.Handler
{
    public class DeleteContactHandlerTests
    {
        [Fact]
        public async Task Handle_DeleteContactCommand_Success()
        {
            var mockRepository = new Mock<IContactRepository>();
            var handler = new DeleteContactHandler(mockRepository.Object);
            var command = new DeleteContactCommand(1);
            var cancellationToken = CancellationToken.None;

            var contact = new Contact("Name", "email@example.com", "123456789");
            

            mockRepository
                .Setup(repo => repo.GetContactByIdAsync(command.Id))
                .ReturnsAsync(contact);

            mockRepository
                .Setup(repo => repo.DeleteContactAsync(command.Id))
                .Returns(Task.CompletedTask);

            var result = await handler.Handle(command, cancellationToken);

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.True(result.Data);
            Assert.Null(result.ErrorMessage);
        }

        [Fact]
        public async Task Handle_DeleteContactCommand_ContactNotFound()
        {
            
            var mockRepository = new Mock<IContactRepository>();
            var handler = new DeleteContactHandler(mockRepository.Object);
            var command = new DeleteContactCommand(1);
            var cancellationToken = CancellationToken.None;

            mockRepository
                .Setup(repo => repo.GetContactByIdAsync(command.Id))
                .ReturnsAsync((Contact)null);

            
            var result = await handler.Handle(command, cancellationToken);

            
            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.False(result.Data);
            Assert.Equal("Contact not found.", result.ErrorMessage);
        }
    }
}