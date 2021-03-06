﻿using System.Threading;
using GiTracker.Models;
using GiTracker.Services.Api;
using GiTracker.Services.Credential;
using GiTracker.Services.Login;
using GiTracker.Services.Rest;
using Moq;
using NUnit.Framework;

namespace GiTracker.Tests.Services
{
    [TestFixture]
    public class LoginServiceTest
    {
        [SetUp]
        public void Init()
        {
            var apiProviderMoq = new Mock<IGitApiProvider>();
            apiProviderMoq.Setup(moq => moq.GetUserRequest()).Returns(_userRequest);
            _gitApiProvider = apiProviderMoq.Object;
        }

        private IGitApiProvider _gitApiProvider;
        private readonly IRestRequest _userRequest = Mock.Of<IRestRequest>();

        private readonly string _testName = "testname";
        private readonly string _testPassword = "testpassword";


        [Test]
        public async void GetUserCallsICredentialService()
        {
            // Arrange
            var user = new Mock<IUser>().Object;

            var restServiceMoq = new Mock<IRestService>();
            restServiceMoq.Setup(moq => moq.GetAsync(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(user);

            var credentialServiceMoq = new Mock<ICredentialsService>();

            var loginService = new LoginService(restServiceMoq.Object, _gitApiProvider, credentialServiceMoq.Object);

            // Act
            var userResponce = await loginService.LoginAsync(_testName, _testPassword);

            // Assert
            credentialServiceMoq.Verify(moq => moq.SetCredentials(_testName, _testPassword),
                Times.Once);

            Assert.AreEqual(user, userResponce);
        }

        [Test]
        public async void GetUserCallsIRestService()
        {
            // Arrange
            var user = new Mock<IUser>().Object;

            var restServiceMoq = new Mock<IRestService>();
            restServiceMoq.Setup(moq => moq.GetAsync(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(user);

            var credentialServiceMoq = new Mock<ICredentialsService>();

            var loginService = new LoginService(restServiceMoq.Object, _gitApiProvider, credentialServiceMoq.Object);

            // Act
            var userResponce = await loginService.LoginAsync(_testName, _testPassword);

            // Assert
            restServiceMoq.Verify(moq => moq.GetAsync(_userRequest, It.IsAny<CancellationToken>()),
                Times.Once);

            Assert.AreEqual(user, userResponce);
        }
    }
}