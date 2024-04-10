using Microsoft.EntityFrameworkCore;
using Practicom.Core.Entites;
using Practicom.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicom.Data.Repositories
{
    public class PositionRepository:IPositionRepository
    {
        private readonly EmployeeContex _employeeContex;
        public PositionRepository(EmployeeContex employeeContex)
        {
            _employeeContex = employeeContex;
        }
        public async Task<IEnumerable<Position>> GetPositions()//get()
        {
            return await _employeeContex.positions.ToListAsync();
        }
        public async Task<Position> GetById(int id)
        {
            return await _employeeContex.positions.Where(p => p.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Position> AddPosition(Position position)//post()
        {
            _employeeContex.positions.Add(position);
            await _employeeContex.SaveChangesAsync();
             return position;

        }
        public async Task<Position> UpdatePosition(Position position)
        {
            var exsitPosition=await GetById(position.Id);
            _employeeContex.Entry(exsitPosition).CurrentValues.SetValues(position);
           await _employeeContex.SaveChangesAsync();
            return position;
        }
        public async Task RemovePosition(int id) 
        {
            var  product= await GetById(id);
            _employeeContex.positions.Remove(product);
           await _employeeContex.SaveChangesAsync();
            
        }

    }
}
