using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class Product:IEntity//diğer katmanlarda erişebilsin diye public ekledik

    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }//short int in bi küçüğü
        public decimal UnitPrice { get; set; }

    }
}
