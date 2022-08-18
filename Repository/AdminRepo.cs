using Microsoft.EntityFrameworkCore;
using PlacementApplicationNew.Model;

namespace PlacementApplicationNew.Repository
{
    public class AdminRepo : IAdmin
    {
        private readonly PlacementAppContext _context;
        public AdminRepo(PlacementAppContext context)
        {
            _context = context;
        }
        public async Task<Admin> AddNewAdmin(Admin admin)
        {
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();
            return admin;
        }

        public Task DeleteAdmin(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Admin> GetAdmin(int id)
        {
            throw new NotImplementedException();
        }

       
            public async Task<Admin> Login(Admin admin)
            {
                var result = await (from i in _context.Admins where i.Password == admin.Password && i.UserId == admin.UserId select i).SingleOrDefaultAsync();
                try
                {
                    if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }
    }

