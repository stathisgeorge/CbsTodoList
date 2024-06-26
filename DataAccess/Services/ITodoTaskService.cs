﻿using DataAccess.Data.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public interface ITodoTaskService
    {
        Task<int> Add(TaskRecord task);
        Task<List<TaskRecord>> GetAllTaskRecords(string username);
        Task<TaskRecord> GetTaskById(int id);

        Task<int> Delete(int taskId);
        Task<bool> ChangeStatus(int taskId);
        Task Edit(TaskRecord taskId);
        Task<List<TaskRecord>> Search(SearchCriteria criteria);
    }
}
