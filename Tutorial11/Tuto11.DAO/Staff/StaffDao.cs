using DAO.Common;
using System;
using System.Data;
using System.Collections.Generic;
using Entities.Staff;
using System.Data.SqlClient;
using System.Data.Common;
using Entities.Staff;
using DbConnection = DAO.Common.DbConnection;

namespace DAO.Staff
{
    /// <summary>
    /// Defines the <see cref="ProductDao" />.
    /// </summary>
    /// 
    public class StaffDao
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
            strSql = "SELECT * FROM Tuto07 ";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable Get(int id)
        {
            strSql = "SELECT * FROM Tuto07 " +
                      "WHERE  Id= " + id;

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// Create Employee
        /// </summary>
        /// <param name="employeeEntity">.</param>
        public bool Insert(StaffEntity staffEntity)
        {
            strSql = strSql = "INSERT INTO Tuto07(Image, Name, JoinFrom, StaffType, NrcNo, Gender, PhoneNo1, PhoneNo2, Address, BirthDate, Password)" +
          " VALUES(@Image, @Name, @JoinFrom, @StaffType, @NrcNo, @Gender, @PhoneNo1, @PhoneNo2, @Address, @BirthDate, @Password)";

            SqlParameter[] sqlParam = {
                                        new SqlParameter("@Image", staffEntity.image),
                                        new SqlParameter("@Name", staffEntity.name),
                                        new SqlParameter("@JoinFrom", staffEntity.joinDate),
                                        new SqlParameter("@StaffType", staffEntity.staffId),
                                        new SqlParameter("@NrcNo", staffEntity.nrcNo),
                                        new SqlParameter("@Gender", staffEntity.gender),
                                        new SqlParameter("@PhoneNo1", staffEntity.phoneNo1),
                                        new SqlParameter("@PhoneNo2", staffEntity.phoneNo2),
                                        new SqlParameter("@Address", staffEntity.address),
                                        new SqlParameter("@BirthDate", staffEntity.birthDate),
                                        new SqlParameter("@Password", staffEntity.password)
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);

            return success;
        }

        /// <summary>
        /// Create Employee
        /// </summary>
        /// <param name="employeeEntity">.</param>
        public bool Update(StaffEntity staffEntity)
        {
            strSql = "UPDATE Tuto07 SET Image=@Image, Name=@Name, JoinFrom=@JoinFrom, StaffType=@StaffType, NrcNo=@NrcNo, Gender=@Gender, PhoneNo1=@PhoneNo1, PhoneNo2=@PhoneNo2, Address=@Address, BirthDate=@BirthDate, Password=@Password WHERE Id = @StaffId";


            SqlParameter[] sqlParam = {
                                        new SqlParameter("@StaffId", staffEntity.staffId),
                                        new SqlParameter("@Image", staffEntity.image),
                                        new SqlParameter("@Name", staffEntity.name),
                                        new SqlParameter("@JoinFrom", staffEntity.joinDate),
                                        new SqlParameter("@StaffType", staffEntity.staffId),
                                        new SqlParameter("@NrcNo", staffEntity.nrcNo),
                                        new SqlParameter("@Gender", staffEntity.gender),
                                        new SqlParameter("@PhoneNo1", staffEntity.phoneNo1),
                                        new SqlParameter("@PhoneNo2", staffEntity.phoneNo2),
                                        new SqlParameter("@Address", staffEntity.address),
                                        new SqlParameter("@BirthDate", staffEntity.birthDate),
                                        new SqlParameter("@Password", staffEntity.password)
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
            strSql = "DELETE FROM Tuto07  WHERE Id =@StaffId";
            SqlParameter[] sqlParam = {
                                        new SqlParameter("@StaffId", id)
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);
            return success;
        }
        #endregion
    }
}