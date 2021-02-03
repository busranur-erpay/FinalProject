using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    //Iproductservs in somut hali
    public class ProductManager : IProductService
    {
        IProductDal _productDal; //hem  ınmemory hem de entity i kapsar

        //product manager new lendiğinde constructor çalışacak ve diyor ki bana bir tane Iproductdal referansı ver. şuan inmemory
        //olabilir yarın entity olabilir, erişim alternatifleri değişebilir
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //iş kodları
            //veri erişimini çağırmamız lazım.
            //bir iş sınıfı başka sınıfları new lemez
            return _productDal.GetAll();
        }
    }
}
