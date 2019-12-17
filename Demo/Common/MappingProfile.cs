using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Demo.Models;
using Demo.ViewModels;

namespace Demo.Common {
    public class MappingProfile : Profile {

        public MappingProfile ( ) {
            #region

            CreateMap<List<User>, List<UserVM>> ( );

            #endregion
        }
    }
}