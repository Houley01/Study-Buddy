using System.ComponentModel;
using Xamarin.Forms;
using Study_Buddy.ViewModels;

namespace Study_Buddy.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}