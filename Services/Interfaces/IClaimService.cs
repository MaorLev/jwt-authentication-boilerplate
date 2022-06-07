using jwt_authentication_boilerplate.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace jwt_authentication_boilerplate.Services.Interfaces
{
    public interface IClaimService
    {
        public Task<ClaimData> GetClaim(int id);
        public Task<ICollection<ClaimData>> GetClaims();
        public Task<bool> PersistClaimsForUser(User persistUser);
    }
}
