using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class FileController : ControllerBase
    {

        [HttpGet("sync")]
        public ActionResult<int> ReadSync()
        {
            var lines = System.IO.File.ReadAllLines(@"C:\skoleni\github\mvc\words01.txt");
            return lines.Count();
        }
        
        [HttpGet("async")]
        public async Task<ActionResult<int>> ReadAsync()
        {
            var lines = await System.IO.File.ReadAllLinesAsync(@"C:\skoleni\github\mvc\words01.txt");
            return lines.Count();
        }
    }
}
