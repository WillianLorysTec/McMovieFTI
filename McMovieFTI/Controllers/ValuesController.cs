using McMovieFTI.DataContext;
using McMovieFTI.DataContext.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace McMovieFTI.Controllers
{
    [EnableCors("AnotherPolicy")]
    [Route("categories")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: /categories

        [HttpGet]
        public async Task<ActionResult<Categorys>> Get()
        {
            var data = new DataContext.DataSql();
            return Ok(data.SelectALL());

        }

        // GET categories/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Categorys>> Get(int id)
        {

            var data = new DataContext.DataSql();
            return Ok(data.SelectById(id));

        }

        // POST categories/post
        [EnableCors("AnotherPolicy")]
        [Route("post")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Categorys category)
        {
            if (ModelState.IsValid)
            {
                var data = new DataSql();
                data.Insert(category.Title, category.Imdb, category.Price, category.Category);
                return Ok(new { Message = "Atulizado com sucesso" });

            }
            return BadRequest(new { Message = "verifique o modelo " });

        }




        // PUT categories/put/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("put")]
        public async Task<ActionResult> Put([FromBody] Categorys category)
        {

            if (ModelState.IsValid)
            {
                var data = new DataContext.DataSql();
                data.Edit(category.Id, category.Title, category.Imdb, category.Price, category.Category);


                return Ok(new { message = "Atualizado com sucesso " });

            }
            return BadRequest(new { Message = "verifique o modelo" });
        }


        //DELETE categories/5
        
        [HttpDelete("del/{id}")]
     
        public async Task<ActionResult> Delete(int id)
        {
            var data = new DataContext.DataSql();
            data.Delete(id);

            return Ok();
        }

    } 
}