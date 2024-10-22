using IdentityApi.Data;
using IdentityApi.Models;
using IdentityApi.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityApi.Controllers
{
    [ApiController]
    [Route("v1")]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        [Route("GetTodos")]
        [Authorize]
        public async Task<IActionResult> GetItensAsync([FromServices] AppDbContext context)
        {
            var todos = await context.Todos.AsNoTracking().ToListAsync();
            return Ok(todos);
        }

        [HttpGet]
        [Route("GetItemById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetItemByIdAsync([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var todo = await context.Todos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (todo != null)
            {
                return Ok(todo);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("PostAsyncTodos")]
        [Authorize]
        public async Task<IActionResult> PostAsyncTodos([FromServices] AppDbContext context, [FromBody] CreateTodoViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var historico = await context.Todos.AsNoTracking().FirstOrDefaultAsync(x => x.Title == viewModel.Title);

            if (historico != null)
                return BadRequest();

            try
            {
                var todo = new Todo()
                {
                    Date = DateTime.Now,
                    Title = viewModel.Title,
                    Done = false
                };

                await context.Todos.AddAsync(todo);
                await context.SaveChangesAsync();

                return Created($"v1/todos/{todo.Id}", todo);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("todos/{id}")]
        [Authorize]
        public async Task<IActionResult> PutAsyncTodos( [FromServices] AppDbContext context, [FromBody] CreateTodoViewModel viewModel, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var todo = await context.Todos.FirstOrDefaultAsync(x => x.Id == id);

                if (todo == null)
                    return NotFound();

                todo.Title = viewModel.Title;
                context.Todos.Update(todo);
                await context.SaveChangesAsync();

                return Ok(todo);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpDelete]
        [Route("deleteTodo/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAsyncTodos([FromServices] AppDbContext context, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var todo = await context.Todos.FirstOrDefaultAsync(x => x.Id == id);

                if (todo == null)
                    return NotFound();


                context.Todos.Remove(todo);
                await context.SaveChangesAsync();

                return Ok(todo);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
