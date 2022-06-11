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
        /// Função verifica se ja existe alguma conta com o cpf
        /// </summary>
        public bool VerifyCpf(string cpf, out string msgError);
        /// <summary>
        /// Função verifica se ja existe alguma conta com o email
        /// </summary>
        public bool VerifyEmail(string email, out string msgError);
        /// <summary>
        /// Função criada para comparar os antigos/novos dados do usuario
        /// </summary>
        public bool VerifyData(User oldUser, IBaseUser newUser, out string msgError);
    }
}
