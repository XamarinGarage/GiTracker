﻿using GiTracker.Services.DataLoader;
using GiTracker.Services.Progress;
using Prism.Mvvm;
using Prism.Navigation;

namespace GiTracker.ViewModels
{
    public abstract class BaseViewModel : BindableBase, INavigationAware
    {
        private readonly IProgressService _progressService;
        protected readonly INavigationService NavigationService;

        private string _title;

        protected BaseViewModel(ILoader loader, IProgressService progressService,
            INavigationService navigationService)
        {
            Loader = loader;
            Loader.LoadingChanged += (sender, args) => IsLoadingChanged(Loader.IsLoading);
            _progressService = progressService;
            NavigationService = navigationService;
        }

        protected ILoader Loader { get; }

        public string Title
        {
            get { return _title; }
            protected set { SetProperty(ref _title, value); }
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        private void IsLoadingChanged(bool isLoading)
        {
            if (isLoading)
            {
                _progressService.ShowProgress();
            }
            else
            {
                _progressService.DismissProgress();
            }
        }
    }
}