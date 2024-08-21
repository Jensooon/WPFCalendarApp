using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalendarApp.Dialogs
{
    public class SaveDialogAsViewModel : BindableBase, IDialogAware
    {
        private readonly IEventAggregator eventAggregator;
        public DelegateCommand CancelDialogCommand { get; private set; }

        public string Title => "Test";

        public SaveDialogAsViewModel(IEventAggregator eventAggregator)
        {
            CancelDialogCommand = new DelegateCommand(CancelDialog);
            this.eventAggregator = eventAggregator;
        }

        private void CancelDialog()
        {
            var result = ButtonResult.OK;
            RequestClose.Invoke(new DialogResult(result));
        }

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            throw new NotImplementedException();
        }

        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {

        }
    }
}
