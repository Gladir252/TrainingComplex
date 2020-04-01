using FitnesCenter.VIewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FitnesCenter.Controllers
{
    public class BaseController : ControllerBase
    {
        protected const string UNKNOWN_ERROR_MESSAGE = "Unknown error";

        protected async Task<ObjectResult> CreateDataObjectResult<T>(Func<T, Task<ResultViewModel>> fillResultModelFunc, T parameter)
        {
            ObjectResult result;

            ResultViewModel resultViewModel = await fillResultModelFunc.Invoke(parameter);

            switch (resultViewModel.Flag)
            {
                case (int)HttpStatusCode.NotFound:
                    result = new NotFoundObjectResult(resultViewModel.Information);
                    break;
                case (int)HttpStatusCode.BadRequest:
                    result = new BadRequestObjectResult(resultViewModel.Information);
                    break;
                case (int)HttpStatusCode.OK:
                    result = new OkObjectResult(resultViewModel.DataSet);
                    break;
                default:
                    result = new BadRequestObjectResult(UNKNOWN_ERROR_MESSAGE);
                    break;
            }

            return result;
        }

        protected async Task<ObjectResult> CreateDataObjectResult(Func<Task<ResultViewModel>> fillResultModelFunc)
        {
            ObjectResult result;

            ResultViewModel resultViewModel = await fillResultModelFunc.Invoke();

            switch (resultViewModel.Flag)
            {
                case (int)HttpStatusCode.NotFound:
                    result = new NotFoundObjectResult(resultViewModel.Information);
                    break;
                case (int)HttpStatusCode.BadRequest:
                    result = new BadRequestObjectResult(resultViewModel.Information);
                    break;
                case (int)HttpStatusCode.OK:
                    result = new OkObjectResult(resultViewModel.DataSet);
                    break;
                default:
                    result = new BadRequestObjectResult(UNKNOWN_ERROR_MESSAGE);
                    break;
            }

            return result;
        }

        protected async Task<ObjectResult> CreateInfoObjectResult<T>(Func<T, Task<ResultViewModel>> fillResultModelFunc, T parameter)
        {
            ObjectResult result;

            ResultViewModel resultViewModel = await fillResultModelFunc.Invoke(parameter);

            switch (resultViewModel.Flag)
            {
                case (int)HttpStatusCode.NotFound:
                    result = new NotFoundObjectResult(resultViewModel.Information);
                    break;
                case (int)HttpStatusCode.BadRequest:
                    result = new BadRequestObjectResult(resultViewModel.Information);
                    break;
                case (int)HttpStatusCode.OK:
                    result = new OkObjectResult(resultViewModel.Information);
                    break;
                default:
                    result = new BadRequestObjectResult(UNKNOWN_ERROR_MESSAGE);
                    break;
            }

            return result;
        }



        protected async Task<ObjectResult> CreateInfoObjectResult<T>(Func<string, Task<ResultViewModel>> fillResultModelFunc, string email)
        {
            ObjectResult result;

            ResultViewModel resultViewModel = await fillResultModelFunc.Invoke(email);

            switch (resultViewModel.Flag)
            {
                case (int)HttpStatusCode.NotFound:
                    result = new NotFoundObjectResult(resultViewModel.Information);
                    break;
                case (int)HttpStatusCode.BadRequest:
                    result = new BadRequestObjectResult(resultViewModel.Information);
                    break;
                case (int)HttpStatusCode.OK:
                    result = new OkObjectResult(resultViewModel.Information);
                    break;
                default:
                    result = new BadRequestObjectResult(UNKNOWN_ERROR_MESSAGE);
                    break;
            }

            return result;
        }

        protected async Task<ObjectResult> CreateInfoObjectResult<T>(Func<string, T, Task<ResultViewModel>> fillResultModelFunc,
            string email, T parameter)
        {
            ObjectResult result;

            ResultViewModel resultViewModel = await fillResultModelFunc.Invoke(email, parameter);

            switch (resultViewModel.Flag)
            {
                case (int)HttpStatusCode.NotFound:
                    result = new NotFoundObjectResult(resultViewModel.Information);
                    break;
                case (int)HttpStatusCode.BadRequest:
                    result = new BadRequestObjectResult(resultViewModel.Information);
                    break;
                case (int)HttpStatusCode.OK:
                    result = new OkObjectResult(resultViewModel.Information);
                    break;
                default:
                    result = new BadRequestObjectResult(UNKNOWN_ERROR_MESSAGE);
                    break;
            }

            return result;
        }

        protected async Task<ObjectResult> CreateInfoObjectResult<T>(Func<string, int, T, Task<ResultViewModel>> fillResultModelFunc,
            string email, int id, T parameter)
        {
            ObjectResult result;

            ResultViewModel resultViewModel = await fillResultModelFunc.Invoke(email, id, parameter);

            switch (resultViewModel.Flag)
            {
                case (int)HttpStatusCode.NotFound:
                    result = new NotFoundObjectResult(resultViewModel.Information);
                    break;
                case (int)HttpStatusCode.BadRequest:
                    result = new BadRequestObjectResult(resultViewModel.Information);
                    break;
                case (int)HttpStatusCode.OK:
                    result = new OkObjectResult(resultViewModel.Information);
                    break;
                default:
                    result = new BadRequestObjectResult(UNKNOWN_ERROR_MESSAGE);
                    break;
            }

            return result;
        }

        protected async Task<ObjectResult> CreateInfoObjectResult<T>(Func<int, T, Task<ResultViewModel>> fillResultModelFunc,
            int id, T parameter)
        {
            ObjectResult result;

            ResultViewModel resultViewModel = await fillResultModelFunc.Invoke(id, parameter);

            switch (resultViewModel.Flag)
            {
                case (int)HttpStatusCode.NotFound:
                    result = new NotFoundObjectResult(resultViewModel.Information);
                    break;
                case (int)HttpStatusCode.BadRequest:
                    result = new BadRequestObjectResult(resultViewModel.Information);
                    break;
                case (int)HttpStatusCode.OK:
                    result = new OkObjectResult(resultViewModel.Information);
                    break;
                default:
                    result = new BadRequestObjectResult(UNKNOWN_ERROR_MESSAGE);
                    break;
            }

            return result;
        }
    }
}
