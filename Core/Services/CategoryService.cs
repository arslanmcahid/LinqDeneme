using Core.Models;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CategoryService
    {
        private readonly IRepository<Category> _repo;
        public CategoryService(IRepository<Category> repo)
        {
            _repo = repo;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return _repo.GetAll();
        }

        public Category GetCategoryById(int id)
        {
            return _repo.GetById(id);
        }

        public void AddCategory(Category category)
        {
            _repo.Add(category);
        }

        public void UpdateCategory(Category category)
        {
            _repo.Update(category);
        }

        public void DeleteCategory(Category category)
        {
            _repo.Delete(category);
        }
    }
}
