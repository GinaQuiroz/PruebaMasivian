using ApiRestArbolBinario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRestArbolBinario
{
    public class BinaryTreeService
    {
       /*
       * Author: Gina Quiroz
       * Date: 14 dic 2018
       * Description: Api rest binary tree
       */

        public BinaryTree binaryTree;
        public BinaryTreeService()
        {
            binaryTree = new BinaryTree();
        }

        /// <summary>
        /// Creates a binary tree from a given data
        /// </summary>
        /// <param name="binaryTree">current binary tree</param>
        /// <param name="value">value to insert into the binary tree</param>
        /// <returns>binaryTree</returns>
        public BinaryTree Insert(BinaryTree binaryTree, int value)
        {
            if (binaryTree == null || binaryTree.value == null)
            {
                binaryTree = new BinaryTree();
                binaryTree.value = value;
            }
            else if (value < binaryTree.value)
            {
                binaryTree.left = Insert(binaryTree.left, value);
            }
            else if (value > binaryTree.value)
            {
                binaryTree.right = Insert(binaryTree.right, value);
            }

            return binaryTree;
        }
        

        /// <summary>
        /// Given a tree and two nodes, find the closest common ancestor.
        /// </summary>
        /// <param name="ancestorNode">tree for search the common ancestor between node1 and nodo2</param>
        /// <param name="node1">firts node to compare</param>
        /// <param name="node2">Second node to compare</param>
        /// <returns>ancestorNode</returns>
        /// 
        
        public BinaryTree FindCommonAncestorNode(BinaryTree ancestorNode, int node1, int node2)
        {
            bool findNodo1 = false;
            bool findNodo2 = false;

            BinaryTree ancesterNode = FindCommonNode(ancestorNode, node1, node2,  ref findNodo1,ref findNodo2);

            if (findNodo1 && findNodo2) { return ancesterNode; }

            return null;
        }

        /// <summary>
        /// Given a tree and two nodes, find the closest common ancestor.
        /// </summary>
        /// <param name="currentNode">tree for search the common ancestor between node1 and nodo2</param>
        /// <param name="node1">firts node to compare</param>
        /// <param name="node2">Second node to compare</param>
        /// <param name="findNodo1">Flag control 1 </param>
        /// <param name="findNodo2">Flag control 2 </param>
        /// <returns>currentNode</returns>
        /// 
        public BinaryTree FindCommonNode(BinaryTree currentNode, int node1, int node2, ref bool findNodo1, ref bool findNodo2)
        {
            BinaryTree leftTree;
            BinaryTree rightTree;

            if (currentNode == null) { return null; }

            leftTree = FindCommonNode(currentNode.left, node1, node2, ref findNodo1, ref findNodo2);
            rightTree = FindCommonNode(currentNode.right, node1, node2, ref findNodo1, ref findNodo2);

            if (leftTree != null &&
               rightTree != null)
            {
                return currentNode;
            }

            if (currentNode.value == node1)
            {
                findNodo1 = true;
                return currentNode;
            }

            if (currentNode.value == node2)
            {
                findNodo2 = true;
                return currentNode;
            }

            return leftTree ?? rightTree;

        }


    }
}