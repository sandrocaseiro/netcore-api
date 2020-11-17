using Microsoft.AspNetCore.Http;
using NetCoreApi.Attributes;

namespace NetCoreApi.Exceptions
{
	public enum AppErrors
    {
        [AppError(StatusCodes.Status200OK, 200, "Error_Success")]
        Success,
        [AppError(StatusCodes.Status500InternalServerError, 500, "Error_Server")]
        ServerError,
        [AppError(StatusCodes.Status400BadRequest, 400, "Error_BadRequest")]
        BadRequestError,
        [AppError(StatusCodes.Status401Unauthorized, 401, "Error_Unauthorized")]
        UnauthorizedError,
        [AppError(StatusCodes.Status403Forbidden, 403, "Error_Forbidden")]
        ForbiddenError,
        [AppError(StatusCodes.Status404NotFound, 404, "Error_NotFound")]
        NotFoundError,
        [AppError(StatusCodes.Status405MethodNotAllowed, 405, "Error_MethodNotAllowed")]
        MethodNotAllowedError,
        [AppError(StatusCodes.Status406NotAcceptable, 406, "Error_NotAcceptable")]
        NotAcceptableMediaType,
        [AppError(StatusCodes.Status415UnsupportedMediaType, 415, "Error_UnsupportedMediaType")]
        UnsupportedMediaType,
        [AppError(StatusCodes.Status401Unauthorized, 900, "Error_TokenExpired")]
        TokenExpiredError,
        [AppError(StatusCodes.Status401Unauthorized, 901, "Error_InvalidToken")]
        InvalidTokenError,
        [AppError(StatusCodes.Status500InternalServerError, 902, "Error_ApiError")]
        ApiError,
        [AppError(StatusCodes.Status404NotFound, 903, "Error_ItemNotFound")]
        ItemNotFoundError,
        [AppError(StatusCodes.Status400BadRequest, 904, "Error_UsernameAlreadyExists")]
        UsernameAlreadyExists,
        [AppError(StatusCodes.Status422UnprocessableEntity, 905, "Error_BindingValidation")]
        BindingValidationError,
        [AppError(StatusCodes.Status400BadRequest, 906, "Error_PageableRequest")]
        PageableRequestError,
        [AppError(StatusCodes.Status400BadRequest, 907, "Error_FilterRequest")]
        FilterRequestError,
        [AppError(StatusCodes.Status400BadRequest, 909, "Error_InvalidCredentials")]
        InvalidCredentials
    }
}
