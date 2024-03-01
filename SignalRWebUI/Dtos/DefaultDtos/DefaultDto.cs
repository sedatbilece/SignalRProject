using SignalRWebUI.Dtos.AboutDtos;
using SignalRWebUI.Dtos.ContactDtos;
using SignalRWebUI.Dtos.DefaultDtos.SliderDtos;
using SignalRWebUI.Dtos.DiscountDtos;
using SignalRWebUI.Dtos.ProductDtos;
using SignalRWebUI.Dtos.TestimonialDtos;

namespace SignalRWebUI.Dtos.DefaultDtos
{
    public class DefaultDto
    {
        public List<ResultSliderDto> Sliders { get; set; }
        public List<ResultDiscountDto> Discounts { get; set; }
        public List<ResultProductDto> Products { get; set; }
        public List<ResultTestimonialDto> Testimonials { get; set; }
        public ResultAboutDto About { get; set; }
        public ResultContactDto Contact { get; set; }
    }
}
