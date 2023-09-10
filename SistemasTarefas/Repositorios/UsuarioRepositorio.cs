using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemasTarefas.Data;
using SistemasTarefas.Models;
using SistemasTarefas.Repositorios.Interfaces;
using System.Text.RegularExpressions;

namespace SistemasTarefas.Repositorios
{
	public class UsuarioRepositorio:IUsuarioRepositorio
	{
		private readonly SistemaTarefasDataBaseContex baseContex;
		public UsuarioRepositorio(SistemaTarefasDataBaseContex sistemaTarefasDataBaseContex) {
			baseContex = sistemaTarefasDataBaseContex;
		}

		public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
		{
			await baseContex.Usuarios.AddAsync(usuario);
			await baseContex.SaveChangesAsync();
			return usuario;
		}

		public async Task<bool> Apagar(int id)
		{
            UsuarioModel usuarioModel = await BuscarPorId(id);
            if (usuarioModel == null)
            {
                throw new Exception($"Usuario para o ID:{id}, não foi encontrado ou não existe no banco de dados");
            }
            baseContex.Usuarios.Remove(usuarioModel);
            await baseContex.SaveChangesAsync();
            return true;
        }

		public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
		{
			UsuarioModel usuarioModel = await BuscarPorId(id);
			if (usuarioModel == null)
			{
				throw new Exception($"Usuario para o ID:{id}, não foi encontrado ou não existe no banco de dados");
			}
			usuarioModel.Name = usuario.Name;
            usuarioModel.Email = usuario.Email;
			baseContex.Usuarios.Update(usuarioModel);
            baseContex.SaveChanges();
			return usuarioModel;
        }

		public async Task<UsuarioModel> BuscarPorId(int id)
		{
            return await baseContex.Usuarios.FirstOrDefaultAsync(x => x.Id == id);//x => x.Id == id é uma função lambda, ou seja, definir uma função anônima ou um delegado. 
			//nesse caso a lambda representa um critério de filtragem ou projeção.  x representa ela, => indica q é lambda, x.Id == id expressão booleana que a função lambda retorna
        }

		public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
		{
            return await baseContex.Usuarios.ToListAsync();
        }
	}
}
