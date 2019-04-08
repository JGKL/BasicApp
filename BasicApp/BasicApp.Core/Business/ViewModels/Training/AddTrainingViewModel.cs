using BasicApp.Business.Services;
using BasicApp.Business.ViewModels;
using BasicApp.Core.Business.Models;
using BasicApp.Core.Utils.Messages;
using MvvmCross.Commands;
using MvvmCross.Plugin.Messenger;
using System;
using System.Threading.Tasks;

namespace BasicApp.Core.Business.ViewModels
{
    public class AddTrainingViewModel : BaseViewModel
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMvxMessenger _mvxMessenger;

        public AddTrainingViewModel(IDatabaseService databaseService, IMvxMessenger mvxMessenger)
        {
            _databaseService = databaseService;
            _mvxMessenger = mvxMessenger;
        }

        public override Task Initialize()
        {
            Datum = DateTime.Now;
            return Task.CompletedTask;
        }

        public Training Training { get; set; } = new Training();

        private DateTime _datum;
        public DateTime Datum
        {
            get {
                return _datum;
            }
            set {
                _datum = value;
                RaisePropertyChanged(() => Datum);
            }
        }

        public IMvxCommand OpslaanCommand
        {
            get
            {
                return new MvxCommand<object>((e) =>
                {
                    Training.Datum = _datum;
                    _databaseService.Insert(Training);
                    _mvxMessenger.Publish(new TrainingMessage(this));
                });
            }
        }
    }
}
