// MainPage.xaml.cs
using Project8.ViewModels;
using System.Diagnostics;

namespace Project8
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        private VehiculoViewModel ViewModel => BindingContext as VehiculoViewModel;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Es una línea de debug que imprime un mensaje en la ventana de salida (Output) de Visual Studio mientras la app está corriendo.
            // Sirve para ayudarte a saber si cierta parte del código sí se está ejecutando.
            // No se muestra en la interfaz del usuario, solo en el panel Output → Debug.

            System.Diagnostics.Debug.WriteLine("Entrando a OnAppearing");

            if (ViewModel != null)
            {
                    System.Diagnostics.Debug.WriteLine("Llamando a ViewModel.CargarVehiculosAsync");
                    await ViewModel.CargarVehiculosAsync();
            }
            else
            {
                    System.Diagnostics.Debug.WriteLine("ViewModel es NULL");
            }
}

        //private void OnCounterClicked(object sender, EventArgs e)
        //{
        //    count++;

        //    if (count == 1)
        //        CounterBtn.Text = $"Clicked {count} time";
        //    else
        //        CounterBtn.Text = $"Clicked {count} times";

        //    SemanticScreenReader.Announce(CounterBtn.Text);
        //}
    }
}
