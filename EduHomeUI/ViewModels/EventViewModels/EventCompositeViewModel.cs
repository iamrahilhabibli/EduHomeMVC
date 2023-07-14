using EduHomeUI.ViewModels.HomeViewModels;
using EduHomeUI.ViewModels.SubscribeViewModels;

namespace EduHomeUI.ViewModels.EventViewModels
{
    public class EventCompositeViewModel
    {
        public EventIndexViewModel EventIndex { get; set; }
        public SubscriberCreateViewModel SubscriberCreate { get; set; }
    }
}
