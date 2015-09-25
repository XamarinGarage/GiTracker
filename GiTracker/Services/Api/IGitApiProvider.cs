﻿using GiTracker.Services.Rest;

namespace GiTracker.Services.Api
{
    public interface IGitApiProvider
    {
        IRestRequest GetUserRequest();
        IRestRequest GetIssuesRequest(string repository);
        IRestRequest GetUserRepositoriesRequest();
        IRestRequest GetCreateCommentRequest(string repository, int issueId);
        IRestRequest GetLoadCommentsRequest(string repository, int issueId);
    }
}