using jwt_authentication_boilerplate.Data;
using jwt_authentication_boilerplate.Data.Entities;
using jwt_authentication_boilerplate.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jwt_authentication_boilerplate.Services
{
    public class ClaimService : IClaimService
    {
        private readonly DBContext m_db;
        public ClaimService(DBContext m_db)
        {
            this.m_db = m_db;
        }
        public async Task<ClaimData> GetClaim(int id)
        {
            return await m_db.ClaimData.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ICollection<ClaimData>> GetClaims()
        {
            return await m_db.ClaimData.ToListAsync();
        }
        public async Task<bool> PersistClaimsForUser(User persistUser)
        {

            ClaimData name = new ClaimData
            {
                Type = "name",
                Value = persistUser.FirstName,
                UserId = persistUser.Id
            };

            ClaimData role = new ClaimData
            {
                Type = "role",
                Value = persistUser.Role.Name,
                UserId = persistUser.Id
            };

            ClaimData userId = new ClaimData
            {
                Type = "userId",
                Value = persistUser.Id.ToString(),
                UserId = persistUser.Id
            };

            await m_db.ClaimData.AddAsync(userId);
            await m_db.ClaimData.AddAsync(name);
            await m_db.ClaimData.AddAsync(role);


            int c = await m_db.SaveChangesAsync();
            return c > 1;
        }
    }
}
