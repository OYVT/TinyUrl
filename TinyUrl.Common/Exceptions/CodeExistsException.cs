namespace TinyUrl.Common.Exceptions
{
    public class CodeExistsException : Exception
    {
        public CodeExistsException(string code) : base($"Code {code} already exists")
        {
        }
    }
}
