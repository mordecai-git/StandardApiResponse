using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace Standard_Api_Response {
    public class StandardResponse<T> {
        public bool Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public object Errors { get; set; }

        public StandardResponse( ) {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ApplicationService.ViewModel.StandardResponse"/> class.
        /// </summary>
        /// <param name="status">If set to <c>true</c> status.</param>
        private StandardResponse(bool status)
            => Status = status;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ApplicationService.ViewModel.StandardResponse"/> class.
        /// </summary>
        /// <param name="status">If set to <c>true</c> status.</param>
        /// <param name="message">Message.</param>
        private StandardResponse(bool status, string message) {
            Status = status;
            Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ApplicationService.ViewModel.StandardResponse"/> class.
        /// </summary>
        /// <param name="status">If set to <c>true</c> status.</param>
        /// <param name="message">Message.</param>
        /// <param name="data">Data.</param>
        private StandardResponse(bool status, string message, T data) {
            Status = status;
            Message = message;
            Data = data;
        }

        /// <summary>
        /// Initialize StandardResponse(bool status, string message, object data, string statusCode)
        /// </summary>
        /// <param name="status"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <param name="statusCode"></param>
        private StandardResponse(bool status, string message, T data, int statusCode) {
            Status = status;
            Message = message;
            Data = data;
            StatusCode = statusCode;
        }

        private StandardResponse(bool status, string message, T data, int statusCode, object errors) {
            Status = status;
            Message = message;
            Data = data;
            StatusCode = statusCode;
            Errors = errors;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static StandardResponse<T> Create( )
            => new();

        /// <summary>
        /// Create the specified status.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="status">If set to <c>true</c> status.</param>
        public static StandardResponse<T> Create(bool status)
            => new(status);

        /// <summary>
        /// Create the specified status and message.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="status">If set to <c>true</c> status.</param>
        /// <param name="message">Message.</param>
        public static StandardResponse<T> Create(bool status, string message)
            => new(status, message);

        /// <summary>
        /// Create the specified status, message and data.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="status">If set to <c>true</c> status.</param>
        /// <param name="message">Message.</param>
        /// <param name="data">Data.</param>
        public static StandardResponse<T> Create(bool status, string message, T data)
            => new(status, message, data);

        /// <summary>
        /// Adds the status code.
        /// </summary>
        /// <returns>The status code.</returns>
        /// <param name="statusCode">Status code.</param>

        public StandardResponse<T> AddStatusCode(int statusCode) {
            StatusCode = statusCode;
            return this;
        }

        /// <summary>
        /// Adds the status message.
        /// </summary>
        /// <returns>The status message.</returns>
        /// <param name="message">Message.</param>
        public StandardResponse<T> AddStatusMessage(string message) {
            Message = message;
            return this;
        }

        /// <summary>
        /// Error that return this
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static StandardResponse<T> Error(string message)
            => new(false, message);

        /// <summary>
        /// Error that return this
        /// </summary>
        /// <param name="message"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public static StandardResponse<T> Error(string message, int statusCode)
            => new(false, message, default, statusCode);

        /// <summary>
        /// Error that return this with model state
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public static StandardResponse<T> Error(ModelStateDictionary modelState) {
            var allErrors = modelState.Values.SelectMany(v => v.Errors);
            var errors = allErrors.Select(error => new { error.ErrorMessage });
            var errorList = modelState.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
            );
            return new(false, "One or more properties is not valid", default,
                                           (int)HttpStatusCode.BadRequest, errorList);
        }

        /// <summary>
        ///  Ok that return this
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static StandardResponse<T> Ok(string message)
            => new(true, message, default, (int)HttpStatusCode.OK);

        /// <summary>
        ///  Ok that return this
        /// </summary>
        /// <returns></returns>
        public static StandardResponse<T> Ok(T data)
            => new(true, StandardResponseMessages.SUCCESSFUL, data, (int)HttpStatusCode.OK);

        public static StandardResponse<T> NotFound( )
            => new(false, StandardResponseMessages.RESOURCE_NOT_FOUND, default, (int)HttpStatusCode.NotFound);

        public static StandardResponse<T> NotFound(string message)
            => new(false, message, default, (int)HttpStatusCode.NotFound);

        public static StandardResponse<T> NotFound(string message, int statusCode)
            => new(false, message, default, statusCode);

        /// <summary>
        ///  Ok that return this
        /// </summary>
        /// <returns></returns>
        public static StandardResponse<T> Ok( )
            => new(true, StandardResponseMessages.SUCCESSFUL, default, (int)HttpStatusCode.OK);

        /// <summary>
        ///  Failed that return this
        /// </summary>
        /// <returns></returns>
        public static StandardResponse<T> Failed( )
            => new(false, StandardResponseMessages.UNSUCCESSFUL);

        /// <summary>
        ///  Failed that return this
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static StandardResponse<T> Failed(string message)
            => new(false, message);

        /// <summary>
        ///  Failed that return this
        /// </summary>
        /// <param name="message"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public static StandardResponse<T> Failed(string message, int statusCode)
            => new(false, message, default, statusCode);

        /// <summary>
        /// Build this instance.
        /// </summary>
        /// <returns>The build.</returns>
        public StandardResponse<T> Build( )
            => this;

        public StandardResponse<T> AddData(T data) {
            Data = data;
            return this;
        }
    }
}
