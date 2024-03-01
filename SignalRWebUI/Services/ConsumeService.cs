using Newtonsoft.Json;
using SignalRWebUI.Dtos.AboutDtos;
using SignalRWebUI.Dtos.ContactDtos;
using SignalRWebUI.Dtos.DefaultDtos.SliderDtos;
using SignalRWebUI.Dtos.DiscountDtos;
using SignalRWebUI.Dtos.ProductDtos;
using SignalRWebUI.Dtos.TestimonialDtos;

namespace SignalRWebUI.Services
{
    public class ConsumeService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ConsumeService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<ResultSliderDto>> ListSliders()
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync("https://localhost:7298/api/Sliders");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
                return values;
            }
            return null;
        }

        public async Task<List<ResultDiscountDto>> ListDiscounts()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7298/api/Discount");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDiscountDto>>(jsonData);
                return values;
            }

            return null;
        }

        public async Task<List<ResultProductDto>> ListProducts()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7298/api/Product");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return values;
            }

            return null;
        }
        public async Task<List<ResultAboutDto>> ListAbouts()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7298/api/About");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return values;
            }

            return null;
        }

        public async Task<List<ResultTestimonialDto>> ListTestimonials()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7298/api/Testimonial");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                return values;
            }

            return null;
        }
        public async Task<List<ResultContactDto>> ListContacts()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7298/api/Contact");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                return values;
            }

            return null;
        }




    }
}
