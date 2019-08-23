using BasicApp.Business.Services;
using BasicApp.Business.ViewModels;
using BasicApp.Core.Business.Models;
using BasicApp.Core.Utils.Messages;
using MvvmCross.Plugin.Messenger;
using MvvmCross.Commands;
using System;
using System.Threading.Tasks;

namespace BasicApp.Core.Business.ViewModels
{
    public class AddTrainingViewModel : BaseViewModel
    {
        private readonly IMvxMessenger _mvxMessenger;

        public AddTrainingViewModel(IMvxMessenger mvxMessenger)
        {
            _mvxMessenger = mvxMessenger;
        }

        public override Task Initialize()
        {
            Datum = DateTime.Now;

            return base.Initialize();
        }

        private DateTime _datum;
        public DateTime Datum
        {
            get { return _datum; }
            set {
                _datum = value;
                RaisePropertyChanged(() => Datum);
            }
        }

        public string Programma { get; set; }

        public IMvxCommand OpslaanCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    var training = new Training
                    {
                        Datum = Datum,
                        Programma = Programma
                    };

                    //_databaseService.Insert(training);

                    _mvxMessenger.Publish(new TrainingMessage(this));
                });
            }
        }
    }
}
