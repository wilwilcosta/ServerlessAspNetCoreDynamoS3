using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime.SharedInterfaces;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ServerlessAspNetCore.Domain;
using ServerlessAspNetCore.Services;
using ServerlessAspNetCore.Settings;
using System.Text;
using System.Text.Json.Serialization;

namespace ServerlessAspNetCore.Service
{
    public class ImageService : IImageService
    {
        private readonly IAmazonDynamoDB _dynamoDB;
        private readonly IAmazonS3 _s3;
        private readonly IOptions<DatabaseSettings> _databaseSettings;

        private readonly string bucketName = "projetoawstestewilson";

        public ImageService(IAmazonDynamoDB dynamoDB,
            IAmazonS3 s3,
            IOptions<DatabaseSettings> databaseSettings)
        {
            _dynamoDB = dynamoDB;
            _s3 = s3;
            _databaseSettings = databaseSettings;
        }
        async Task<List<ImageModel>> GetAllImagesDynamoDB()
        {
            ScanRequest scanRequest = new ScanRequest(_databaseSettings.Value.TableName);

            var response = await _dynamoDB.ScanAsync(scanRequest);
            return ConvertScanResponseToImageModel(response);
        }

        private List<ImageModel> ConvertScanResponseToImageModel(ScanResponse response)
        {
            var json = JsonConvert.SerializeObject(response);
            var dto = JsonConvert.DeserializeObject<ImageDTO>(json);
            List<ImageModel> images = dto.ConvertDTOsToModels(dto);

            
            
            return images;

        }

        async Task<List<ImageModel>> IImageService.GetAllImages()
        {
            var imageModelList = await this.GetAllImagesDynamoDB();
            foreach (var imageModel in imageModelList)
            {
                var fileName = imageModel.S3_Url.Split('/')[3];
                var content = GetFileS3(fileName).Result ;
                imageModel.Content = content != null ? ReadFully(content.ResponseStream) : new byte[0];
            }
            return imageModelList;
            //IActionResult()
        }

        async Task<List<ImageModel>> IImageService.GetAllImagesDynamoDB()
        {
            ScanRequest scanRequest = new ScanRequest(_databaseSettings.Value.TableName);

            var response = await _dynamoDB.ScanAsync(scanRequest);
            return ConvertScanResponseToImageModel(response);
        }

        private async Task<GetObjectResponse> GetFileS3(string fileName)
        {
            try
            {
                var response = await _s3.GetObjectAsync(this.bucketName, fileName);
                return response;
            }
            catch (AmazonS3Exception ex) when (ex.Message is "The specified key does not exist.") 
            {
                return null;
            }
        }

        private static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }

        //Task<List<ImageModel>> IImageService.GetAllImagesDynamoDB()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
