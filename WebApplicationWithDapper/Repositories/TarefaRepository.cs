using Dapper;
using WebApplicationWithDapper.Data;

namespace WebApplicationWithDapper.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        public DbSession _dbSession;

        public TarefaRepository(DbSession dbSession)
        {
            _dbSession = dbSession;
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var connection = _dbSession.Connection)
            {
                string command = @"DELETE FROM Tarefas 
                                   WHERE Id = @id";

                var resultado = await connection.ExecuteAsync(sql: command, param: new { id });
                return resultado;
            }
        }

        public async Task<Tarefa> GetTarefaByAsync(int id)
        {
            using (var connection = _dbSession.Connection)
            {
                string query = "SELECT * FROM Tarefas WHERE Id = @Id";
                Tarefa tarefa = await connection.QueryFirstOrDefaultAsync<Tarefa>(sql: query, param: new { id });
                return tarefa;
            }
        }

        public async Task<List<Tarefa>> GetTarefasAsync()
        {
            using (var connection = _dbSession.Connection)
            {
                string query = "SELECT * FROM Tarefas";
                List<Tarefa> tarefas = (await connection.QueryAsync<Tarefa>(sql: query)).ToList();
                return tarefas;
            }
        }

        public async Task<TarefaConteiner> GetTarefasEContadorAsync()
        {
            using (var connection = _dbSession.Connection)
            {
                string query = 
                    @"SELET COUNT(*) FROM Tarefas
                    SELECT * FROM Tarefas";
                var reader = await connection.QueryMultipleAsync(sql: query);

                return new TarefaConteiner
                {
                    Contador = (await reader.ReadAsync<int>()).FirstOrDefault(),
                    Tarefas = (await reader.ReadAsync<Tarefa>()).ToList()
                };
            }
        }

        public async Task<int> SaveAsync(Tarefa novaTarefa)
        {
            using (var connection = _dbSession.Connection)
            {
                string command = @"INSERT INTO Tarefas(Descricao, IsCompleta)
                                    VALUES(@Descricao, @IsCompleta)";

                var result = await connection.ExecuteAsync(sql: command, param: novaTarefa);

                return result;
            }
        }

        public async Task<int> UpdateTarefaStatusAsync(Tarefa atulizaTarefa)
        {
            using (var connection = _dbSession.Connection)
            {
                string command = @"UPDATE Tarefas SET IsCompleta = @IsCompleta 
                                   WHERE Id = @Id";

                var result = await connection.ExecuteAsync(sql: command, param: atulizaTarefa);

                return result;
            }
        }
    }
}
