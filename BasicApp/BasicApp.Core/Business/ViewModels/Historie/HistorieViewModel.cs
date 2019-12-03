using BasicApp.Business.ViewModels;
using BasicApp.Core.Business.Models;
using BasicApp.Core.ServiceAccess.Agents;
using BasicApp.Core.Utils.Messages;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Plugin.Messenger;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BasicApp.Core.Business.ViewModels
{
    public class HistorieViewModel : BaseViewModel
    {
        private readonly IMvxMessenger _mvxMessenger;
        private readonly ITrainingenServiceAgent _trainingenServiceAgent;

        public HistorieViewModel(IMvxMessenger mvxMessenger, ITrainingenServiceAgent trainingenServiceAgent)
        {
            _mvxMessenger = mvxMessenger;
            _trainingenServiceAgent = trainingenServiceAgent;
        }

        public override async Task Initialize()
        {
            await GetTrainingen();
            _mvxMessenger.Subscribe(async (TrainingMessage trainingMessage) => await GetTrainingen());
        }

        private ObservableCollection<Training> _trainingen;
        public ObservableCollection<Training> Trainingen
        {
            get { return _trainingen; }
            set
            {
                _trainingen = value;
                RaisePropertyChanged(() => Trainingen);
            }
        }

        private async Task GetTrainingen()
        {
            IsBusy = true;
            var trainingen = await _trainingenServiceAgent.GetTrainingen();
            Trainingen = new ObservableCollection<Training>(trainingen);
            IsBusy = false;
        }

        private void ShowTraining(Training training)
        {
            Navigate(new TrainingViewModel(training));
        }

        private IMvxAsyncCommand _refreshCommand;
        public IMvxAsyncCommand RefreshCommand => _refreshCommand ?? (_refreshCommand = new MvxAsyncCommand(GetTrainingen));

        private IMvxCommand _trainingClickCommand;
        public IMvxCommand TrainingClickCommand => _trainingClickCommand ?? (_trainingClickCommand = new MvxCommand<Training>((training) => ShowTraining(training)));

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }
    }
}
