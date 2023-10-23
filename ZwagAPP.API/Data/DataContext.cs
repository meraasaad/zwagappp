using Microsoft.EntityFrameworkCore;
using ZwagAPP.API.Models;
using Microsoft.EntityFrameworkCore.Design;
namespace ZwagAPP.API.Data
{
    public class DataContext : DbContext
    {
      
        // The constructor takes an argument options of type DbContextOptions<DataContext>
        //المطلوب وقت مانادي علي الداتا كونتكست يطلب مني الاوبشنز اللي انا بناءا عليها احدد الاعدادات الخاصه بالداتا كونتكست
        public DataContext(DbContextOptions<DataContext> options):base(options){}

        //الجداول (الدي بي ست) بعملها هنا في الداتا كونتكست
        public DbSet<Value> Values { get; set; }




        
    }
}