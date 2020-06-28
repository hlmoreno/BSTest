using BSTest.Data;
using BSTest.Model;
using ImTools;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace BSTest.ViewModels
{
    public class TodoListViewModel : ViewModelBase
    {
        private ObservableCollection<TodoTask> taskList;

        private INavigationService navigationService;

        public DelegateCommand AddCommand { get; private set; }
        public DelegateCommand CheckCommand { get; private set; }
        public DelegateCommand DeleteCommand { get; private set; }

        private TodoTask itemSelected;

        public TodoTask ItemSelected
        {
            get { return itemSelected; }
            set { itemSelected = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<TodoTask> TaskList
        {
            get { return taskList; }
            set 
            { 
                taskList = value;
                RaisePropertyChanged();
            }
        }

        public TodoListViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            this.navigationService = navigationService;
            Title = "Lista de tareas";
           

            AddCommand = new DelegateCommand(AddTask);
            CheckCommand = new DelegateCommand(CheckTask);
            DeleteCommand = new DelegateCommand(DeleteTask);

            TaskList = new ObservableCollection<TodoTask>();
            UpdateTareas();

            MessagingCenter.Subscribe<AddTodoTaskViewModel>(this, "NuevaTarea", (e) =>
            {
                UpdateTareas();
            });

        }

        private async void DeleteTask()
        {
            if(ItemSelected != null)
            {
                await BDInstance.BD.BorrarTareaAsync(ItemSelected.Id);
                UpdateTareas();
            }
        }

        private async void CheckTask()
        {
            if (ItemSelected != null)
            {
                await BDInstance.BD.MarcarTareaAsync(ItemSelected.Id);
                UpdateTareas();
            }
        }

        private void AddTask()
        {
            navigationService.NavigateAsync("AddTodoTask");
        }

        private void UpdateTareas()
        {
            TaskList.Clear();
            var list = BDInstance.BD.TraerTareas().Result;
            foreach (var item in list)
                TaskList.Add(item);
        }
    }
}
