using ComplantSystem.Models;
using ComplantSystem.Models.Data.Base;

using System.Threading.Tasks;


namespace ComplantSystem
{
    public interface ISolveCompalintService 
    {

        Task UpdateMovieAsync(CompalintSolutionVM data);
    }
}
