using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.AbstractFactory
{
    /*    
        Soyut Fabrika (Abstract Factory) (GoF) 
        Bazı durumlarda birbirleriyle ilişkili birden fazla nesne yaratmak gerekir. 
        Örneğin ; Belli koşullarda ProductA1 sınıfından nesne ile ProductB1 sınıfından nesne birlikte kullanılacaktır. 
        Benzer şekilde de ProductA2 sınıfından nesne ile ProductB2 sınıfından nesne birlikte kullanılacaktır. 
        Bu durumda birbirleriyle ilişkili nesneleri (aile) yaratan farklı fabrika sınıfları oluşturulur. 
        Bu fabrika sınıfları ortak bir soyut fabrikadan türetilir.
    */
    public interface AbstractFactroy
    {
        ProductA1 createProductA();
        ProductB1 createProductB();
    }


}
