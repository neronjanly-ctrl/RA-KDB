using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DockingDataModels;

[Owned]
[DataContract]
public class Prediction
{
    /// <summary>
    /// The predicted result from the trained machine learning model. Unknown if not computed.
    /// </summary>
    [DataMember]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public BioActivity Activity { get; set; }

    /// <summary>
    /// The confidence level for the machine learning prediction. Null value if not computed.
    /// </summary>
    [DataMember]
    public float? ConfidenceLevel { get; set; }
}
