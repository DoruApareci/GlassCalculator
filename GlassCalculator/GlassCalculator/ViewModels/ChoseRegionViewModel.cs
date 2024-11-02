using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;

namespace GlassCalculator.ViewModels
{
    public class ChoseRegionViewModel : INotifyPropertyChanged
    {
        private GlassCalculator.Models.Region _selectedRegion;

        public ObservableCollection<GlassCalculator.Models.Region> Regions { get; set; }

        public GlassCalculator.Models.Region SelectedRegion { get; set; }

        public ChoseRegionViewModel()
        {
            LoadRegions();
        }

        private async void LoadRegions()
        {
            var regions = await LoadRegionsFromJsonAsync();
            Regions = new ObservableCollection<Models.Region>(regions.OrderBy(r => r.Name));
        }

        private async Task<ObservableCollection<Models.Region>> LoadRegionsFromJsonAsync()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "GlassCalculator.Resources.Data.Regions.json";

            using Stream stream = assembly.GetManifestResourceStream(resourceName);

            using StreamReader reader = new StreamReader(stream);
            string json = await reader.ReadToEndAsync();
            var regions = JsonConvert.DeserializeObject<List<Models.Region>>(json);
            return new ObservableCollection<Models.Region>(regions);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
