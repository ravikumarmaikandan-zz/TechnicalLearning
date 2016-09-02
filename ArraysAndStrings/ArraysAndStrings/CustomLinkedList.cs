using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings
{
    class CustomLinkedList
    {
        protected Node Header { get; set; }

        public CustomLinkedList()
        {
            Header = new Node("Header");
        }
        //We need to find the element in the linked list 
        private Node Find(object toFindData)
        {
            Node current = new Node();
            current = Header;
            while (current.Data != toFindData)
            {
                current = current.Link;
            }
            return current;
        }

        public void Insert(object newNodeData, object afterData)
        {
            Node newNode =  new Node(newNodeData);
            Node current = Find(afterData);
            if (current.Link != null)
            {
                newNode.Link = current.Link;
                current.Link = newNode;
            }
            else
            {
                //This will be a scenario where the afterdata matches with the TAIL node and that will not have any link
                //Just add a link to the new node and the new node will act as a TAIL node.
                current.Link = newNode;
            }
        }

        private Node FindPrevious(object toFind)
        {
            Node current = new Node();
            current = Header;
            while (current.Link != null && current.Link.Data != toFind)
            {
                current = current.Link;
            }
            return current;
        }

        public void Remove(object toRemove)
        {
            Node previous = FindPrevious(toRemove);
            if (previous.Link != null)
            {
                previous.Link = previous.Link.Link;
            }
        }

        public void PrintList()
        {
            Node current = new Node();
            current = Header;
            while (current.Link != null)
            {
                Console.WriteLine(current.Data.ToString());
                current = current.Link;
            }

            //we have encountered the last node, so we need to print the last node 
            Console.WriteLine(current.Data.ToString());
        }
    }
    /// <summary>
    /// Core class for the linked list creation 
    /// </summary>
    public class Node
    {
        //In the node class we need two data members, one should be the link and other should be a data 
        public Node Link { get; set; }
        public object Data { get; set; }

        public Node()
        {
            Link = null;
            Data = null;
        }
        /// <summary>
        /// This constructor is used to create a node with the data
        /// </summary>
        /// <param name="data"></param>
        public Node(object data)
        {
            Data = data;
            Link = null;
        }
    }
}
