using BasicApp.Business.Services;
using BasicApp.Business.ViewModels;
using BasicApp.Core.Business.Models;
using BasicApp.Core.Utils.Messages;
using MvvmCross.Commands;
using MvvmCross.Plugin.Messenger;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BasicApp.Core.Business.ViewModels.Historie
{
    public class HistorieViewModel : BaseViewModel
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMvxMessenger _mvxMessenger;

        public HistorieViewModel(IDatabaseService databaseService, IMvxMessenger mvxMessenger)
        {
            _databaseService = databaseService;
            _mvxMessenger = mvxMessenger;
        }

        public override Task Initialize()
        {
            var trainingen = _databaseService.GetCollection<Training>();
            Trainingen = new ObservableCollection<Training>(trainingen);

            _mvxMessenger.Subscribe<TrainingMessage>(OnTrainingenChanged);

            return Task.CompletedTask;
        }

        private void OnTrainingenChanged(TrainingMessage trainingMessage)
        {
            var trainingen = _databaseService.GetCollection<Training>();
            Trainingen = new ObservableCollection<Training>(trainingen);
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

        public IMvxCommand OpenTrainingCommand
        {
            get
            {
                return new MvxCommand<object>((e) =>
                {
                    Navigate<TrainingViewModel>();
                });
            }
        }

        public IMvxAsyncCommand TestAsyncCommand => new MvxAsyncCommand(async () => await TestAsyncCommandMethod());

        private async Task TermostatSignin()
        {
            //await some stuff
        }
    }
}
