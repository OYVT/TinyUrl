using Microsoft.AspNetCore.Mvc;
using TinyUrl.Common.Exceptions;
using TinyUrl.Common;
using TinyUrl.API.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TinyUrl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TinyUrl : ControllerBase
    {
        private readonly ITinyUrlProvider _tinyUrlProvider;

        public TinyUrl(ITinyUrlProvider tinyUrlProvider)
        {
            _tinyUrlProvider = tinyUrlProvider;
        }

        // POST api/<TinyUrl>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] UrlInfo urlInfo)
        {
            try
            {
                await _tinyUrlProvider.AddNewUrlAsync(urlInfo);
            }
            catch (CodeExistsException codeExistsException)
            {
                return BadRequest(codeExistsException.Message);
            }

            return Ok();
        }

        // GET: api/<TinyUrl>
        [HttpGet]
        public async Task<IEnumerable<UrlInfo>> Get()
        {
            return await _tinyUrlProvider.GetUrlsAsync();
        }

        // GET api/<TinyUrl>/123
        [HttpGet("{code}")]
        public async Task<IActionResult> Get(string code)
        {
            UrlInfo urlInfo;
            try
            {
                urlInfo = await _tinyUrlProvider.GetUrlAsync(code);
            }
            catch (CodeNotFoundException codeNotFoundException)
            {
                return NotFound(codeNotFoundException.Message);
            }

            return Ok(urlInfo);
        }

    }
}
