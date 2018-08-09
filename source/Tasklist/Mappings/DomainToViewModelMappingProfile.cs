using AutoMapper;
using Tasklist.Model.Models;
using Tasklist.Web.ViewModels;

namespace Tasklist.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Task, TaskViewModel>();
        }
    }
}