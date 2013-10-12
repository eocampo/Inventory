using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Inventory.Data;
using System.Data;

namespace Inventory
{
    public class Product
    {
        private Guid _productId = Guid.Empty;

        private string _name = null;

        private Product() {
            this._productId = Guid.NewGuid();
        }

        public Guid ProductId {
            get { return this._productId; }
        }

        public string Name {
            get { return this._name; }
        }





        public static IEnumerable<Product> GetProducts() {
            List<Product> products = new List<Product>();
            ProductDAC dac = new ProductDAC();

            using (IDataReader reader = dac.Select()) {
                while(reader.Read()) {
                    Product product = new Product();
                    product._productId = reader.GetGuid(reader.GetOrdinal("product_id"));
                    product._name = reader.GetString(reader.GetOrdinal("display_name"));
                    // product._productId = reader.GetGuid(reader.GetOrdinal("product_id"));

                    products.Add(product);
                }
            }

            return products;
        }

        public static Product CreateProduct(string name) {
            Product product = new Product();
            product._name = name.Trim();
            ProductDAC dac = new ProductDAC();
            if (dac.Insert(product.ProductId, product.Name)) {
                return product;
            }
            else
                return null;

        }
    }
}
