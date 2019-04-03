namespace HelloWorldDempProject
{
    public interface ILoggingService
    {
        void DeleteLine(int rowIndex);
        void Log(string toLog);
    }
}