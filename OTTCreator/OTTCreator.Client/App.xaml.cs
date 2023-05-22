using OTTCreator.Client.Data;
using OTTCreator.Client.Models;
using OTTCreator.Client.Pages;

namespace OTTCreator.Client
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            Routing.RegisterRoute("ContentItemPage", typeof(ContentItemPage));
            Routing.RegisterRoute("CategoryPage", typeof(CategoryPage));
        }
    }
}