using Microsoft.AspNetCore.Mvc;
using WebApplicationWithDapper.Data;
using WebApplicationWithDapper.Repositories;

namespace WebApplicationWithDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        public readonly ITarefaRepository _tarefaRepository;

        public TarefasController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        [HttpGet]
        [Route("tarefas")]
        public async Task<IActionResult> GetTarefasAsync()
        {
            var result = await _tarefaRepository.GetTarefasAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("tarefa")]
        public async Task<IActionResult> GetTodosItemByIdAsync(int id)
        {
            var tarefa = await _tarefaRepository.GetTarefaByAsync(id);
            return Ok(tarefa);
        }

        [HttpGet]
        [Route("tarefascontador")]
        public async Task<IActionResult> GetTodosAndCountAsync() 
        {
            var resultadon = await _tarefaRepository.GetTarefasEContadorAsync();
            return Ok(resultadon);
        }

        [HttpPost]
        [Route("criartarefa")]
        public async Task<IActionResult> SaveAsync(Tarefa novaTarefa)
        {
            var result = await _tarefaRepository.SaveAsync(novaTarefa);
            return Ok(result);
        }

        [HttpPost]
        [Route("atulizastatus")]
        public async Task<IActionResult> UpdateTodosStatusAsync(Tarefa atulizaTarefa)
        {
            var result = await _tarefaRepository.UpdateTarefaStatusAsync(atulizaTarefa);
            return Ok(result);
        }

        [HttpDelete]
        [Route("deletatarefa")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var tareafa = _tarefaRepository.DeleteAsync(id);
            return Ok(tareafa);
        }
    }
}
