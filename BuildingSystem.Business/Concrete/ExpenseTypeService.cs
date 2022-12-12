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

        public ExpenseTypeService(IExpenseTypeRepository expenseTypeRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _expenseTypeRepository = expenseTypeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ExpenseTypeDto> AddAsync(ExpenseTypeDto expenseTypeDto)
        {
            var entityDto = _mapper.Map<ExpenseType>(expenseTypeDto);
            await _expenseTypeRepository.AddAsync(entityDto);
            await _unitOfWork.CommitAsync();
            return expenseTypeDto;
        }

        public async Task DeleteAsync(int id)
        {
            var expenses = await _expenseTypeRepository.GetById(id);
            _expenseTypeRepository.Delete(expenses);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<ExpenseTypeDto>> GetAllAsync()
        {
            var expenseList = await _expenseTypeRepository.GetAll().ToListAsync();
            var expenseTypeDto = _mapper.Map<IEnumerable<ExpenseTypeDto>>(expenseList);
            return expenseTypeDto;
        }

        public async Task<ExpenseTypeDto> GetById(int id)
        {
            var expenseType = await _expenseTypeRepository.GetById(id);
            var expenseTypeDto = _mapper.Map<ExpenseTypeDto>(expenseType);
            return expenseTypeDto;
        }

        public async Task UpdateAsync(ExpenseTypeDto expenseTypeDto)
        {
            var entityDto = _mapper.Map<ExpenseType>(expenseTypeDto);
            _expenseTypeRepository.Update(entityDto);
            await _unitOfWork.CommitAsync();
        }
    }
}
