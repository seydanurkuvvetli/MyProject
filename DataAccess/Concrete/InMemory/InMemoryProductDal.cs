using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;//değişken oluşturdum
        public InMemoryProductDal()//Constructor (Yapıcı Metod)
        {//burda sql,postgres,MongoDb gibi veritabanlaından geldiğini düşün
            _products = new List<Product> {
            new Product{ProductId=1,CategoryId=1,ProductName="BARDAK",UnitPrice=40,UnitsInStock=15},
            new Product{ProductId=2,CategoryId=1,ProductName="KAMERA",UnitPrice=1400,UnitsInStock=20 },
            new Product{ProductId=3,CategoryId=2,ProductName="MOUSE",UnitPrice=100,UnitsInStock=60 },
            new Product{ProductId=4,CategoryId=2,ProductName="KLAVYE",UnitPrice=600,UnitsInStock=70 },
            new Product{ProductId=5,CategoryId=2 ,ProductName="TELEFON",UnitPrice=3500,UnitsInStock=20 },

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ-Language Integrated Query
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
           
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            //gönderdiğim ürün id'sine sahip olan listedeki  ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }
        public List<Product> GetAllByCategory(int cateoryId)
        {
            return _products.Where(p => p.CategoryId == cateoryId).ToList();
            //Where koşulu içindeki şarta uyan bütün elemanları yeni bir liste haline getirir onu döndürür.


        }
    }
}
