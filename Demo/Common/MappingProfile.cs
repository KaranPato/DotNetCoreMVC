using AutoMapper;
using Demo.Models;
using Demo.ViewModels;
using System.Linq;
using System.Collections.Generic;

namespace Demo.Common {
    public class MappingProfile : Profile {

        public MappingProfile ( ) {
            #region

            CreateMap<List<User>, List<UserVM>> ( );

            #endregion
        }
    }
}