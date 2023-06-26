using TinyUrl.API.Dtos;
using TinyUrl.Common;
using TinyUrl.Common.Exceptions;

namespace TinyUrl.CoreLogic
{
    public class TinyUrlProvider : ITinyUrlProvider
    {
        private readonly ITinyUrlDataAccess _dataAccess;

        public TinyUrlProvider(ITinyUrlDataAccess tinyUrlDataAccess)
        {
            _dataAccess = tinyUrlDataAccess;
        }

        public async Task AddNewUrlAsync(UrlInfo urlInfo)
        {
            if (await _dataAccess.HasCode(urlInfo.Code))
                throw new CodeExistsException(urlInfo.Code);

            if (!Uri.IsWellFormedUriString(urlInfo.Url, UriKind.RelativeOrAbsolute))
                throw new InvalidUrlException(urlInfo.Url);

            await _dataAccess.AddNewUrlAsync(urlInfo);
        }

        public async Task<UrlInfo> GetUrlAsync(string code)
        {
            if (!await _dataAccess.HasCode(code))
                throw new CodeNotFoundException(code);

            string url = await _dataAccess.GetUrlAsync(code);
            return new UrlInfo { Code = code, Url = url };
        }

        public async Task<IEnumerable<UrlInfo>> GetUrlsAsync()
        {
            return await _dataAccess.GetUrlsAsync();
        }

        
    }
}