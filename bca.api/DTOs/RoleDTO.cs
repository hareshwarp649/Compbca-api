﻿namespace bca.api.DTOs
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; } = string.Empty;
    }
}
