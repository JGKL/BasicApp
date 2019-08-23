using BasicApp.Business.Services;
using BasicApp.Business.ViewModels;
using BasicApp.Core.Business.Models;
using BasicApp.Core.ServiceAccess.Agents;
using BasicApp.Core.Utils.Messages;
using MvvmCross.Navigation;
using MvvmCross.Plugin.Messenger;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BasicApp.Core.Business.ViewModels.Historie
{
    public class HistorieViewModel : BaseViewModel
    {
        private readonly IMvxMessenger _mvxMessenger;
        private readonly IMvxNavigationService _navigationService;
        private readonly ITrainingenServiceAgent _trainingenServiceAgent;

        public HistorieViewModel(IMvxMessenger mvxMessenger, IMvxNavigationService navigationService, ITrainingenServiceAgent trainingenServiceAgent)
        {
            _mvxMessenger = mvxMessenger;
            _navigationService = navigationService;
            _trainingenServiceAgent = trainingenServiceAgent;
        }

        public override async Task Initialize()
        {
            var trainingen = await _trainingenServiceAgent.GetTrainingen();
            Trainingen = new ObservableCollection<Training>(trainingen);

            _mvxMessenger.Subscribe<TrainingMessage>(async (TrainingMessage trainingMessage) => 
            {
                var newTrainingen = await _trainingenServiceAgent.GetTrainingen();
                Trainingen = new ObservableCollection<Training>(newTrainingen);
            });
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

        public void SelectItemExecution(Training training)
        {
            _navigationService.Navigate(new TrainingViewModel(training));
        }
    }
}
