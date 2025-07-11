﻿using bca.api.Data.Entities;
using bca.api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace bca.api.Services
{
    public interface IUserDocumentService
    {
        Task<UserDocumentDTO> UploadDocumentAsync(UserDocumentUploadDTO uploadDTO);
        Task<IEnumerable<UserDocumentDTO>> UploadMultipleDocumentsAsync(UserMultipleDocumentUploadDTO uploadDTO);
        Task<IEnumerable<UserDocumentDTO>> GetUserDocumentsAsync(int userId);
        Task<bool> DeleteDocumentAsync(int id);
        Task<FileStreamResult?> GetDocumentAsync(int documentId);
        Task<UserDocument?> GetByIdAsync(int documentId);
    }
}
