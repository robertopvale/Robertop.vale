using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Robertop.vale.Models
{
    public class Produto
    {
        public string object_ { get { return "Produto"; }}
        public int sku { get; set; }
        public string name { get; set; }
        public cinventory inventory { get; set; }

        /* conforme solicitado calculo feito em tempo de execução
        Toda vez que um produto for recuperado por sku deverá ser calculado a propriedade: isMarketable
        Um produto é marketable sempre que seu inventory.quantity for maior que 0
        */
        public Boolean isMarketable
        {
            get
            {
                if (inventory.quantity > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
        }

    }
}