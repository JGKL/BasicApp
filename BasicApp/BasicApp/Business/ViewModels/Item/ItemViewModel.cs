using System;

namespace BasicApp.Business.ViewModels
{
    public class ItemViewModel : BaseViewModel<ItemViewModel>
    {
        public ItemViewModel()
        {
            Title = "Item";
        }

        protected override void Initialize(ItemViewModel parameter)
        {
            
        }
    }
}
