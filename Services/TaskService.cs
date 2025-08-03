using System.Collections.Generic;
using TaskManagementApi.Data;
using TaskManagementApi.Models;

namespace TaskManagementApi.Services
{
    public class TaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public List<TaskModel> GetAll() => _context.Tasks.ToList();

        public TaskModel GetById(int id) => _context.Tasks.FirstOrDefault(t => t.Id == id);

        public void Add(TaskModel task)
        {
            _context.Tasks.Add(task); // Just add task without setting Id
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }
    }
}
