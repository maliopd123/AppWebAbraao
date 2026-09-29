using AppWebAbraao.Configs;
using AppWebAbraao.Model;
using MySql.Data.MySqlClient;

namespace AppWebAbraao.DAO
{
    public class ProcessoDAO
    {
        private readonly Conexao _conexao;

        public ProcessoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Processo> Listar()
        {
            var lista = new List<Processo>();

            using var conexao = _conexao.GetConnection();
            using var comando = new MySqlCommand(
                "SELECT id_pro, numero_pro, data_pro, interessado_pro, assunto_pro, descricao_pro, situacao_pro FROM processos;",
                conexao);
            using var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                lista.Add(MapearProcesso(leitor));
            }

            return lista;
        }

        public void Inserir(Processo processo)
        {
            using var conexao = _conexao.GetConnection();
            using var comando = new MySqlCommand(@"
                INSERT INTO processos
                    (numero_pro, data_pro, interessado_pro, assunto_pro, descricao_pro, situacao_pro)
                VALUES
                    (@numero, @data, @interessado, @assunto, @descricao, @situacao);", conexao);

            comando.Parameters.AddWithValue("@numero", processo.Numero.Trim());
            comando.Parameters.AddWithValue("@data", processo.Data!.Value.Date);
            comando.Parameters.AddWithValue("@interessado", processo.Interessado.Trim());
            comando.Parameters.AddWithValue("@assunto", processo.Assunto.Trim());
            comando.Parameters.AddWithValue("@descricao", processo.Descricao?.Trim() ?? string.Empty);
            comando.Parameters.AddWithValue("@situacao", processo.Situacao);
            comando.ExecuteNonQuery();
        }

        private static Processo MapearProcesso(MySqlDataReader leitor)
        {
            return new Processo
            {
                Id = leitor.GetInt32("id_pro"),
                Numero = DAOHelper.GetString(leitor, "numero_pro"),
                Data = DAOHelper.GetDateTime(leitor, "data_pro"),
                Interessado = DAOHelper.GetString(leitor, "interessado_pro"),
                Assunto = DAOHelper.GetString(leitor, "assunto_pro"),
                Descricao = DAOHelper.GetString(leitor, "descricao_pro"),
                Situacao = DAOHelper.GetString(leitor, "situacao_pro")
            };
        }
    }
}
