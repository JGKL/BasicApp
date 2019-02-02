using BasicApp.Business.Services;
using BasicApp.Business.ViewModels;
using BasicApp.Core.Business.Models;
using MvvmCross.Commands;

namespace BasicApp.Core.Business.ViewModels
{
    public class AddTrainingViewModel : BaseViewModel
    {
        private readonly IDatabaseService _databaseService;

        public AddTrainingViewModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public Training Training { get; set; } = new Training();

        public IMvxCommand OpslaanCommand
        {
            get
            {
                return new MvxCommand<object>((e) =>
                {
                    _databaseService.Insert(Training);
                });
            }
        }
    }
}
