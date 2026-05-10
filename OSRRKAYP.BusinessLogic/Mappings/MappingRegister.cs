using OSRRKAYP.BusinessLogic.DTOs;
using OSRRKAYP.Entities;
using Mapster;

namespace OSRRKAYP.BusinessLogic.Mappings
{
    public class MappingRegister : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Product, BrandResponse>()
                .Map(br => br.BrandName, p => p.Name);

            config.NewConfig<User, User>()
                .Map(ud => ud.Role, u => u.Role);
        }
    }
}
