using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trial_App.Pages.ToDo_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToggleListTrial : ContentPage
    { 
        ObservableCollection<string> ToDoListitems { get; set; }
        ObservableCollection<string> completedListItems { get; set; }
        public ToggleListTrial()
        {
            InitializeComponent();
            setlistData();
        }

        private void setlistData()
        {
            ToDoListitems = new ObservableCollection<string>();
            ToDoListitems.Add("Item 1");
            ToDoListitems.Add("Item 2");
            ToDoListitems.Add("Item 3");
            ToDoListitems.Add("Item 4");
            ToDoListitems.Add("Item 5");
            ToDoListitems.Add("Item 6");
            ToDoListitems.Add("Item 7");
            ToDoListitems.Add("Item 8");
            ToDoListitems.Add("Item 9");
            todoItems.ItemsSource = ToDoListitems;
        }

        private void taskCompleted(object sender, CheckedChangedEventArgs e)
        {
            
        }
    }
}