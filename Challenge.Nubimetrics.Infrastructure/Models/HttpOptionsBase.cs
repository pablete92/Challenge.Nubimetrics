namespace Challenge.Nubimetrics.Infrastructure.Models
{
    public abstract class HttpOptionsBase
    {
        public virtual string HttpClientName { get; set; }
        public virtual string UrlBase { get; set; }
        public HttpOptionsBase() { }
    }
}
