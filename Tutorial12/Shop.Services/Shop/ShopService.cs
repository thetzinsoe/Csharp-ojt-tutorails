using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO.Shop;
using Entities.Shop;

namespace Services.Employee
{
    /// <summary>
    /// Defines the <see cref="ProductService" />.
    /// </summary>
    public class EmployeeService
    {
        /// <summary>
        /// Define product Dao..
        /// </summary>
        private ShopDao shopDao = new ShopDao();


        #region==========Employee========== 
        /// <summary>
        /// Get All.
        /// </summary>
        public DataTable GetAll()
        {
            DataTable dt = shopDao.GetAll();
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
            DataTable dt = shopDao.Get(id);
            return dt;
        }

        /// <summary>
        /// Save Employee.
        /// </summary>
        /// <param name="ShopEntity">.</param>
        public bool Insert(ShopEntity shopEntity)
        {
            return shopDao.Insert(shopEntity);
        }

        /// <summary>
        /// Update Employee.
        /// </summary>
        /// <param name="employeeEntity">.</param>
        public bool Update(ShopEntity shopEntity)
        {
            return shopDao.Update(shopEntity);
        }

        /// <summary>
        /// Delete Employee.
        /// </summary>
        /// <param name="id">.</param>
        public bool Delete(int id)
        {
            return shopDao.Delete(id);
        }
    }
}
