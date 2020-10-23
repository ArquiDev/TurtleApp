namespace TurtleApp.Microservices.ImportServices.Responses.FileImport
{
    public enum ImportFileResultErrorType
    {
        Unknown,
        FileNoExist,
        NotSupportedExtension,
        IncorrectJsonFormat,
    }
}
