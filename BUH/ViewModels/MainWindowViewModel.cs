using BUH.DAL;
using BUH.Domain.Models;
using BUH.Domain.Repositories;
using BUH.Domain.Services.Abstraction;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Windows.Input;

namespace BUH.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region "Fields"

        private readonly IAccountRepository _accountRepository;
        private readonly IFirstRunService _firstRunService;
        private ObservableCollection<Account> _accounts;
        private bool _canExecLoadList = true;

        #endregion

        #region "Properties"

        public RelayCommand WindowLoadedCommand { get; private set; }

        public RelayCommand LoadListCommand { get; private set; }

        public ObservableCollection<Account> Accounts
        {
            get
            {
                return _accounts;
            }
            set
            {
                _accounts = value;
                RaisePropertyChanged(() => Accounts);
            }
        }

        #endregion

        #region ".ctor"

        public MainWindowViewModel(
            IAccountRepository accountRepository,
            IFirstRunService firstRunService) 
        {
            _accountRepository = accountRepository;
            _firstRunService = firstRunService;

            WindowLoadedCommand = new RelayCommand(OnFirstRun);
            LoadListCommand = new RelayCommand(FillListView, CanLoadList);
        }

        #endregion

        #region "Private methods"

        private void FillListView()
        {
            if (!_canExecLoadList)
                return;

            _canExecLoadList = false;
            Accounts = new ObservableCollection<Account>(_accountRepository.GetCollection());
            _canExecLoadList = true;
        }

        private bool CanLoadList()
        {
            return _canExecLoadList;
        }

        private void OnFirstRun()
        {
            var context = new BUHContext();
            var isCreated = context.Database.CreateIfNotExists();
            context.Dispose();
            if (!isCreated)
                return;

            _firstRunService.FillDefaultDataBase();
        }

        #endregion
    }
}
