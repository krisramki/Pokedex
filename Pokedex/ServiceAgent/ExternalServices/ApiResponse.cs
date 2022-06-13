namespace Pokedex.ServiceAgent.ExternalServices
{
    public abstract class ApiResponse
    {
        public bool Success { get; set; }
    }

    public class ApiResponse<TResponse> : ApiResponse
    {
        public TResponse Result { get; set; }

        public ApiResponse(TResponse result)
          : this(success: true, result: result)
        { }

        public ApiResponse(bool success, TResponse result)
        {
            this.Success = success;
            this.Result = result;
        }
    }
}
