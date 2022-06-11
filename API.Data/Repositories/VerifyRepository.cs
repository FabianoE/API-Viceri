using API.Data.Base;
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
    public class VerifyRepository : RepositoryBase<User>, IVerifyData
    {
        public VerifyRepository(DataContext context) : base(context)
        {
        }

        public bool VerifyCpf(string cpf, out string msgError)
        {
            msgError = string.Empty;

            var isNumeric = long.TryParse(cpf, out _);

            if (!isNumeric)
            {
                msgError = "Somente numeros no CPF";
                return true;
            }

            int checkCpfCount = _context.Set<User>().Count(x => x.Cpf == cpf);

            if (checkCpfCount > 0)
            {
                msgError = "CPF Em uso";
                return true;
            }

            return false;
        }

        public bool VerifyEmail(string email, out string msgError)
        {
            msgError = string.Empty;

            int checkCpfCount = _context.Set<User>().Count(x => x.Email == email);

            if (checkCpfCount > 0)
            {
                msgError = "Email Em uso";
                return true;
            }

            return false;
        }

        public bool VerifyData(User oldUser, IBaseUser newUser, out string msgError)
        {
            msgError = string.Empty;

            if (oldUser != newUser)
            {
                if (oldUser.Email != newUser.Email)
                {
                    return VerifyEmail(newUser.Email, out msgError); //Retorna true se existir alguma conta com o email
                }
                else if (oldUser.Cpf != newUser.Cpf)
                {
                    return VerifyCpf(newUser.Cpf, out msgError); //Retorna true se existir alguma conta com o cpf
                }
            }

            return false;
        }
    }
}
