﻿using System;

using GiveOrTake.FrontEnd.Shared.Models;
using GiveOrTake.FrontEnd.Shared.ViewModels;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace GiveOrTake.FrontEnd.Shared.Views
{
	public partial class ItemsPage : ContentPage
	{
		ItemsViewModel viewModel;

		public ItemsPage()
		{
			InitializeComponent();

			BindingContext = viewModel = new ItemsViewModel();
		}

		async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			var item = args.SelectedItem as Item;
			if (item == null)
				return;

			await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

			// Manually deselect item
			ItemsListView.SelectedItem = null;
		}

		async void AddItem_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NewItemPage());
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			await viewModel.ExecuteLoadItemsCommand();
		}
	}
}
