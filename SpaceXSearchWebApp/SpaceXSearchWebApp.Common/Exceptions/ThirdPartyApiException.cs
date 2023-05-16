namespace SpaceXSearchWebApp.Common.Exceptions
{
    public class ThirdPartyApiException : Exception 
    {
        public ThirdPartyApiException() { }
        public ThirdPartyApiException(string message) : base(message) { } 
        public ThirdPartyApiException(string message, Exception innerException) : base(message, innerException) { } 
    }
}
