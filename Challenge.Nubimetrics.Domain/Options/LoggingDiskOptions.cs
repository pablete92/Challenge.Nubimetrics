using Challenge.Nubimetrics.Infrastructure.Models;

namespace Challenge.Nubimetrics.Domain.Options
{
    public class LoggingDiskOptions : HttpOptionsBase
    {
        public LoggingDiskOptions() : base() { }

        public string FolderName { get; set; }
        public string FileCSV { get; set; }
        public string FileJSON { get; set; }
    }
}
