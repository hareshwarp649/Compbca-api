﻿using bca.api.Enums;
using System.Text.Json.Serialization;

namespace bca.api.DTOs
{
    public class UserDocumentDTO
    {
        public int Id { get; set; }
        public DocumentType DocumentType { get; set; }

        [JsonIgnore]
        public string FilePath { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;
    }
}
