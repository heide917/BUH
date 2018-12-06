using BUH.DAL;
using BUH.Domain.Enums;
using BUH.Domain.Models;
using BUH.Domain.Providers.Abstraction;
using BUH.Domain.Repositories;
using BUH.Domain.Services.Abstraction;
using BUH.ViewModels;
using System;
using System.Linq;
using System.Windows;

namespace BUH
{
    public partial class MainWindow : Window
    {
        public MainWindow(
            IAccountRepository accountRepository,
            IFirstRunService firstRunService)
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(accountRepository, firstRunService);
        }
    }
}
