using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using User.Application.Interfaces;
using Users.Domain.Dto;
using Users.Domain.Model;






namespace User.Function
{
    public class Function
    {
        private readonly ILogger<Function> _logger;
        private readonly IUserApplication _userApplication;
        private readonly IValidator<UserCreateDto> _createValidator;
        private readonly IValidator<UserUpdateDto> _updateValidator;

        public Function(ILogger<Function> log, IUserApplication userApplication, IValidator<UserCreateDto> createValidator,  IValidator<UserUpdateDto> updateValidator)
        {
            _logger = log;
            _userApplication = userApplication;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            
        }

        [FunctionName("GetAllUser")]
        [OpenApiOperation(operationId: "GetAllUser", tags: new[] { "Users" })]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(List<UserDtoResponse>), Description = "The OK response")]
        public  ActionResult<List<UserDtoResponse>> GetAllUser(
           [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "api/GetAllUser")] HttpRequest req)
        {

            return new ObjectResult(_userApplication.GetAllUser());

        }

        [FunctionName("CreateUser")]
        [OpenApiOperation(operationId: "CreateUser", tags: new[] { "Users" })]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(ResponseApi), Description = "The OK response")]
        [OpenApiRequestBody("application/json", typeof(UserCreateDto))]
        public async Task<ActionResult<UserDtoResponse>> CreateUser(
          [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "api/CreateUser")] UserCreateDto userCreateDto)
        {
            var validation = _createValidator.Validate(userCreateDto);

            if (!validation.IsValid)
            {
                return new BadRequestObjectResult(new ResponseApi()
                {
                    IsSuccess = false,
                    Messague = "Error a la hora de validar data",
                    Result = validation.Errors.Select(e => new
                    {
                        Field = e.PropertyName,
                        Error= e.ErrorMessage
                    })
                }) ;
            }

            return new ObjectResult(new ResponseApi() {Result= await _userApplication.CreateUser(userCreateDto), IsSuccess=true, Messague="Usuario creado exitosamente" });

        }

        [FunctionName("GetUserById")]
        [OpenApiOperation(operationId: "GetUserById", tags: new[] { "Users" })]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(UserDtoResponse), Description = "The OK response")]
        [OpenApiParameter(name:"id")]
        public ActionResult<List<UserDtoResponse>> GetUserById(
         [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "api/GetUserById/{id:int}")] HttpRequest req, int id)
        {
            var user= _userApplication.GetUserById(id);

            if (user == null)
            {
                return new NotFoundResult();
            }
            return new ObjectResult(user);

        }
        
        [FunctionName("UpdateUser")]
        [OpenApiOperation(operationId:"UpdateUser", tags:new[] { "Users"})]
        [OpenApiResponseWithBody(statusCode:HttpStatusCode.OK, contentType:"application/json", bodyType:typeof(UserDtoResponse), Description ="The Ok Response")]
        [OpenApiRequestBody("application/json", typeof(UserUpdateDto))]
        [OpenApiParameter(name: "id")]
        public ActionResult<UserDtoResponse> UpdateUser([HttpTrigger(AuthorizationLevel.Anonymous, "put", Route ="api/UpdateUser/{id:int}")] UserUpdateDto userUpdateDto, int id)
        {
           var userUpdate= _userApplication.UpdateUser(id, userUpdateDto);
           if(userUpdate == null)
            {
                return new NotFoundResult();
            }

           return userUpdate;
        }

        

    }
}

