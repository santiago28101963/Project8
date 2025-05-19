// Project8/Resources/Views/Pages/VehiculoPage.xaml.cs
using Project8.ViewModels;

namespace Project8.Resources.Views.Pages
{
    public partial class VehiculoPage : ContentPage
    {
        private readonly VehiculoViewModel _viewModel;

        public VehiculoPage()
        {
            InitializeComponent();
            _viewModel = new VehiculoViewModel();
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.CargarVehiculosAsync();
        }
    }
}
