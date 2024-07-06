using BlueProject.Business.Command;
using BlueProject.Business.Dto;
using BlueProject.Business.Handler;
using BlueProject.Business.Mappings;
using BlueProject.Business.Query;
using BlueProject.Business.Response;
using BlueProject.Infra.Data;
using BlueProject.Infra.Interfaces;
using BlueProject.Infra.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContext with SQL Server
builder.Services.AddDbContext<BlueProjectDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Register repositories
builder.Services.AddScoped<IContactRepository, ContactRepository>();

// Register handlers
builder.Services.AddScoped<IRequestHandler<CreateContactCommand, ApiResponse<ContactDto>>, CreateContactHandler>();
builder.Services.AddScoped<IRequestHandler<GetContactByIdQuery, ApiResponse<ContactDto>>, GetContactByIdHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteContactCommand, ApiResponse<bool>>, DeleteContactHandler>();
builder.Services.AddScoped<IRequestHandler<UpdateContactCommand, ApiResponse<ContactDto>>, UpdateContactHandler>();
builder.Services.AddScoped<IRequestHandler<GetAllContactsQuery, ApiResponse<List<ContactDto>>>, GetAllContactsHandler>();

// Register MediatR and scan the assembly containing the handlers
builder.Services.AddMediatR(typeof(CreateContactHandler).Assembly);

// Register AutoMapper with the mapping profile
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add CORS service
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
