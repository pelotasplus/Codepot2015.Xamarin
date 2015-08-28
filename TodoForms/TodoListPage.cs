using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

namespace TodoForms
{
	public class TodoListPage : ContentPage
	{
		ListView listView;

		public TodoListPage ()
		{
			Title = "TodoForms";

			listView = new ListView ();
			listView.ItemTemplate = new DataTemplate 
					(typeof (TodoItemCell));
			listView.ItemSelected += (sender, e) => {
				var todoItem = (Item)e.SelectedItem;

//				var todoPage = new TodoItemPage();
//				todoPage.BindingContext = todoItem;
//
				Debug.WriteLine("item selected " + todoItem.Name);
//
//				Navigation.PushAsync(todoPage);
			};

			var layout = new StackLayout();
			layout.Children.Add(listView);
			layout.VerticalOptions = LayoutOptions.FillAndExpand;

			Content = layout;
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			listView.ItemsSource = new List<Item>();

			FetchItems ();
		}

		public async void FetchItems ()
		{
			List<Item> ret = await ApiServices.FetchItemsAsync();
			listView.ItemsSource = ret;
		}
	}
}

