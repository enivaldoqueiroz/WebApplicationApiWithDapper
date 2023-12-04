using WebApplicationWithDapper.Data;

namespace WebApplicationWithDapper.Repositories
{
    public interface ITarefaRepository
    {
        Task<List<Tarefa>> GetTarefasAsync();
        Task<Tarefa> GetTarefaByAsync(int id);
        Task<TarefaConteiner> GetTarefasEContadorAsync();
        Task<int> SaveAsync(Tarefa novaTarefa);
        Task<int> UpdateTarefaStatusAsync(Tarefa atulizaTarefa);
        Task<int> DeleteAsync(int id);
    }
}
