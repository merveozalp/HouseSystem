using AutoMapper;
using BuildingSystem.Business.Abstract;
using BuildingSystem.Business.UnitOfWork;
using BuildingSystem.DataAccess.Abstract;
using BuildingSystem.Entities.Dtos;
using Entites.Entitiy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Business.Concrete
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExpenseService(IExpenseRepository expenseRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _expenseRepository = expenseRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ExpenseCreateDto> AddAsync(ExpenseCreateDto dto)
        {
            var entityDto = _mapper.Map<Expense>(dto);
            await _expenseRepository.AddAsync(entityDto);
            await _unitOfWork.CommitAsync();
            return dto;
        }

        public async Task DeleteAsync(ExpenseDto dto)
        {
            var entityDto = _mapper.Map<Expense>(dto);
            _expenseRepository.Delete(entityDto);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<ExpenseDto>> GetAllAsync()
        {
            var expenseList = await _expenseRepository.GetAll().ToListAsync();
            var expenseDto = _mapper.Map<IEnumerable<ExpenseDto>>(expenseList);
            return expenseDto;
        }

        public async Task<ExpenseDto> GetById(int Id)
        {
            var blocks = await _expenseRepository.GetById(Id);
            var blockDto =_mapper.Map<ExpenseDto>(blocks);
            return blockDto;
        }

        public async Task UpdateAsync(UpdateExpenseDto dto)
        {
            var entityDto = _mapper.Map<Expense>(dto);
            _expenseRepository.Update(entityDto);
            await _unitOfWork.CommitAsync();
        }
    }
}
