using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO.Staff;
using Entities.Staff;

namespace Services.Staff
{
    /// <summary>
    /// Defines the <see cref="ProductService" />.
    /// </summary>
    public class StaffService
    {
        /// <summary>
        /// Define product Dao..
        /// </summary>
        private StaffDao staffDao = new StaffDao();


        #region==========Employee========== 
        /// <summary>
        /// Get All.
        /// </summary>
        public DataTable GetAll()
        {
            DataTable dt = staffDao.GetAll();
            return dt;
        }
        #endregion

        /// <summary>
        /// Get.
        /// </summary>
        /// <param name="id">.</param>
        /// <returns>.</returns>
        public DataTable Get(int id)
        {
            DataTable dt = staffDao.Get(id);
            return dt;
        }

        /// <summary>
        /// Save Employee.
        /// </summary>
        /// <param name="employeeEntity">.</param>
        public bool Insert(StaffEntity employeeEntity)
        {
            return staffDao.Insert(employeeEntity);
        }

        /// <summary>
        /// Update Employee.
        /// </summary>
        /// <param name="employeeEntity">.</param>
        public bool Update(StaffEntity employeeEntity)
        {
            return staffDao.Update(employeeEntity);
        }

        /// <summary>
        /// Delete Employee.
        /// </summary>
        /// <param name="id">.</param>
        public bool Delete(int id)
        {
            return staffDao.Delete(id);
        }
    }
}
