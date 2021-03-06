﻿using System.Threading;
using System.Threading.Tasks;
using GiTracker.Models;
using GiTracker.Services.Api;
using GiTracker.Services.Credential;
using GiTracker.Services.Rest;

namespace GiTracker.Services.Login
{
    internal class LoginService : ILoginService
    {
        private readonly ICredentialsService _credentialsService;
        private readonly IGitApiProvider _gitApiProvider;
        private readonly IRestService _restService;

        public LoginService(IRestService restService, IGitApiProvider gitApiProvider,
            ICredentialsService credentialsService)
        {
            _restService = restService;
            _gitApiProvider = gitApiProvider;
            _credentialsService = credentialsService;
        }

        public async Task<IUser> LoginAsync(string username, string password, CancellationToken cancellationToken)
        {
            _credentialsService.SetCredentials(username, password);
            var user =
                await
                    _restService.GetAsync(_gitApiProvider.GetUserRequest(), cancellationToken)
                        .ConfigureAwait(false);

            return user as IUser;
        }
    }
}