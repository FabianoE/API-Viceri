using API.Common.Utils;
using API.Data.Interfaces;
using API.Entities.Common;
using API.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)  {  }

        public void EditUserData(IBaseUser newUser, ref User user)
        {
            if (user.Nome != newUser.Nome)
                user.Nome = newUser.Nome;

            if (user.DataNasc != newUser.DataNasc)
                user.DataNasc = newUser.DataNasc;

            if (user.Senha != null)
                user.Senha = Encrypt.SHA256(newUser.Senha);

            user.Email = newUser.Email;
            user.Cpf = newUser.Cpf;
        }
    }
}
