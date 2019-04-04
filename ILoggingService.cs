using SharedTypes;

namespace HelloWorldDempProject
{
    public interface ILoggingService
    {
        void DeleteLine(int rowIndex);
        void Log(string toLog);

        void Log(LogLineModel toLog);
    }
}