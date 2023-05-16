namespace SpaceXSearchWebApp.Common.Exceptions
{
    public class AutoMapperMappingException : Exception
    {
        public AutoMapperMappingException() { }
        public AutoMapperMappingException(string message) : base(message) { }
        public AutoMapperMappingException(string message, Exception exception) : base(message, exception) { }
    }
}
