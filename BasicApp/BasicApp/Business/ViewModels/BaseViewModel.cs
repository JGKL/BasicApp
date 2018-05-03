using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using Newtonsoft.Json;
using BasicApp.Business.Models;

namespace BasicApp.Business.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        protected bool ShowViewModel<TViewModel, TInit>(TInit parameter) where TViewModel : BaseViewModel
        {
            var text = JsonConvert.SerializeObject(parameter);
            return base.ShowViewModel<TViewModel>(new Dictionary<string, string> { { "parameter", text } });
        }

        /// <summary>
        /// The toolbar items
        /// </summary>
        List<ToolbarItem> _toolbarItems;
        public List<ToolbarItem> ToolbarItems
        {
            get
            {
                return _toolbarItems;
            }
            set
            {
                _toolbarItems = value;
                RaisePropertyChanged(() => ToolbarItems);
            }
        }

        public IMvxCommand NavigationCommand
        {
            get
            {
                return new MvxCommand(() =>
                {

                });
            }
        }

        /// <summary>
        /// The title.
        /// </summary>
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged(() => Title);
            }
        }

        /// <summary>
        /// Property for showing the close button or not
        /// </summary>
        private bool _showCloseButton;
        public bool ShowCloseButton
        {
            get { return _showCloseButton; }
            set
            {
                _showCloseButton = value;
                RaisePropertyChanged(() => ShowCloseButton);
            }
        }

        /// <summary>
        /// Closes the modal.
        /// </summary>
        public void CloseModal()
        {
            Close(this);
        }
    }

    public abstract class BaseViewModel<TInit> : BaseViewModel
    {
        /// <summary>
        /// Init is called by MvvmCross.
        /// </summary>
        /// <returns>The init.</returns>
        /// <param name="parameter">Parameter.</param>
        public void Init(string parameter)
        {
            var deserialized = JsonConvert.DeserializeObject<TInit>(parameter);
            Initialize(deserialized);
        }

        /// <summary>
        /// Initialize is called by Init with a deserialized parameter.
        /// </summary>
        /// <returns>The initialize.</returns>
        /// <param name="parameter">Parameter.</param>
        protected abstract void Initialize(TInit parameter);
    }
}
