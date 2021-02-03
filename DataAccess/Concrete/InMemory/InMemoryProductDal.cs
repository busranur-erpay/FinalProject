using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    //bellekte çalışacak sekilde IProductdal ı kodlayacağız. bu da bir Iproductdal. 
    //Entityframework kullanırsak yazacağımız kodlar farklıdır bunu kullanırsak yazacağımız kodlar farklıdır.
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        // projeyi başlatınca bellekte bir tane ürün  listesi oluşsun. constructor ile bellekte referans ald. zaman çalışacak blok
        public InMemoryProductDal()
        {
            _products = new List<Product> {
            //yeni ürün ekleyeceğiz
            //1.ürün
            new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15 },
            //2.ürün
             new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3 },
             new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2 },
             new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65 },
             new Product{ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1 },
            };
        }


        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ- language Integrated Query -ile liste bazlı yapıları sql gibi filtreleyebiliyoruz.
            Product productToDelete;

            productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId); //bu fonk tek bir eleman bulmaya yarar._products ı tek tek dolaşır.
            //p tek tek dolaşırken kullanacağı takma isimdir. p nin id si bizim gönderdiğimiz product ın id sine eşitse o elemanı bulur.

            _products.Remove(productToDelete);
            
        }

        public List<Product> GetAll()
        {
            //burda veritabanındaki datayı business a vermemiz lazım.
            //veritabanını olduğu gibi döndürüyor.
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            //where içindeki koşula uyan bütün elemanları yeni bir liste haline getiri ve onu döndürür
           return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //güncellenecek referans bulunur
            //Gönderdiğimiz ürün id sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            //artık bilgileri güncelliyoruz.
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }
    }
}
