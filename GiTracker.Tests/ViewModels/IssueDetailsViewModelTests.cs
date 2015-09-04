﻿using System;
using GiTracker.Helpers;
using GiTracker.Models;
using GiTracker.Resources.Strings;
using GiTracker.Services.Device;
using GiTracker.ViewModels;
using Moq;
using NUnit.Framework;
using Prism.Navigation;

namespace GiTracker.Tests.ViewModels
{
    [TestFixture]
    public class IssueDetailsViewModelTests
    {
        [Test]
        public void OpenInBrowserWork()
        {
            // Arrange
            var expectedIssuePage = "http://www.apple.com";
            Uri calledUri = null;
            var deviceService = new Mock<IDeviceService>();
            deviceService.Setup(d => d.OpenUri(It.IsAny<Uri>())).Callback<Uri>(uri => calledUri = uri);
            var vm = new IssueDetailsPageViewModel(deviceService.Object, new Loader(null), null, null);

            var issue = new IssueViewModel(new GitHubIssue {WebPage = expectedIssuePage});
            vm.Issue = issue;

            // Act
            vm.OpenInBrowserCommand.Execute(null);

            // Assert
            Assert.AreEqual(expectedIssuePage, calledUri.OriginalString);
        }

        [Test]
        public void ViewModelInitializesCorrectly()
        {
            // Arrange
            const int expectedIssueNumber = 42;
            var expectedPageTitle = string.Format(IssueDetails.IssueNumber, expectedIssueNumber);
            var vm = new IssueDetailsPageViewModel(null, new Loader(null), null, null);
            var issue = new IssueViewModel(new GitHubIssue {Number = expectedIssueNumber});
            var parameters = new NavigationParameters {{IssueDetailsPageViewModel.IssueParameterName, issue}};

            // Act
            vm.OnNavigatedTo(parameters);

            // Assert
            Assert.AreEqual(expectedIssueNumber, vm.Issue.Number);
            Assert.AreEqual(expectedPageTitle, vm.Title);
        }
    }
}