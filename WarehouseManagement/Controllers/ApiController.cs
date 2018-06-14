using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Data;
using WarehouseManagement.Models;

namespace WarehouseManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/Api")]
    public class ApiController : Controller
    {
        private readonly IApiRequestSend<Product> ApiRequestSend;

        public ApiController(IApiRequestSend<Product> apiRequestSend)
        {
            ApiRequestSend = apiRequestSend;
        }

        public void AddProduct(Product product)
        {
            ApiRequestSend.AddEntity(product);
        }

        public void EditProduct(int id, Product product)
        {
            ApiRequestSend.ModifyEntity(id, product);
        }

        public void DeleteProduct(Product product)
        {
            ApiRequestSend.DeleteEntity(product);
        }

        public void GetAllData() => ApiRequestSend.GetAllData();
    }
}