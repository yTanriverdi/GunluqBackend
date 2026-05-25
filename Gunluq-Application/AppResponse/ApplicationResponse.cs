namespace Gunluq_Application.ApplicationResponse
{
    public class ApplicationResponse<T>
    {
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; }
        public T? Data { get; set; } = default(T?);

        /// <summary>
        /// APPLICATION KATMANINDA BAŞARILI İŞLEM İÇİN KULLAN
        /// </summary>
        /// <param name="data">Gönderilecek olan veri</param>
        /// <param name="message">Gönderilecek olan mesaj</param>
        /// <returns>Başarılı</returns>
        public static ApplicationResponse<T> Ok(T data, string message)
        {
            ApplicationResponse<T> successResponse = new ApplicationResponse<T>()
            {
                Data = data,
                Message = message,
                Success = true
            };
            return successResponse;
        }


        /// <summary>
        /// APPLICATION KATMANINDA BAŞARISIZ İŞLEM İÇİN KULLAN
        /// </summary>
        /// <param name="message">Gönderilecek olan mesaj</param>
        /// <returns>Başarısız</returns>
        public static ApplicationResponse<T> Fail(string message)
        {
            ApplicationResponse<T> failResponse = new ApplicationResponse<T>()
            {
                Message = message,
                Success = false
            };
            return failResponse;
        }
    }
}
