using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using World.Web.DTO;

namespace World.Web.Pages
{
    public class CountryModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CountryModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]  
        public List<CountryDTO> Countries {  get; set; }

        public async void OnGet()
        {
            var httpClient = _httpClientFactory.CreateClient("WorldWebAPI");
            Countries = await httpClient.GetFromJsonAsync<List<CountryDTO>>("api/Country/GetCountry");
        }
    }
}
