﻿using freedom.exchange.api.Requests;

namespace freedom.exchange.api.Commands.Interfaces
{
    public interface IUpdateUserMessage
    {
        public Task<bool> ExecuteAsync(UpdateUserMessageRequest request);
    }
}
