using TinyUrl.API.Dtos;

namespace TinyUrl.Common
{    
    public interface ITinyUrlDataAccess
    {
        /// <summary>
        /// Adds a new Url to the system
        /// </summary>
        /// <param name="urlInfo"></param>
        /// <returns></returns>
        public Task AddNewUrlAsync(UrlInfo urlInfo);

        /// <summary>
        ///  Gets the url for the given code
        /// </summary>
        public Task<string> GetUrlAsync(string code);

        /// <summary>
        /// Tests presence of code in data store
        /// </summary>
        /// <param name="code"></param>
        /// <returns>true if found.</returns>
        public Task<bool> HasCode(string code);

        /// <summary>
        /// Get all Code and Url records.
        /// </summary>
        public Task<IEnumerable<UrlInfo>> GetUrlsAsync();
    }
}
