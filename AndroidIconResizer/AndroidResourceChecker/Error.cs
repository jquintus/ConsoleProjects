namespace AndroidResourceChecker
{
    public class Error
    {
        public Error(string message, bool isError = false)
        {
            IsError = isError;
            Message = message;
        }

        public bool IsError { get; private set; }

        public string Message { get; private set; }

        public override string ToString()
        {
            return Message;
        }
    }
}