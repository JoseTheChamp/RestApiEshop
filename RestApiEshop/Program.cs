using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using RestApiEshop.Application;
using RestApiEshop.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddProblemDetails();

builder.Services.AddApiVersioning(options =>
	{
		options.DefaultApiVersion = new ApiVersion(1, 0);
		options.ReportApiVersions = true;
		options.ApiVersionReader = new UrlSegmentApiVersionReader();
	})
	.AddMvc()
	.AddApiExplorer(options =>
	{
		options.GroupNameFormat = "'v'VVV";
		options.SubstituteApiVersionInUrl = true;
	})
	.AddOpenApi(options =>
	{
		options.Document.AddDocumentTransformer((document, context, cancellationToken) =>
		{
			document.Info.Title = "RestApiEshop API";
			document.Info.Description = "Product catalog of the eshop - list of products, product detail and update of the product description.";

			return Task.CompletedTask;
		});

		// decimal is described as a double by default
		options.Document.AddSchemaTransformer((schema, context, cancellationToken) =>
		{
			if (context.JsonTypeInfo.Type == typeof(decimal))
			{
				schema.Format = "decimal";
			}

			return Task.CompletedTask;
		});
	});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();
app.UseStatusCodePages();

if (app.Environment.IsDevelopment())
{
	app.MapOpenApi().WithDocumentPerVersion();
	app.UseSwaggerUI(options =>
	{
		foreach (ApiVersionDescription description in app.DescribeApiVersions())
		{
			options.SwaggerEndpoint($"/openapi/{description.GroupName}.json", description.GroupName);
		}
	});

	await app.Services.ApplyMigrationsAsync();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
