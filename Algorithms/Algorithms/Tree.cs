using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
  public static class Tree
  {
    public static void BinarySearchTree()
    {
      //Create a binary Tree
      BinarySearchTree<int> btree = new BinarySearchTree<int>();
      //btree.Root = new BinarySearchTreeNode<int>(1);
      //btree.Root = new BinarySearchTreeNode<int>(1,new BinarySearchTreeNode<int>(2),new BinarySearchTreeNode<int>(3));

      //btree.Root = new BinarySearchTreeNode<int>(1);
      //btree.Root.Left = new BinarySearchTreeNode<int>(2);
      //btree.Root.Right = new BinarySearchTreeNode<int>(3);
      //btree.Root.Left.Left = new BinarySearchTreeNode<int>(4);
      //btree.Root.Right.Right = new BinarySearchTreeNode<int>(5);

      //btree.Root.Left.Left.Right = new BinarySearchTreeNode<int>(6);
      //btree.Root.Right.Right.Right = new BinarySearchTreeNode<int>(7);
      //btree.Root.Right.Right.Right.Right = new BinarySearchTreeNode<int>(8);

      btree.Add(1);
      btree.Add(2);
      btree.Add(3);
      btree.Add(4);
      btree.Add(5);
      btree.Add(6);
    }

    public static void SortedArrayToBST()
    {
      int[] input = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
      int start = 0, end = input.Length - 1;
      var mid = (start + end) / 2;
    }
    private static void CreateSubTree(int[] input, mid, left, right)
    {

    }
  }
  public class BinarySearchTreeNode<T> : Node<T>
  {
    public BinarySearchTreeNode(): base()
    {

    }
    public BinarySearchTreeNode(T data): base(data,null)
    {

    }
    public BinarySearchTreeNode(T data, BinarySearchTreeNode<T> Left, BinarySearchTreeNode<T> Right)
    {
      base.Value = data;
      NodeList<T> children = new NodeList<T>(2);
      children[0] = Left;
      children[1] = Right;
      base.Neighbors = children;
    }

    public BinarySearchTreeNode<T> Left
    {
      get
      {
        if(this.Neighbors != null)
        {
          return this.Neighbors[0] as BinarySearchTreeNode<T>;
        }
        else
        {
          return null;
        }
      }
      set
      {
        if (base .Neighbors == null)
          base.Neighbors = new NodeList<T>(2);

        base.Neighbors[0] = value;

      }
    }

    public BinarySearchTreeNode<T> Right
    {
      get
      {
        if (this.Neighbors != null)
        {
          return this.Neighbors[1] as BinarySearchTreeNode<T>;
        }
        else
        { 
          return null;
        }
    }
      set
      {
        if(base.Neighbors == null)
          base.Neighbors = new NodeList<T>(2);

        base.Neighbors[1] = value;
      }
  }
}

  public class BinarySearchTree<T>
  {
    private Comparer<T> comparer = Comparer<T>.Default;
    private BinarySearchTreeNode<T> root;
    public BinarySearchTree()
    {
      root = null;
    }

    public BinarySearchTreeNode<T> Root 
    { 
      get
      {
        return root;
      }
      set
      {
        root = value;
      }
    }

    public bool Contains(T data)
    {
      BinarySearchTreeNode<T> current = root;
      int result;

      while(current != null)
      {
        result = comparer.Compare(current.Value, data);

        if (result == 0)
        {
          return true;
        }
        else if(result > 0)
        {
          current = current.Left;
        }
        else if(result <0)
        {
          current = current.Right;
        }
      }
      return false;
    }

    public virtual void Add(T data)
    {
      //Create a new Node Instance
      BinarySearchTreeNode<T> newNode = new BinarySearchTreeNode<T>(data);
      int result;

      //now insert n into the tree
      //trace down the tree until we hit null

      BinarySearchTreeNode<T> current = root,parent= null;
      while (current != null)
      {
        result = comparer.Compare(current.Value, data);
        if (result == 0)
          return;
        else if(result >0)
        {
          parent = current;
          current = current.Left;
        }
        else if (result <0)
        {
          parent = current;
          current = current.Right;
        }
      }

      if (parent == null)
      {
        root = newNode;
      }
      else
      {
        result = comparer.Compare(parent.Value, data);
        if (result >0)
        {
          //parent.value > data, therefore newNode must be added to the left subtree
          parent.Left = newNode;
        }
        else
        {
          //parent.value < data, therefore newNode must be added to the right subtree 
          parent.Right = newNode;
        }
      }
    }
  }

  public class Node
  {
    public int data;
    public Node Left;
    public Node Right;
  }

}
