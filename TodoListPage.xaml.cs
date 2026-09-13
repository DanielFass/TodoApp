using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Views
{
    // Extraneous Xamarin compilation tags removed to prevent file decoupling
    public partial class TodoListPage : ContentPage
    {
        public TodoListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                TodoItemDatabase database = await TodoItemDatabase.Instance;
                listView.ItemsSource = await database.GetItemsAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Startup error", ex.Message, "OK");
            }
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoItemPage
            {
                BindingContext = new TodoItem()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TodoItemPage
                {
                    BindingContext = e.SelectedItem as TodoItem
                });
            }
        }
    }
}
