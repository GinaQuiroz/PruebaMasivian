using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRestArbolBinario.Models
{
    public class BinaryTree
    {
        /*
       * Author: Gina Quiroz
       * Date: 14 dic 2018
       * Description: Api rest binary tree
       */

        //// Summary:Value of the node.
        public int? value   { get; set; }

        /// Summary:Node left of the tree.
        public BinaryTree left   { get; set; }

        /// Summary:Node right of the tree.
        public BinaryTree right { get; set; }
        
    }
}