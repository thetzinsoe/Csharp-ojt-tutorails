using DAO.Common;
using System;
using System.Data;
using Entities.Product;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAO.Product
{
    /// <summary>
    /// Defines the <see cref="ProductDao" />.
    /// </summary>
    /// 

    public class PrductDao
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
        /// <param name="">.</param>
        public bool Insert(ProductEntity productEntity)
        {
            strSql = "INSERT INTO Employees(Name,Description,ProductImage,Price,IsDeleted,CreatedUserId,UpdateUserId)" +
                     "VALUES(@Name, @Description, @ProductImage, @Price, @CreatedUserId, @UpdateUserId )";

            SqlParameter[] sqlParam = {
                                        new SqlParameter("@Name", productEntity.name),
                                        new SqlParameter("@Description", productEntity.description),
                                        new SqlParameter("@ProductImage", productEntity.productImage),
                                        new SqlParameter("@Price", productEntity.price),
                                        new SqlParameter("@CreatedUserId", productEntity.createdUserId)
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);

            return success;
        }

        /// <summary>
        /// Create Employee
        /// </summary>
        /// <param name="employeeEntity">.</param>
        public bool Update(ProductEntity productEntity)
        {
            strSql = "UPDATE ProductTable SET Name=@Name ,Description=@Description ,ProductImage=@ProductImage ,Price=@Price ,IsDeleted=@IsDeleted ,CreatedUserId=@CreatedUserId ,UpdateUserId=@UpdateUserId WHERE Id = @ProductId";

            SqlParameter[] sqlParam =  {
                                        new SqlParameter("@Name", productEntity.name),
                                        new SqlParameter("@Description", productEntity.description),
                                        new SqlParameter("@ProductImage", productEntity.productImage),
                                        new SqlParameter("@Price", productEntity.price),
                                        new SqlParameter("@UpdatedUserId", productEntity.updateddUserId),
                                        new SqlParameter("@UpdatedDateTime", productEntity.updateddUserId),
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
            strSql = "UPDATE ProductTable SET Name=@Name ,Description=@Description  ProductId =@PorductId";
            SqlParameter[] sqlParam = {
                                        new SqlParameter("@EmployeeId", id)
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);
            return success;
        }
        #endregion
    }
}
