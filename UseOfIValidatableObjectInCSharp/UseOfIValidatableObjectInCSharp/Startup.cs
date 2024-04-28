using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace UseOfIValidatableObjectInCSharp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                        .Where(e => e.Value?.Errors.Count > 0)
                        .Select(e => new
                        {
                            Name = e.Key,
                            Errors = e.Value?.Errors.Select(er => er.ErrorMessage).ToArray()
                        }).ToArray();

                    var response = new
                    {
                        Message = "Validation errors occurred",
                        Success = false,
                        Errors = errors
                    };
                    return new BadRequestObjectResult(response);
                };
            });
            services.AddSwaggerGen();
            services.AddScoped<IRepositoryService, RepositoryService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public interface IRepositoryService
    {
        bool IsEmailPresent(string email);
    }

    public class RepositoryService : IRepositoryService
    {
        public bool IsEmailPresent(string email)
        {
            if (!string.IsNullOrWhiteSpace(email) && email.EndsWith("gmail.com"))
                return false;
            else
                return true;
        }
    }
    public class Document
    {
        public string DocumentName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }

    public class Student : IValidatableObject
    {
        public string Email { get; set; }
        public string Telephone { get; set; }
        public List<Document> DocumentList { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            //validate email
            try
            {
                var addr = new System.Net.Mail.MailAddress(Email);
                if (addr.Address != Email.Trim())
                {
                    results.Add(new ValidationResult("Invalid email format.", [nameof(Email)]));
                }
            }
            catch
            {
                results.Add(new ValidationResult("Invalid email format.", [nameof(Email)]));
            }

            // Custom validation for telephone prefix
            if (!Telephone.StartsWith("+1"))
            {
                results.Add(new ValidationResult("Telephone number must start with '+1'.", [nameof(Telephone)]));
            }

            // Validate DocumentList
            foreach (var document in DocumentList)
            {
                if (document.ExpiryDate <= document.CreatedDate)
                {
                    results.Add(new ValidationResult($"The document at index {DocumentList.IndexOf(document)} with name '{document.DocumentName}' has an expiry date that is not greater than the created date.", ["DocumentList"]));
                }

                if (document.CreatedDate > DateTime.Now)
                {
                    results.Add(new ValidationResult($"The document at index {DocumentList.IndexOf(document)} with name '{document.DocumentName}' has a created date that is in the future.", ["DocumentList"]));
                }
            }

            // Get IRepositoryService from the ValidationContext
            var repositoryService = (IRepositoryService)validationContext.GetService(typeof(IRepositoryService));

            // Check if email is already present in the database
            if (repositoryService.IsEmailPresent(Email))
            {
                results.Add(new ValidationResult("Email is already present in the database.", [nameof(Email)]));
            }

            return results;
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IRepositoryService _repositoryService;

        public StudentsController(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {           
            // Save the student to the database, etc.
            return Ok();
        }
    }

}
