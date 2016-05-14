using TMD.Models.DomainModels;
using TMD.Web.ViewModels.UserRoles;

namespace TMD.Web.ModelMappers
{
    public static class AspNetRoleMapper
    {
        public static AspNetRoleModel CreateFromServerToClient(this AspNetRole source)
        {
       
            return new AspNetRoleModel
            {
                Id = source.Id,
                Name = source.Name
            };
        }

      
     
    }
}