using API.Data.Base;
using API.Entities.Common;
using API.Entities.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Data.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        /// <summary>
        /// Edita os dados alterados
        /// </summary>
        public void EditUserData(IBaseUser newUser, ref User User);
    }
}
