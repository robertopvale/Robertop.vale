using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Robertop.vale.Models
{
    public class cinventory
    {
        /*
         * Conforme solicitado calculo feito em tempo de execução
          Toda vez que um produto for recuperado por sku deverá ser calculado a propriedade: inventory.quantity
           A propriedade inventory.quantity é a soma da quantity dos warehouses
        */
        public int quantity
        {
            get
            {
                int contador = 0;

                foreach (warehouses linha in Lwarehouses)
                {
                    contador = contador + linha.quantity;

                }


                return contador;
            }
        }


        public List<warehouses> Lwarehouses { get; set; }

    }
}