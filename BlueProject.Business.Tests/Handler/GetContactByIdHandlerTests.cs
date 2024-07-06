using AutoMapper;
using BlueProject.Business.Dto;
using BlueProject.Business.Handler;
using BlueProject.Business.Query;
using BlueProject.Domain.Entities;
using BlueProject.Infra.Interfaces;
using Moq;

namespace BlueProject.Business.Tests.Handler
{
    public class GetContactByIdHandlerTests
    {
        [Fact]
        public async Task Handle_GetContactByIdQuery_Success()
        {
            var mockMapper = new Mock<IMapper>();
            var mockRepository = new Mock<IContactRepository>();
            var handler = new GetContactByIdHandler(mockRepository.Object, mockMapper.Object);
            var query = new GetContactByIdQuery(1);
            var cancellationToken = CancellationToken.None;

            var contact = new Contact("Name", "email@example.com", "123456789");

            var contactDto = new ContactDto
            {
                Id = query.Id,
                Name = contact.Name,
                Email = contact.Email,
                Phone = contact.Phone
            };

            mockRepository
                .Setup(repo => repo.GetContactByIdAsync(query.Id))
                .ReturnsAsync(contact);

            mockMapper
                .Setup(mapper => mapper.Map<ContactDto>(contact))
                .Returns(contactDto);

            var result = await handler.Handle(query, cancellationToken);

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.NotNull(result.Data);
            Assert.Equal(contact.Name, result.Data.Name);
            Assert.Equal(contact.Email, result.Data.Email);
            Assert.Equal(contact.Phone, result.Data.Phone);
            Assert.Null(result.ErrorMessage);
        }

        [Fact]
        public async Task Handle_GetContactByIdQuery_ContactNotFound()
        {
            
            var mockMapper = new Mock<IMapper>();
            var mockRepository = new Mock<IContactRepository>();
            var handler = new GetContactByIdHandler(mockRepository.Object, mockMapper.Object);
            var query = new GetContactByIdQuery(1);
            var cancellationToken = CancellationToken.None;

            mockRepository
                .Setup(repo => repo.GetContactByIdAsync(query.Id))
                .ReturnsAsync((Contact)null);

            
            var result = await handler.Handle(query, cancellationToken);

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.Null(result.Data);
            Assert.Equal($"Contact with ID '{query.Id}' not found.", result.ErrorMessage);
        }
    }
}

