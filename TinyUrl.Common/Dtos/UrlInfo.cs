namespace TinyUrl.API.Dtos
{
    public record UrlInfo
    {
        public string Url { get; init; }
        public string Code { get; init; }
    }
}
