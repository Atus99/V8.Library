using AutoMapper;
using V8.Application.Models.ViewModels;
using V8.Domain.Models.V8;

namespace V8.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            V8Mapper();
        }

        #region V8
        private void V8Mapper()
        {
            CreateMap<VMUser, User>();
            CreateMap<User, VMUser>();
        }
        #endregion
    }
}
