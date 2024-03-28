using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Shop
{
    public class ShopEntity
    {
        /// <summary>
        /// Gets or sets the employee id.
        /// </summary>
        public int shopId { get; set; }


        /// <summary>
        /// Gets or Sets name
        /// </summary>
        public string shopName { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string phoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the designation.
        /// </summary>
        public string address { get; set; }

        /// <summary>
        /// Gets or sets the joining date
        /// </summary>
        public int isDeleted { get; set; }

        /// <summary>
        /// Gets or sets the joining date
        /// </summary>
        public int createdUserId { get; set; }

        /// <summary>
        /// Gets or sets the joining date
        /// </summary>
        public int updateddUserId { get; set; }

        /// <summary>
        /// Gets or sets the joining date
        /// </summary>
        public int deletedUserId { get; set; }

        /// <summary>
        /// Gets or sets the joining date
        /// </summary>
        public DateTime createdDateTime { get; set; }

        /// <summary>
        /// Gets or sets the joining date
        /// </summary>
        public DateTime updatedDateTime { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeEntity"/> class.
        /// </summary>
        public ShopEntity()
        {
            InitializedObjectValue();
        }

        /// <summary>
        /// The InitializedObjectValue.
        /// </summary>
        internal void InitializedObjectValue()
        {
            this.shopId = 0;
            this.shopName = String.Empty;
            this.phoneNumber = String.Empty;
            this.address = String.Empty;
            this.isDeleted = 0;
            this.createdUserId = 0;
            this.updateddUserId = 0;
            this.deletedUserId = 0;
            this.createdDateTime = DateTime.Now;
            this.updatedDateTime = DateTime.Now;
        }
    }
}

