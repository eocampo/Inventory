using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public class Product
    {
        private Guid _productId = Guid.Empty;

        private string name = null;

        private Product() {
            this._productId = Guid.NewGuid();
        }

        public Guid ProductId {
            get { return this._productId; }
        }

        public string Name {
            get { return this.name; }
        }
    }
}
