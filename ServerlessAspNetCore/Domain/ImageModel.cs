using System.Text.Json.Serialization;

namespace ServerlessAspNetCore.Domain
{
    public class ImageModel
    {
        [JsonPropertyName("image_id")]
        public string Image_id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("s3_url")]
        public string S3_Url { get; set; }

        [JsonPropertyName("content")]
        public byte[] Content { get; set;}

    }
}
