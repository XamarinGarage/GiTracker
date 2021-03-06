﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiTracker.Models;
using GiTracker.Resources.Strings;
using GiTracker.Services.DataLoader;
using GiTracker.Services.Issues;
using GiTracker.Services.Progress;
using Prism.Commands;
using Prism.Navigation;

namespace GiTracker.ViewModels
{
    internal class IssueListPageViewModel : BaseListViewModel
    {
        private readonly IIssueService _issueService;
        private IEnumerable<IssueViewModel> _issues;
        private DelegateCommand<IssueViewModel> _openIssueDetailsCommand;
        private IRepo _repo;
        private DelegateCommand _updateIssuesCommand;

        public IssueListPageViewModel(ILoader loader, ILoader listLoader, IProgressService progressService,
            INavigationService navigationService,
            IIssueService issueService)
            : base(loader, listLoader, progressService, navigationService)
        {
            _issueService = issueService;

            Title = IssueList.Title;
        }

        public IEnumerable<IssueViewModel> OpenIssues
            => _issues?.Where(issue => issue.IsOpened).ToList();

        public IEnumerable<IssueViewModel> ClosedIssues
            => _issues?.Where(issue => issue.IsClosed).ToList();

        public DelegateCommand UpdateIssuesCommand =>
            _updateIssuesCommand ?? (_updateIssuesCommand = new DelegateCommand(UpdateIssues));

        public DelegateCommand<IssueViewModel> OpenIssueDetailsCommand =>
            _openIssueDetailsCommand ??
            (_openIssueDetailsCommand = new DelegateCommand<IssueViewModel>(OpenIssueDetails));

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            _repo = parameters[Constants.RepoParameterName] as IRepo;
            Title = _repo.Name;

            await LoadIssuesAsync(Loader);
        }

        private Task LoadIssuesAsync(ILoader loader)
        {
            _issues = null;
            TriggerIssuesPropertyChanged();

            return loader.LoadAsync(async cancellationToken =>
            {
                var issues =
                    await _issueService.GetIssuesAsync(_repo.Path, cancellationToken);

                _issues = issues.Select(issue => new IssueViewModel(issue)).ToList();
                TriggerIssuesPropertyChanged();
            });
        }

        private void TriggerIssuesPropertyChanged()
        {
            OnPropertyChanged(() => OpenIssues);
            OnPropertyChanged(() => ClosedIssues);
        }

        private async void UpdateIssues()
        {
            await LoadIssuesAsync(ListLoader);
        }

        private void OpenIssueDetails(IssueViewModel issueViewModel)
        {
            NavigationService.Navigate<IssueDetailsPageViewModel>(
                new NavigationParameters
                {
                    {Constants.IssueParameterName, issueViewModel.Issue},
                    {Constants.RepoParameterName, _repo}
                }, false);
        }
    }
}