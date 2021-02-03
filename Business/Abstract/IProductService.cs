using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    //product ın iş kodu.iş katmanında kullanılacak operasyonlar
    //business data access ve entities i kullanır.
    public interface IProductService
    {
        List<Product> GetAll();
    }
}
