using DAO.Common;
using System;
using System.Data;
using System.Collections.Generic;
using Entities.Shop;
using System.Data.SqlClient;
using Entities.Product;

namespace DAO.Shop
{
    /// <summary>
    /// Defines the <see cref="ProductDao" />.
    /// </summary>
    /// 

    public class ShopDao
    {
        /// <summary>
        /// Defines Database Connection..
        /// </summary>
        private DbConnection connection = new DbConnection();

        /// <summary>
        /// Defines strSql..
        /// </summary>
        private string strSql = String.Empty;

        /// <summary>
        /// Defines the resultDataTable.
        /// </summary>
        private DataTable resultDataTable = new DataTable();

        /// <summary>
        /// Defines the existCount.
        /// </summary>
        private int existCount;

        #region==========Product========== 

        /// <summary>
        /// Get All
        /// </summary>
        public DataTable GetAll()
        {
            strSql = "SELECT * FROM Employees ";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable Get(int id)
        {
            strSql = "SELECT * FROM Employees " +
                      "WHERE  EmployeeId= " + id;

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// Create Employee
        /// </summary>
        /// <param name="shopEntity">.</param>
        public bool Insert(ShopEntity shopEntity)
        {
            strSql = "INSERT INTO ShopTable(ShopName,PhoneNumber,Address,IsDeleted,CreatedUserId,CeletedUserId)" +
                     "VALUES(@ShopName, @PhoneNumber, @Address, @IsDeleted, @CreatedUserId, @CeletedUserId)";

            SqlParameter[] sqlParam = {
                                       new SqlParameter("@ShopName", shopEntity.shopName),
                                       new SqlParameter("@PhoneNumber", shopEntity.phoneNumber),
                                       new SqlParameter("@Address", shopEntity.address),
                                       new SqlParameter("@CreatedUserId", shopEntity.createdUserId),
                                        new SqlParameter("@ProductImage", shopEntity.address),
                                        new SqlParameter("@CreatedUserId", shopEntity.createdUserId)
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);

            return success;
        }

        /// <summary>
        /// Create Employee
        /// </summary>
        /// <param name="employeeEntity">.</param>
        public bool Update(ShopEntity shopEntity)
        {
            strSql = "UPDATE ShopTable SET ShopName=@ShopName, PhoneNumber=@PhoneNumber, Address=@Address, UpdatedUserId=@UpdatedUserId, UpdatedDateTime=@UpdatedDateTime WHERE ShopId = @ShopId";

            SqlParameter[] sqlParam = {
                                        new SqlParameter("@ShopName", shopEntity.shopName),
                                        new SqlParameter("@PhoneNumber", shopEntity.phoneNumber),
                                        new SqlParameter("@address", shopEntity.address),
                                        new SqlParameter("@Price", shopEntity.isDeleted),
                                        new SqlParameter("@UpdatedUserId", shopEntity.updateddUserId),
                                        new SqlParameter("@UpdatedDateTime", shopEntity.updatedDateTime),
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);

            return success;
        }

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name="id">.</param>
        public bool Delete(int id)
        {
            strSql = "DELETE FROM Employees  WHERE EmployeeId =@EmployeeId";
            SqlParameter[] sqlParam = {
                                        new SqlParameter("@EmployeeId", id)
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);
            return success;
        }
        #endregion
    }
}
