using GlassCalculator.Models;
using System.Reflection;
using System.Text.Json;

namespace GlassCalculator.Services
{
    public class GlassTypeService
    {
        public async Task<List<GlassType>> LoadGlassTypesAsync()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "GlassCalculator.Resources.Data.GlassTypes.json";

            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            var glassTypes = await JsonSerializer.DeserializeAsync<List<GlassType>>(stream);
            return glassTypes;
        }
    }
}
