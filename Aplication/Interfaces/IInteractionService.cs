﻿using Aplication.Response;

namespace Aplication.Interfaces
{
    public interface IInteractionService
    {
        public Task<List<InteractionResponse>> GetAll();
    }
}
