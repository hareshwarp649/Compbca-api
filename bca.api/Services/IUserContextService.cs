﻿using bca.api.Data.Entities;

namespace bca.api.Services
{
    public interface IUserContextService
    {
        Task<ApplicationUser?> GetCurrentUserAsync(bool ensureNotDeleted, bool ensureNotBCA);
    }

}
