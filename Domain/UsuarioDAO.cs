using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain
{
    public class UsuarioDAO
    {
        /// <summary>
        /// Salva um usuário no Banco de Dados
        /// </summary>
        /// <param name="user">Usuario a ser salvo.</param>
        /// <returns>Usuário Salvo, com o ID Atribuido pelo banco</returns>
        public Usuario salvar(Usuario user)
        {
            Model1Container mdl = new Model1Container();
            mdl.UsuarioSet.Add(user);
            mdl.SaveChanges();
            return user;
        }

        /// <summary>
        /// Obtem um usuário do banco.
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <returns>Usuario com o ID informado, NULL se não existe o usuário no banco</returns>
        public Usuario obterUsuario(int id)
        {
            Model1Container mdl = new Model1Container();
            return mdl.UsuarioSet.Find(id);
        }

        /// <summary>
        /// Obtem um usuário do banco.
        /// </summary>
        /// <param name="nome">Nome do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Usuario com o nome e senha informado, NULL se não existe o usuário no banco</returns>
        public Usuario obterUsuario(string nome, string senha)
        {
            try
            {
                Model1Container mdl = new Model1Container();
                return mdl.UsuarioSet.FirstOrDefault(a => a.Nome.Equals(nome) && a.Senha.Equals(senha));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void atualizar(Usuario user)
        {
            try
            {
                Model1Container mdl = new Model1Container();
                mdl.Set<Usuario>().Attach(user);
                mdl.Entry(user).State = System.Data.EntityState.Modified;
                mdl.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Exclui um usuário do banco
        /// </summary>
        /// <param name="user">usuario a ser excluído</param>
        /// <returns>numero de usuários excluídos</returns>
        public int excluir(Usuario user)
        {
            Model1Container mdl = new Model1Container();
            mdl.UsuarioSet.Remove(user);
            return mdl.SaveChanges();
        }

        /// <summary>
        /// Lista todos os usuários do banco.
        /// </summary>
        /// <returns></returns>
        public List<Usuario> obterUsuarios()
        {
            Model1Container mdl = new Model1Container();
            return mdl.UsuarioSet.ToList<Usuario>();
        }
    }
}