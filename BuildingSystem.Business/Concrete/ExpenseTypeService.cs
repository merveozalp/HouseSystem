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

        public void Delete(int id)
        {
            var expenses =  _expenseTypeRepository.GetById(id).Result;
            _expenseTypeRepository.Delete(expenses);
            _unitOfWork.Commit();
        }

        public async Task<List<ExpenseTypeDto>> GetAllAsync()
        {
            var expenseList = await _expenseTypeRepository.GetAll().ToListAsync();
            var expenseTypeDto = _mapper.Map<List<ExpenseTypeDto>>(expenseList);
            return expenseTypeDto;
        }

        public async Task<ExpenseTypeDto> GetById(int id)
        {
            var expenseType = await _expenseTypeRepository.GetById(id);
            var expenseTypeDto = _mapper.Map<ExpenseTypeDto>(expenseType);
            return expenseTypeDto;
        }

        public void Update(ExpenseTypeDto expenseTypeDto)
        {
            var entityDto = _mapper.Map<ExpenseType>(expenseTypeDto);
            _expenseTypeRepository.Update(entityDto);
            _unitOfWork.Commit();
        }
    }
}
