namespace Entities.Staff
{
    using System;
    using System.Data;

    /// <summary>
    /// Defines the <see cref="StaffEntity" />.
    /// </summary>
    public class StaffEntity
    {
        /// <summary>
        /// Gets or sets the employee id.
        /// </summary>
        public int staffId { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// 
        public string image { get; set; }


        /// <summary>
        /// Gets or Sets name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// 
        public DateTime joinDate { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// 
        public string staffType { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// 
        public string nrcNo { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// 
        public string gender { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// 
        public string phoneNo1 { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// 
        public string phoneNo2 { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// 
        public string address { get; set; }


        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// 
        public DateTime birthDate { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// 
        public string password { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeEntity"/> class.
        /// </summary>
        public StaffEntity()
        {
            InitializedObjectValue();
        }

        /// <summary>
        /// The InitializedObjectValue.
        /// </summary>
        internal void InitializedObjectValue()
        {
            this.staffId = 0;
            this.image = string.Empty;
            this.name = String.Empty;
            this.joinDate = DateTime.Now;
            this.staffType = string.Empty;
            this.nrcNo = string.Empty;
            this.gender = string.Empty;
            this.phoneNo1 = string.Empty;
            this.phoneNo2 = string.Empty;
            this.address = String.Empty;
            this.birthDate = DateTime.Now;
            this.password = string.Empty;
        }
    }
}
