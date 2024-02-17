namespace ServerlessAspNetCore.Domain
{
    public class Description
    {
        public object B { get; set; }
        public bool BOOL { get; set; }
        public bool IsBOOLSet { get; set; }
        public List<object> BS { get; set; }
        public List<object> L { get; set; }
        public bool IsLSet { get; set; }
        public M M { get; set; }
        public bool IsMSet { get; set; }
        public object N { get; set; }
        public List<object> NS { get; set; }
        public bool NULL { get; set; }
        public string S { get; set; }
        public List<object> SS { get; set; }
    }

    public class ImageId
    {
        public object B { get; set; }
        public bool BOOL { get; set; }
        public bool IsBOOLSet { get; set; }
        public List<object> BS { get; set; }
        public List<object> L { get; set; }
        public bool IsLSet { get; set; }
        public M M { get; set; }
        public bool IsMSet { get; set; }
        public object N { get; set; }
        public List<object> NS { get; set; }
        public bool NULL { get; set; }
        public string S { get; set; }
        public List<object> SS { get; set; }
    }

    public class Item
    {
        public Description description { get; set; }
        public S3Url s3_url { get; set; }
        public ImageId image_id { get; set; }
        public Title title { get; set; }
    }

    public class LastEvaluatedKey
    {
    }

    public class M
    {
    }

    public class Metadata
    {
    }

    public class ResponseMetadata
    {
        public string RequestId { get; set; }
        public Metadata Metadata { get; set; }
        public int ChecksumAlgorithm { get; set; }
        public int ChecksumValidationStatus { get; set; }
    }

    public class ImageDTO
    {
        public object ConsumedCapacity { get; set; }
        public int Count { get; set; }
        public List<Item> Items { get; set; }
        public LastEvaluatedKey LastEvaluatedKey { get; set; }
        public int ScannedCount { get; set; }
        public ResponseMetadata ResponseMetadata { get; set; }
        public int ContentLength { get; set; }
        public int HttpStatusCode { get; set; }
        
        public List<ImageModel> ConvertDTOsToModels(ImageDTO dto)
        {
            List<ImageModel> imageList = new List<ImageModel>();
            foreach (var item in dto.Items)
            {
                ImageModel image = new ImageModel();

                image.Image_id = item.image_id.S;
                image.Title = item.title.S;
                image.Description = item.description.S;
                image.S3_Url = item.s3_url.S;

                imageList.Add(image);
            }
            return imageList;
        }
    }

    public class S3Url
    {
        public object B { get; set; }
        public bool BOOL { get; set; }
        public bool IsBOOLSet { get; set; }
        public List<object> BS { get; set; }
        public List<object> L { get; set; }
        public bool IsLSet { get; set; }
        public M M { get; set; }
        public bool IsMSet { get; set; }
        public object N { get; set; }
        public List<object> NS { get; set; }
        public bool NULL { get; set; }
        public string S { get; set; }
        public List<object> SS { get; set; }
    }

    public class Title
    {
        public object B { get; set; }
        public bool BOOL { get; set; }
        public bool IsBOOLSet { get; set; }
        public List<object> BS { get; set; }
        public List<object> L { get; set; }
        public bool IsLSet { get; set; }
        public M M { get; set; }
        public bool IsMSet { get; set; }
        public object N { get; set; }
        public List<object> NS { get; set; }
        public bool NULL { get; set; }
        public string S { get; set; }
        public List<object> SS { get; set; }
    }



}
