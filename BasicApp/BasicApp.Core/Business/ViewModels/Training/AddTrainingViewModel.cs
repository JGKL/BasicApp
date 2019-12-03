using BasicApp.Business.ViewModels;
using BasicApp.Core.Business.Models;
using BasicApp.Core.Utils.Messages;
using MvvmCross.Plugin.Messenger;
using MvvmCross.Commands;
using System;
using System.Threading.Tasks;
using BasicApp.Core.ServiceAccess.Agents;

namespace BasicApp.Core.Business.ViewModels
{
    public class AddTrainingViewModel : BaseViewModel
    {
        private readonly IMvxMessenger _mvxMessenger;
        private readonly ITrainingenServiceAgent _trainingenServiceAgent;

        public AddTrainingViewModel(IMvxMessenger mvxMessenger, ITrainingenServiceAgent trainingenServiceAgent)
        {
            _mvxMessenger = mvxMessenger;
            _trainingenServiceAgent = trainingenServiceAgent;
        }

        public override Task Initialize()
        {
            return base.Initialize();
        }

        public bool Saving { get; private set; }

        public string Programma { get; set; }

        private DateTime _datum;
        public DateTime Datum
        {
            get
            {
                if (_datum == null)
                    _datum = DateTime.Now;

                return _datum;
            }

            set
            {
                _datum = value;
                RaisePropertyChanged(() => Datum);
            }
        }

        private int _kilometers { get; set; }
        public int Kilometers {
            get
            {
                return _kilometers;
            }
            set
            {
                _kilometers = value;
                RaisePropertyChanged(() => Kilometers);
            }
        }

        public IMvxCommand OpslaanCommand
        {
            get
            {
                return new MvxAsyncCommand(async () =>
                {
                    Saving = true;

                    var training = new Training
                    {
                        Programma = Programma,
                        Datum = Datum,
                        Kilometers = Kilometers
                    };

                    await _trainingenServiceAgent.PostTraining(training);
                    _mvxMessenger.Publish(new TrainingMessage(this));

                    Saving = false;
                });
            }
        }
    }
}
