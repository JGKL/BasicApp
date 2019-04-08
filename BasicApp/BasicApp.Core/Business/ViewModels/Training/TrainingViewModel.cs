using BasicApp.Business.Services;
using BasicApp.Business.ViewModels;
using BasicApp.Core.Business.Models;
using System.Linq;
using System.Threading.Tasks;

namespace BasicApp.Core.Business.ViewModels
{
    public class TrainingViewModel : BaseViewModel
    {
        private readonly IDatabaseService _databaseService;

        public TrainingViewModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;

            Training = _databaseService.GetCollection<Training>().First();
        }

        private Training _training;
        public Training Training
        {
            get { return _training; }
            set { _training = value; RaisePropertyChanged(() => Training); }
        }

        public override Task Initialize()
        {
            return Task.CompletedTask;
        }
    }
}
