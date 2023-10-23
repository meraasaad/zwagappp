using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZwagAPP.API.Data;

namespace ZwagAPP.API.Controllers;

[ApiController]
[Route("api/[controller]")]
// http://localhost:5077/api/values
public class ValuesController : ControllerBase
{

        private readonly DataContext _context; //it means that its value cannot be changed after it has been assigned. 
        // الفاريبل ده اللي هخزن فيه الداتا كونتست اللي عامله انجكشن ليها
        public ValuesController(DataContext context)// عملت انجكشن داخل الكونترولر للداتا كونتكست 
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetValues() //the IActionResult interface represents the result of an action method (ok 200) in a controller
        //it makes the HTTP request
        //async علشان بيتاخد وقت فينفذها اسرع  مالتي ثريد
        {
            var values =await _context.Values.ToListAsync();
            //لازم احط اويت علشان اسينك علشان يبعت الميثود لدليجيد
            // ToListAsync بصصصيي

            return Ok(values);
        }

        [HttpGet("{id}")]
          public async Task<IActionResult> GetValue(int id)
          {
             var value =await _context.Values.FirstOrDefaultAsync(x=>x.id==id);
             //FirstOrDefaultAsync بترجع القيمه ولو ملاقيتهاش بترجع نل
             //_context اللي هرجه منه القيمه 
             //Values الجدول 
             //x=>x.id==id عايز يرحع من جدول الفاليوز الايدي بتاعه == اللي باعته كبرامتر
             return Ok(value);
          }

          [HttpPost]

          public void Post([FromBody]string value){} 

          [HttpPut("{id}")]
          public void Put(int id,[FromBody] string value){}


          [HttpDelete]
          public void Delete(int id){} 


}
