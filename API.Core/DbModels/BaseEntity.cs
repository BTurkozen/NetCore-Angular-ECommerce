using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.DbModels
{
   public class BaseEntity
    {

        //Oluşturacagım bütün entity classlarda bu class'ı türeterek her class içerisinde ıd tanımlama işlemini kaldırarak
        //ortak bir noktadan kullanım saglıyoruz.
        public int Id { get; set; }
    }
}
