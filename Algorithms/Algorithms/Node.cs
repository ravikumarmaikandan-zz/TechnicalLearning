using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
  public class Node<T>
  {
    private T Data;
    private NodeList<T> neighbors = null;
    
    public Node()
    {

    }
    public Node(T data)
      : this(data, null)
    {

    }
    public Node(T data, NodeList<T> neighbors)
    {
      this.Data = data;
      this.neighbors = neighbors;
    }

    public T Value
    {
      get
      {
        return Data;
      }
      set
      {
        Data = value;
      }
    }

    public NodeList<T> Neighbors
    {
      get
      {
        return neighbors;
      }
      set
      {
        neighbors = value;
      }
    }
  }

  public class NodeList<T> : Collection<Node<T>>
  {
    public NodeList()
      : base()
    {

    }

    public NodeList(int initialSize)
    {
      for(int i=0; i<initialSize;i++)
        base.Items.Add(default(Node<T>));
    }

    public Node<T> FindByValue(T value)
    {
      foreach (Node<T> node in Items)
      {
        if (node.Value.Equals(value))
          return node;
      }
      return null;
    }
  }
}
