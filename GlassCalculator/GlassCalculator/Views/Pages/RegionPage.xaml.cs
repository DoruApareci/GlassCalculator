using GlassCalculator.ViewModels;

namespace GlassCalculator.Views.Pages;

public partial class RegionPage : ContentPage
{
	public RegionPage()
	{
        BindingContext = new ChoseRegionViewModel();
    }
}