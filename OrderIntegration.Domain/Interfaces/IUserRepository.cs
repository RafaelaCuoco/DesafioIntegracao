using System.Collections.Generic;
using OrderIntegration.Domain.Entities;

namespace OrderIntegration.Domain.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Obtém todos os usuários.
        /// </summary>
        /// <returns>Uma lista de usuários.</returns>
        IEnumerable<User> GetAllUsers();

        /// <summary>
        /// Obtém um usuário pelo ID.
        /// </summary>
        /// <param name="userId">O ID do usuário.</param>
        /// <returns>O usuário encontrado ou null se não existir.</returns>
        User GetUserById(int userId);
        void AddOrUpdateUser(User user);

        /// <summary>
        /// Adiciona um novo usuário ao repositório.
        /// </summary>
        /// <param name="user">O usuário a ser adicionado.</param>
        void AddUser(User user);

        /// <summary>
        /// Atualiza um usuário existente no repositório.
        /// </summary>
        /// <param name="user">O usuário a ser atualizado.</param>
        void UpdateUser(User user);

        /// <summary>
        /// Remove um usuário do repositório.
        /// </summary>
        /// <param name="userId">O ID do usuário a ser removido.</param>
        void DeleteUser(int userId);

        /// <summary>
        /// Salva as alterações no repositório.
        /// </summary>
        void SaveChanges();
    }
}