using Practicom.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicom.Core.Repositories
{
    public  interface IPositionRepository
    {
        Task<IEnumerable<Position>> GetPositions();//get()
      
        Task<Position> GetById(int id);
       
        Task<Position> AddPosition(Position position);//post()
        
        Task<Position> UpdatePosition( Position position);
       
        Task RemovePosition(int id);
     
    }
}
