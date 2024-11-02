using GlassCalculator.Models;
using GlassCalculator.Models.Enums;
using GlassCalculator.Services;

namespace GlassCalculator.Views.Pages;

public partial class GlassPickerPage : ContentPage
{
    private GlassTypeService _glassTypeService;
    private List<GlassType> _glassTypes;
    public GlassPickerPage()
    {
        InitializeComponent();
        _glassTypeService = new GlassTypeService();
        LoadGlassTypes();
    }

    private async void LoadGlassTypes()
    {
        _glassTypes = await _glassTypeService.LoadGlassTypesAsync();
        var thicknesses = _glassTypes.Select(g => g.Thickness).Distinct().ToList();

        ThicknessPicker.ItemsSource = thicknesses;
    }

    private void OnThicknessChanged(object sender, EventArgs e)
    {
        if (ThicknessPicker.SelectedItem == null)
            return;
        int selectedThickness = (int)ThicknessPicker.SelectedItem;
        var colors = _glassTypes
            .Where(g => g.Thickness == selectedThickness)
            .Select(g => g.GlassColor)
            .Distinct()
            .ToList();

        ColorPicker.ItemsSource = colors;
        ColorPicker.SelectedIndex = -1;
    }

    private void OnColorChanged(object sender, EventArgs e)
    {
        if (ColorPicker.SelectedItem == null)
            return;
        GlassColorEnum selectedColor = (GlassColorEnum)ColorPicker.SelectedItem;
        int selectedThickness = (int)ThicknessPicker.SelectedItem;

        var workTypes = _glassTypes
            .Where(g => g.Thickness == selectedThickness && g.GlassColor == selectedColor)
            .Select(g => g.Price.GlassWorkType)
            .Distinct()
            .ToList();

        WorkTypePicker.ItemsSource = workTypes;
        WorkTypePicker.SelectedIndex = -1;
    }
}
