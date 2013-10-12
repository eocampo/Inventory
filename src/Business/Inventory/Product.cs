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

        private string _code = null;
        private string _name = null;
        private string _description = null;

        private Product() {
            this._productId = Guid.NewGuid();
        }

        private Product(string code, string name, string description) {
            this._productId = Guid.NewGuid();
            this._code = code.Trim();
            this._name = name.Trim();
            this._description = description.Trim();
        }

        public Guid ProductId {
            get { return this._productId; }
        }

        public string Code {
            get { return this._code; }
        }

        public string Name {
            get { return this._name; }
        }

        public string Description {
            get { return this._description; }
        }

        private void Read(IDataReader reader) {
            this._productId = reader.GetGuid(reader.GetOrdinal("product_id"));
            this._name = reader.GetString(reader.GetOrdinal("display_name"));
            this._code = reader.GetString(reader.GetOrdinal("code"));
            this._description = reader.GetString(reader.GetOrdinal("description"));            
        }

        public static IEnumerable<Product> GetProducts() {
            List<Product> products = new List<Product>();
            ProductDAC dac = new ProductDAC();

            using (IDataReader reader = dac.Select()) {
                while(reader.Read()) {
                    Product product = new Product();
                    product.Read(reader);
                    products.Add(product);
                }
            }

            return products;
        }

        public static Product CreateProduct(string code, string name, string description) {
            Product product = new Product();
            product._code = code.Trim();
            product._name = name.Trim();
            product._description = description.Trim();
            ProductDAC dac = new ProductDAC();
            if (dac.Insert(product.ProductId, product.Code, product.Name, product.Description)) {
                return product;
            }
            else
                return null;

        }

        public static Product GetProduct(string code) {

            List<Product> products = new List<Product>();
            ProductDAC dac = new ProductDAC();
            Product product = null;
            using (IDataReader reader = dac.Select()) {
                while (reader.Read()) {
                    product = new Product();
                    product._productId = reader.GetGuid(reader.GetOrdinal("product_id"));
                    product._name = reader.GetString(reader.GetOrdinal("display_name"));
                    product._code = reader.GetString(reader.GetOrdinal("code"));
                    product._description = reader.GetString(reader.GetOrdinal("description"));                    
                }
            }
            return product;
        }
    }
}
