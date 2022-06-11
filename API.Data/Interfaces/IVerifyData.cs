using API.Entities.Common;
using API.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Data.Interfaces
{
    public interface IVerifyData
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
        /// Função criada para comparar/verificar os antigos/novos dados do usuario
        /// </summary>
        public bool VerifyData(User oldUser, IBaseUser newUser, out string msgError);
    }
}
