
namespace Referral.RestClient
{
    public class HttpResult<T> where T : new()
    {
        public bool IsSuccess { get; private set; }

        public T Result { get; private set; }

        public static HttpResult<T> SetResult(T result)
        {
            var httpResult = new HttpResult<T>();
            if (result == null)
            {
                httpResult.IsSuccess = false;
                httpResult.Result = new T();
            }
            else
            {
                httpResult.IsSuccess = true;
                httpResult.Result = result;
            }

            return httpResult;
        }
    }
}