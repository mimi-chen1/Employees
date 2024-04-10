using Practicom.Core.Entites;
using Practicom.Core.Repositories;
using Practicom.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicom.Service
{
    public class PositionService: IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }
        public async Task<IEnumerable<Position>> GetPositions()//get
        {
            return await _positionRepository.GetPositions();
        }
        public async Task<Position> GetById(int id)
        {
            return await _positionRepository.GetById(id);
        }
        public async Task<Position> AddPosition(Position position) 
        { 
          return await  _positionRepository.AddPosition(position);
        
        }
        public async Task<Position> UpdatePosition(Position position)
        {
            return await _positionRepository.UpdatePosition( position);
        }
        public async Task RemovePosition(int id)
        {
           await  _positionRepository.RemovePosition(id);
        }

       

        
     
    }
}
