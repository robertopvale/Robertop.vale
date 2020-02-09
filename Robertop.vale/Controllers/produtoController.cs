using Robertop.vale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Robertop.vale.Controllers
{
    [RoutePrefix("api/produto")]
    public class produtoController : ApiController
    {


        [Route("{sku}")]
        public List<Produto> Get(string sku)
        {
            List<Produto> ret = ListaProdutos.produtos.Where(x => x.sku.Equals(int.Parse("0" + sku))).ToList();

            return ret;
        }

        [Route("")]
        public result Post(Produto prod)
        {

            List<Produto> ret = ListaProdutos.produtos.Where(x => x.sku.Equals(prod.sku)).ToList();

            /* conforme solicitado validação de duplicidade:
             Caso um produto já existente em memória tente ser criado com o mesmo sku uma exceção deverá ser lançada
             Dois produtos são considerados iguais se os seus skus forem iguais 
             */

            if (ret.Count > 0)
            {
                return new result
                {
                    msg = "Dois produtos são considerados iguais se os seus skus forem iguais"
                };
            }
            else
            {
                ListaProdutos.produtos.Add(prod);
                return new result
                {
                    msg = "Produto inserio com exito"
                };
            }

        }

        [Route("{sku}")]
        public result Delete(string sku)
        {

            List<Produto> ret = ListaProdutos.produtos.Where(x => x.sku.Equals(int.Parse("0" + sku))).ToList();

            if (ret.Count == 0)
            {
                return new result
                {
                    msg = "Produto não encontrado no cadastro."
                };
            }
            else
            {
                ListaProdutos.produtos.RemoveAt(
                            ListaProdutos.produtos.IndexOf(
                                    ListaProdutos.produtos.First(
                                                    x => x.sku.Equals(int.Parse("0" + sku))
                                                                )
                                                        )
                                                );
                return new result
                {
                    msg = "Produto excluido com exito"
                };
            }

        }

        [HttpPut]
        [Route("{sku}")]
        public result Put(int sku,Produto prod)
        {

            List<Produto> ret = ListaProdutos.produtos.Where(x => x.sku.Equals(prod.sku)).ToList();

            /* conforme solicitado Metodo de alteração
                Ao atualizar um produto, o antigo deve ser sobrescrito com o que esta sendo enviado na requisição
                A requisição deve receber o sku e atualizar com o produto que tbm esta vindo na requisição             
             */

            if (ret.Count > 0)
            {


               for (int i = 0; i < ListaProdutos.produtos.Count; i++) { 

                    if (ListaProdutos.produtos[i].sku == prod.sku)
                    {
                        ListaProdutos.produtos[i].name = prod.name;
                        for (int k = 0; k < ListaProdutos.produtos[i].inventory.Lwarehouses.Count; k++)
                        {
                            ListaProdutos.produtos[i].inventory.Lwarehouses[k].locality = prod.inventory.Lwarehouses[k].locality;
                            ListaProdutos.produtos[i].inventory.Lwarehouses[k].quantity = prod.inventory.Lwarehouses[k].quantity;
                            ListaProdutos.produtos[i].inventory.Lwarehouses[k].type = prod.inventory.Lwarehouses[k].type;
                        }
                     }
                }

                return new result
                {
                    msg = "Produto Alterado com exito"
                };

            }
            else
            {
                return new result
                {
                    msg = "Não existe este produto cadastrado na base"
                };
            }

        }

    }
}
