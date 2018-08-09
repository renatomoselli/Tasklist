using AutoMapper;
using Tasklist.Model.Models;
using Tasklist.Web.ViewModels;

namespace Tasklist.Mappings
{

    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<TaskViewModel, Task>();
        }
    }
}