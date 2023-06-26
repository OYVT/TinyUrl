using TinyUrl.API.Dtos;

namespace TinyUrl.Common
{
    public interface ITinyUrlProvider
    {
        /// <summary>
        /// Adds a new Url to the system
        /// </summary>
        /// <param name="urlInfo"></param>
        /// <returns></returns>
        /// <exception cref="TinyUrl.Common.Exceptions.CodeExistsException">Returned if code already exists.</exception>
        public Task AddNewUrlAsync(UrlInfo urlInfo);

        /// <summary>
        /// Get all Code and Url records.
        /// </summary>
        public Task<IEnumerable<UrlInfo>> GetUrlsAsync();

        /// <summary>
        /// Get Url for the given code.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<UrlInfo> GetUrlAsync(string code);

    }
}
