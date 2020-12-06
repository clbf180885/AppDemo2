using System.ComponentModel;
using Xamarin.Forms;
using AppDemo.ViewModels;

namespace AppDemo.Views
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