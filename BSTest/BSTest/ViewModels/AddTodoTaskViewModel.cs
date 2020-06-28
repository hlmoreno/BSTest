using BSTest.Data;
using BSTest.Model;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace BSTest.ViewModels
{
    public class AddTodoTaskViewModel : ViewModelBase
    {
        private string taskName;

        public string TaskName
        {
            get { return taskName; }
            set 
            {
                taskName = value;
                RaisePropertyChanged();
            }
        }

        private INavigationService navigationService;
        public DelegateCommand AddCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }
        public AddTodoTaskViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            this.navigationService = navigationService;
            Title = "Agregar Tarea";

            AddCommand = new DelegateCommand(AddTask);
            CancelCommand = new DelegateCommand(CancelTask);

        }

        private void CancelTask()
        {
            navigationService.GoBackAsync();
        }

        private async void AddTask()
        {
            TodoTask tarea = new TodoTask();
            tarea.TaskName = taskName;
            tarea.Done = false;
            await BDInstance.BD.GuardarTareaAsync(tarea);
            MessagingCenter.Send<AddTodoTaskViewModel>(this, "NuevaTarea");
            CancelTask();
        }
    }
}
