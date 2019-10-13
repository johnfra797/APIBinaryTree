using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace APIBinaryTree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BinaryTreeController : ControllerBase
    {
        private static BT.BinaryTree bt = new BT.BinaryTree();

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("crear")]
        public ActionResult<string> Crear(int id)
        {
            return Ok(bt.CrearBinaryTree());
        }

        [HttpGet("LowestCommonAncestor")]
        public ActionResult<string> LowestCommonAncestor(int key1, int key2)
        {
            return Ok(bt.BuscarPadre(key1, key2));
        }

        [HttpGet("Ancestor")]
        public ActionResult<string> Ancestor(int key)
        {
            return Ok(bt.BuscarPadre(key));
        }
    }
}
