using Newtonsoft.Json;

namespace OWDocuments.Models
{
   
    public partial class CreateDocumentRequest 
    {
        [JsonProperty("messageId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string MessageId { get; set; }
    
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("additionalInfo", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public AdditionalInfo AdditionalInfo { get; set; }


    }

    public partial class CreateDocumentResponse 
    {
        [JsonProperty("messageId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string MessageId { get; set; }
    
    
    }
    
    public partial class ProblemDetails 
    {
        [JsonProperty("type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    
        [JsonProperty("title", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }
    
        [JsonProperty("status", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Status { get; set; }
    
        [JsonProperty("detail", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Detail { get; set; }
    
        [JsonProperty("instance", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Instance { get; set; }
    
      
    }
    

    public enum DocumentStatus
    {
        [System.Runtime.Serialization.EnumMember(Value = @"created")]
        Created = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"notReady")]
        NotReady = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"notFound")]
        NotFound = 2,
    
    }
    

    public partial class GetDocumentStatusResponse 
    {
        [JsonProperty("messageId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string MessageId { get; set; }
    
        [JsonProperty("status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public DocumentStatus Status { get; set; }
    
    
    }
    

    public partial class GetDocumentResponse 
    {
        [JsonProperty("messageId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string MessageId { get; set; }
    
        [JsonProperty("name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [JsonProperty("additionalInfo", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public AdditionalInfo AdditionalInfo { get; set; }
    
    
    }

    public class AdditionalInfo
    {
        [JsonProperty("additionalProp1", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string AdditionalProp1 { get; set; }

        [JsonProperty("additionalProp2", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string AdditionalProp2 { get; set; }

        [JsonProperty("additionalProp3", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string AdditionalProp3 { get; set; }
    }

}
