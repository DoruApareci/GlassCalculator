using GlassCalculator.Models;
using GlassCalculator.Views;
using GlassCalculator.Views.Pages;

namespace GlassCalculator
{
    public partial class MainPage : ContentPage//, INotifyPropertyChanged
    {
        public List<Models.SideMenuBar.MenuBarItem> MenuElements { get; set; }
        public MainPage()
        {
            InitializeComponent();
            MenuElements = new ()
            {
                new () { MenuItemName = "Home", MenuItemIconString = "home.png" },
                new () { MenuItemName = "Settings", MenuItemIconString = "settings.png" },
                new () { MenuItemName = "Region", MenuItemIconString = "settings.png" },
                new () { MenuItemName = "GlassPiker", MenuItemIconString = "settings.png" }
            };
            BindingContext = this;
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            SideMenuBar.ToggleDrawer();
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Models.SideMenuBar.MenuBarItem selectedMenuItem)
            {
                MainContent.Content = selectedMenuItem.MenuItemName switch
                {
                    "Home" => new HomeView().Content,
                    "Settings" => new SettingsView().Content,
                    "Region" => new RegionPage().Content,
                    "GlassPiker" => new GlassPickerPage().Content,
                    _ => null,
                };
                SideMenuBar.ToggleDrawer();
            }
        }
    }

}
