using AutoMapper;
using BuildingSystem.Business.Abstract;
using BuildingSystem.Business.UnitOfWork;
using BuildingSystem.DataAccess.Abstract;
using BuildingSystem.Entities.Dtos;
using BuildingSystem.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Business.Concrete
{
    public class ExpenseTypeService : IExpenseTypeService
    {
        private readonly IExpenseTypeRepository _expenseTypeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public async Task<ExpenseTypeDto> AddAsync(ExpenseTypeDto dto)
        {
            var entityDto = _mapper.Map<ExpenseType>(dto);
            await _expenseTypeRepository.AddAsync(entityDto);
            await _unitOfWork.CommitAsync();
            return dto;
        }

        public async Task DeleteAsync(ExpenseTypeDto dto)
        {
            var entityDto = _mapper.Map<ExpenseType>(dto);
            _expenseTypeRepository.Delete(entityDto);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<ExpenseTypeDto>> GetAllAsync()
        {
            var expenseList = await _expenseTypeRepository.GetAll().ToListAsync();
            var expenseTypeDto = _mapper.Map<IEnumerable<ExpenseTypeDto>>(expenseList);
            return expenseTypeDto;
        }

        public async Task<ExpenseTypeDto> GetById(int Id)
        {
            var expenseType = await _expenseTypeRepository.GetById(Id);
            var expenseTypeDto = _mapper.Map<ExpenseTypeDto>(expenseType);
            return expenseTypeDto;
        }

        public async Task UpdateAsync(ExpenseTypeDto dto)
        {
            var entityDto = _mapper.Map<ExpenseType>(dto);
            _expenseTypeRepository.Update(entityDto);
            await _unitOfWork.CommitAsync();
        }
    }
}
