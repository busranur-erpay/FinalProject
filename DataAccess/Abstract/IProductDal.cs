using Entities.Concrete; //referans yapıldıktan sonra eklendi
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //product ın interface i
    //Bu product ile ilgili veritabanında yapacağımız operasyonları içeren interface 
    public interface IProductDal
    {
        //şimdi product ları listeleyeceğiz. getall ile çekiyoruz. ama product farklı farklı bir katmandan gelecek
        List<Product> GetAll(); //add reference to Entities hatası geldi. Bu demek ki biz entities katmanını kullanacağız o yüzden
        //dataaccess içindeki dependencies (bağımlılık) demeli ki ben dataaccess olarak entities e bağlıyım.çünkü ürünler entities katmanında
        //bu katmanı kullanmak istiyoruz. başka bir katmanı kullanmak istiyorsak referans veririz.

        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);

        List<Product> GetAllByCategory(int categoryId);
    }
}
