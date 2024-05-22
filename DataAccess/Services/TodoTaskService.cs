using DataAccess.Data;
using DataAccess.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Services
{
    public class TodoTaskService : ITodoTaskService
    {
        private ApplicationDbContext _db;
        public TodoTaskService(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Save a new task to db 
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public async Task<int> Add(TaskRecord task)
        {
            try
            {
                await _db.TaskRecord.AddAsync(task);
                return await _db.SaveChangesAsync();
            }
            catch (Exception ex) {
                return -1;
            }
            
        }

        /// <summary>
        /// Retrieve all task records from db
        /// </summary>
        /// <returns></returns>
        public async Task<List<TaskRecord>> GetAllTaskRecords()
        {
            var records = new List<TaskRecord>();
            try
            {
                return await _db.TaskRecord.OrderByDescending(t=>t.CreatedAt).ToListAsync();
            }
            catch (Exception ex) { }
            return records;
        }

        /// <summary>
        /// Retrieve a task from db by taskId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TaskRecord> GetTaskById(int id)
        {
            try
            {
                return await _db.TaskRecord.Where(t => t.Id == id).SingleOrDefaultAsync();
            }catch(Exception ex) { }
            return new TaskRecord();
        } 

        /// <summary>
        /// Delete a task record from db 
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public async Task<int> Delete(int taskId)
        {
            TaskRecord? task =await _db.TaskRecord.Where(t => t.Id == taskId).FirstOrDefaultAsync();
            if (task!=null)
            {
                try
                {
                    _db.TaskRecord.Remove(task);
                    return await _db.SaveChangesAsync();
                }
                catch (Exception ex) {
                }
            }
            return -1;

        }
        public async Task<bool> ChangeStatus(int taskId)
        {
            var task= await _db.TaskRecord.Where(t => t.Id == taskId).FirstOrDefaultAsync();
            if(task!=null)
            {
                try
                {
                    task.Status = (task.Status==Status.Pending)? Status.Completed : Status.Pending;
                    task.CompletedAt = DateTime.Now;
                    return  await _db.SaveChangesAsync()>0;
                    
                }catch(Exception ex) { }
            }
            return false;
        }

        /// <summary>
        /// Edit a task 
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public async Task Edit(TaskRecord taskId)
        {
            var task= await _db.TaskRecord.Where(t=>t.Id== taskId.Id).FirstOrDefaultAsync();
            if (task!=null )
            {
                task.Description = taskId.Description;
                task.Title = taskId.Title;
                task.ModifiedAt = DateTime.Now;
                await _db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Implementation to search tasks by some criteria like Title, Description or CreatedAt date 
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public async Task<List<TaskRecord>> Search(SearchCriteria criteria)
        {
            var query = _db.TaskRecord.AsQueryable();
            if (criteria != null)
            {
                if (!string.IsNullOrEmpty(criteria.Title))
                    query.Where(t => t.Title.Contains(criteria.Title, StringComparison.OrdinalIgnoreCase));
                if (!string.IsNullOrEmpty(criteria.Description))
                    query.Where(t => t.Description.Contains(criteria.Description, StringComparison.OrdinalIgnoreCase));
                if (criteria.CreatedAtFrom != null)
                {
                    query.Where(t => t.CreatedAt <= t.CreatedAt);
                }
                if (criteria.CreatedAtFrom != null)
                {
                    query.Where(t => t.CreatedAt >= t.CreatedAt);
                }
                if (criteria.CompletedAtFrom != null)
                {
                    query.Where(t => t.CompletedAt <= t.CompletedAt);
                }
                if (criteria.CompletedAtTo != null)
                {
                    query.Where(t => t.CompletedAt >= t.CompletedAt);
                }

            }
            return await query.ToListAsync();

        }
    }
}
