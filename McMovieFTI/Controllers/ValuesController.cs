using McMovieFTI.DataContext;
using McMovieFTI.DataContext.Data;
using Microsoft.AspNetCore.Mvc;


namespace McMovieFTI.Controllers
{
    [Route("categories")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: /categories
        [HttpGet]
        public async Task<ActionResult<Category>> Get()
        {
            var data = new DataContext.DataSql();
            return Ok(data.SelectALL());

        }

        // GET categories/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Category>> Get(int id, Category category)
        {

             var data = new DataContext.DataSql();
             return Ok(data.SelectById(id));

        }

        // POST categories

        [HttpPost]
        public ActionResult Post([FromBody] Category category)
        {
            if (ModelState.IsValid)
            {
                var data = new DataSql();
                data.Insert(category.Name, category.Telephone, category.RG, category.CPF, category.Active);
                return Ok(new { Message = "Atulizado com sucesso"});

            }
            return BadRequest( new { Message = "verifique o modelo " });
            
        }

        // PUT categories/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Category category)
        {

            if (id.Equals(null))
            {
                return BadRequest(new { Message = "Id nulo?"});
            }
            if (ModelState.IsValid)
            {
                var data = new DataContext.DataSql();
                data.Edit(id, category.Name, category.Telephone, category.RG, category.CPF, category.Active);
                return Ok();

            }
            return BadRequest(new { Message = "verifique o modelo"});
        }

        // DELETE categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var data = new DataContext.DataSql();
            data.Delete(id);

            return Ok();
        }

    }
    } 
