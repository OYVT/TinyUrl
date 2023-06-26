using TinyUrl.API.Dtos;
using TinyUrl.Common;

namespace TinyUrl.InMemoryDataAccess
{
    public class TinyUrlInMemoryDataAccess: ITinyUrlDataAccess
    {
        private readonly Dictionary<string, string> _data = new Dictionary<string, string>();

        public async Task AddNewUrlAsync(UrlInfo urlInfo)
        {
            _data.Add(urlInfo.Code, urlInfo.Url);
        }

        public async Task<string> GetUrlAsync(string code)
        {
            return _data[code];
        }

        public async Task<bool> HasCode(string code)
        {
            return _data.ContainsKey(code);
        }

        public async Task<IEnumerable<UrlInfo>> GetUrlsAsync()
        {
            return _data.Select(x => new UrlInfo { Code = x.Key, Url = x.Value});
        }
    }
}