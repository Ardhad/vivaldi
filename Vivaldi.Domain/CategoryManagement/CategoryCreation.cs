using System;
using Vivaldi.Api.DataAccess;
using Vivaldi.Api.Domain.CategoryManagement;
using Vivaldi.Api.Model;

namespace Vivaldi.Domain.CategoryManagement
{
    public class CategoryCreation : ICategoryCreation
    {
        private readonly ICategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryCreation(ICategoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Category Create(string name)
        {
            return new Category
            {
                CategoryName = name,
                IsVisible = true
            };
        }

        public void AssingParent(Category target, Category parent)
        {
            if (parent == null) throw new ArgumentNullException(nameof(parent));
            if (target == null) throw new ArgumentNullException(nameof(target));

            target.Parent = parent;
        }

        public void Save(Category newCategory)
        {
            _repository.Insert(newCategory);
            _unitOfWork.Commit();
        }
    }
}