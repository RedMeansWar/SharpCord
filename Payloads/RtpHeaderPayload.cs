using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharpCord.Payloads
{
    public class RtpHeaderPayload
    {
        [JsonPropertyName("version")]
        public int Version { get; set; }
        
        [JsonPropertyName("padding")]
        public bool Padding { get; set; }

        [JsonPropertyName("extension")]
        public bool Extension { get; set; }

        [JsonPropertyName("csrc_count")]
        public int CsrcCount { get; set; }

        [JsonPropertyName("marker")]
        public bool Marker { get; set; }

        [JsonPropertyName("payload_type")]
        public int PayloadType { get; set; }

        [JsonPropertyName("sequence_number")]
        public ushort SequenceNumber { get; set; }

        [JsonPropertyName("timestamp")]
        public uint Timestamp { get; set; }

        [JsonPropertyName("ssrc")]
        public uint Ssrc { get; set; }

        [JsonPropertyName("csrc")]
        public uint[] Csrc { get; set; }
    }
}
