using System.Threading.Tasks;

namespace Activioo.Infrastructure.Migration
{
  public interface IDataSeeder
  {
    Task SeedData();
  }
}