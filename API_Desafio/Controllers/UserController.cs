using API.Common;
using API.Common.Utils;
using API.Data.Interfaces;
using API.Entities.User;
using API_Desafio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Desafio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        IUserRepository UserRepository { get; set; }
        public UserController(IUserRepository user)
        {
            UserRepository = user;
        }

        /// <summary>
        /// Cria um novo usuario
        /// </summary>
        /// <returns>Um novo usuario criado</returns>
        /// <response code="200">Retorna o usuario criado</response>
        /// <response code="405">Se o item não for criado, retorna uma mensagem com o problema</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse))]
        public async Task<ActionResult> Post(UserModelDto user)
        {
            string msgError = string.Empty;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (UserRepository.VerifyEmail(user.Email, out msgError))
                return BadRequest(new ApiResponse(405, msgError));
            if (UserRepository.VerifyCpf(user.Cpf, out msgError))
                return BadRequest(new ApiResponse(405, msgError));

            var usr = new User
            {
                Nome = user.Nome,
                Email = user.Email,
                Cpf = user.Cpf,
                DataNasc = user.DataNasc,
                Senha = Encrypt.SHA256(user.Senha),
            };

            await UserRepository.Add(usr);

            return Ok(new ApiResponseOk<User>(usr));
        }

        /// <summary>
        /// Retorna a lista de usuario
        /// </summary>
        /// <returns>Uma lista com os usuarios</returns>
        /// <response code="200">Retorna a lista</response>
        /// <response code="404">Não foi encontrado nenhum usuario</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponseOk<List<User>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse))]
        public async Task<ActionResult> GetAll()
        {
            var ListUsers = await UserRepository.GetAll();

            if (ListUsers.Count == 0)
                return NotFound(new ApiResponse(404, "Nenhum usuario encontrado"));

            return Ok(new ApiResponseOk<List<User>>(ListUsers));
        }

        /// <summary>
        /// Retorna um usuario
        /// </summary>
        /// <returns>Um usuario</returns>
        /// <response code="200">Retorna o usuario</response>
        /// <response code="404">Usuario não existe</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponseOk<User>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse))]
        [Route("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var User = await UserRepository.GetById(id);

            if (User == null)
                return NotFound(new ApiResponse(404, "Usuario não encontrado"));

            return Ok(new ApiResponseOk<User>(User));
        }

        /// <summary>
        /// Edita os dados de um usuario
        /// </summary>
        /// <returns>Retorna os dados do usuario editado</returns>
        /// <response code="200">Usuario editado</response>
        /// <response code="400">Erro ao editar</response>
        /// <response code="404">Usuario não existe</response>
        [HttpPut]
        [Route("Edit")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponseOk<User>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse))]
        public async Task<ActionResult> Edit(int id, UserModelEdit userData)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id == 0)
                return BadRequest(new ApiResponse(405, "ID invalido"));

            var user = await UserRepository.GetById(id);

            if (user == null)
                return NotFound(new ApiResponse(404, "Usuario não existe"));

            if (UserRepository.VerifyData(user, userData, out string msgError))
                return BadRequest(new ApiResponse(405, msgError));

            if (user.Nome != userData.Nome && userData.Nome != null)
                user.Nome = userData.Nome;
            else if (user.DataNasc != userData.DataNasc && userData.DataNasc != null)
                user.DataNasc = userData.DataNasc;
            else if (user.Senha != null)
                user.Senha = Encrypt.SHA256(userData.Senha);

            user.Email = userData.Email;
            user.Cpf = userData.Cpf;

            await UserRepository.Update(user);

            return Ok(new ApiResponseOk<User>(user));
        }

        /// <summary>
        /// Delete um usuario
        /// </summary>
        /// <returns>Retorna os dados do usuario editado</returns>
        /// <response code="200">Usuario deletado</response>
        /// <response code="404">Usuario não existe</response>
        [HttpDelete]
        [Route("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse))]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await UserRepository.GetById(id);

            if (user == null)
                return NotFound(new ApiResponse(404, "Usuario não existe"));

            await UserRepository.Delete(user);

            return Ok(new ApiResponse(200, "Usuario Deletado"));
        }
    }
}
