using BasicApp.Core.Business.Models;
using MvvmCross.ViewModels;

namespace BasicApp.Core.Business.ViewModels
{
    public class TrainingViewModel : MvxViewModel
    {
        public TrainingViewModel(Training parameter)
        {
            Training = parameter;
        }

        private Training _training;
        public Training Training
        {
            get { return _training; }
            set {
                _training = value;
                RaisePropertyChanged(() => Training);
            }
        }
    }
}
