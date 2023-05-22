﻿using OzelAkademi.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Business.Abstract
{
    public interface IStudentService
    {
        Task CreateAsync(Student student);
        Task<Student> GetByIdAsync(int id);
        Task<List<Student>> GetAllAsync();
        void Update(Student student);
        void Delete(Student student);
        //Task<Student> GetAll
        
    }
}
