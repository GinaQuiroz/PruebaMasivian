using ApiRestArbolBinario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiRestArbolBinario.Controllers
{

    public class BinaryTreeController : ApiController
    {
        /*
        * Author: Gina Quiroz
        * Date: 14 dic 2018
        * Description: Api rest binary tree
        */

        static BinaryTreeService _BinaryTreeRepository;

        public BinaryTreeController()
        {
            if (_BinaryTreeRepository == null)
                _BinaryTreeRepository = new BinaryTreeService();
        }
        

        [Route("~/api/binaryTree")]          
        [HttpPost]
        // POST /api/binaryTree
        /// <summary>
        /// Call the service layer to add values to the tree from listValues
        /// </summary>
        /// <param name="listValues">list of list to create the binary tree</param>
        /// <returns>OK()</returns>
        public IHttpActionResult AddValuesBTree([FromBody]ApiRequest listValues)
        {
            foreach (List<int> list in listValues.array)
            {
                foreach (int value in list)
                {
                    _BinaryTreeRepository.binaryTree = _BinaryTreeRepository.Insert(_BinaryTreeRepository.binaryTree, value);
                }
            }
            
            return Ok();
        }

        [Route("~/api/binaryTree")]
        [HttpGet]
        // Get /api/binaryTree 
        /// <summary>
        /// Call the service layer to tree for search the common ancestor between node1 and nodo2
        /// </summary>
        /// <param name="node1">firts node to compare</param>
        /// <param name="node2">Second node to compare</param>
        /// <returns>ancestor.value</returns>
        public IHttpActionResult FindAncestor( [FromUri] int node1, [FromUri]  int node2)
        {
            BinaryTree ancestor = _BinaryTreeRepository.FindCommonAncestorNode(_BinaryTreeRepository.binaryTree, node1, node2); 

            if (ancestor != null)           
                return Ok(ancestor.value);            
            else            
                return NotFound();            
                             
        }

        

    }
}
