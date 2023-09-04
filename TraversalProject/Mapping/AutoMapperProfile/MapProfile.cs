using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;

namespace TraversalProject.Mapping.AutoMapperProfile
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementAddDto, Announcement>(); // AnnouncementAddDTOs dto'sunun Announcement sınıfıyla(tablosuyla) eşleştirecek
            CreateMap<Announcement, AnnouncementAddDto>(); // Yukarıdaki işlemin tersi

            CreateMap<AppUserRegisterDTOs, AppUser>();
            CreateMap<AppUser, AppUserRegisterDTOs>();

            CreateMap<AppUserLoginDTOs, AppUser>();
            CreateMap<AppUser, AppUserLoginDTOs>();
            
            CreateMap<AnnouncementListDto, Announcement>();
            CreateMap<Announcement, AnnouncementListDto>();

            CreateMap<AnnouncementUpdateDto, Announcement>();
            CreateMap<Announcement, AnnouncementUpdateDto>();

            CreateMap<SendMessageDto, ContactUs>().ReverseMap();  // ReverseMap ile tersini de yazmış gibi oluyoruz
        }
    }
}
