﻿using GiTracker.Models;
using GiTracker.Services.DataLoader;
using GiTracker.Services.Progress;
using GiTracker.Services.WorkLog;
using Prism.Navigation;

namespace GiTracker.ViewModels
{
    public class LogWorkPageViewModel : BaseViewModel
    {
        public const string IssueParameterName = "IssueParameterName";
        public const string RepoParameterName = "RepoParameterName";
        private readonly IWorkLogService _workLogService;
        private IIssue _issue;
        private IRepo _repo;

        public LogWorkPageViewModel(ILoader loader,
            IProgressService progressService,
            INavigationService navigationService,
            IWorkLogService workLogService)
            : base(loader, progressService, navigationService)
        {
            _workLogService = workLogService;
        }

        public IIssue Issue
        {
            get { return _issue; }
            private set { SetProperty(ref _issue, value); }
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            Issue = parameters[IssueParameterName] as IIssue;
            _repo = parameters[RepoParameterName] as IRepo;
        }
    }
}