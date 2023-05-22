using OTTCreator.Client.Data;
using OTTCreator.Client.Models;

namespace OTTCreator.Client
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}