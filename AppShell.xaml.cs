namespace Project8
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Registro de la ruta para navegación a VehiculoPage
            Routing.RegisterRoute("vehiculo", typeof(Project8.Resources.Views.Pages.VehiculoPage));
        }
    }
}
