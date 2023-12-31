using DMSAPI.Interfaces;
using DMSAPI.Interfaces.Common;
using DMSAPI.Repositories;
using DMSAPI.Repositories.Common;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "DMS API",
        Description = "�2023-23 LOGIC InfoTech Ltd. All rights reserved. Generated by .NET Core V7 with for Document Management System (SCM) of Asrotex Group."
    });
});

// Add dependency injection to the container.
builder.Services.AddSingleton<IDBManager, DBManager>();
builder.Services.AddScoped<IRequisitionRepository, RequisitionRepository>();
builder.Services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();



var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DefaultModelsExpandDepth(-1);
    });
}

app.UseAuthorization();
app.MapControllers();
app.Run();
