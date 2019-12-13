using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SportsMarket.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }

        [Required(ErrorMessage =" please enter your name")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [Range (0.1, double.MaxValue, ErrorMessage = "Please enter a positive value") ]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "please specify a value")]
        public string Category { get; set; }

        public byte[] ImageData { get; set; }

        public string ImageMimeType { get; set; }

    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem (Product product, int quantity)
        {
            CartLine line = lineCollection
                .Where(a => a.Product.ProductID == product.ProductID)
                .FirstOrDefault();
            if(line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
                {line.Quantity += quantity;}
        }

        public void RemoveItem(Product product)
        {
            lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }

    }
}
