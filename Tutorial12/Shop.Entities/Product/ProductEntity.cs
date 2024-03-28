using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Product
{
    public class ProductEntity
    {
        /// <summary>
        /// Gets or sets the employee id.
        /// </summary>
        public int productId { get; set; }


        /// <summary>
        /// Gets or Sets name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Gets or sets the designation.
        /// </summary>
        public string productImage { get; set; }

        /// <summary>
        /// Gets or Sets salary
        /// </summary>
        public decimal price { get; set; }

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
        /// 

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
        public ProductEntity()
        {
            InitializedObjectValue();
        }

        /// <summary>
        /// The InitializedObjectValue.
        /// </summary>
        internal void InitializedObjectValue()
        {
            this.productId = 0;
            this.name = String.Empty;
            this.description = String.Empty;
            this.productImage = String.Empty;
            this.price = 0;
            this.isDeleted = 0;
            this.createdUserId = 0;
            this.updateddUserId = 0;
            this.deletedUserId = 0; 
            this.createdDateTime = DateTime.Now;
            this.updatedDateTime = DateTime.Now;
        }
    }
}

