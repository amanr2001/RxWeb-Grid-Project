using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class uploadcontroller : ControllerBase
    {
        public readonly string bucketimga = "abcdbucket1234";
        private readonly IAmazonS3 client;

        // GET: api/<uploadcontroller>
        [HttpPost("upload")]
        public async Task<IActionResult> uploadfile(IFormFile file)
        {
            if (file == null || file.Length <= 0)
            {
                return BadRequest("error");
            }

            var destkey = $"Images/{file.FileName.ToLower() + DateTime.Now.ToString()}";
            using (var client = new AmazonS3Client("", "", Amazon.RegionEndpoint.APSouth1))
            {
                using (var transferUtility = new TransferUtility(client))
                {
                    var transferUtilityRequest = new TransferUtilityUploadRequest
                    {
                        BucketName = bucketimga,
                        Key = destkey,
                        InputStream = file.OpenReadStream(),
                        //CannedACL = S3CannedACL.PublicRead // Optional: Set the desired ACL for the uploaded file
                    };
                    await transferUtility.UploadAsync(transferUtilityRequest);

                }
            }
            var reg = RegionEndpoint.APSouth1;
            var url = $"https://{bucketimga}.s3.{reg.SystemName}.amazonaws.com/{destkey}";
            var resp = new
            {
                Message = "File uploaded successfully.",
                url
            };

            return Ok(resp);


        }
    }
}

