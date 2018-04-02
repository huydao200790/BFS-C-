using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree_t
{
    public class Node
    {
        public char value;
        public Node left;
        public Node right;

        public Node(char initial)
        {
            value = initial;
            left = null;
            right = null;
        }
    }

    /*
        public class BinaryTree_t
        {
            public Node root;
            public BinaryTree_t()
            {
                root = null;
            }
            public BinaryTree_t(char initial)
            {
                root = new Node(initial);
            }

            public void add(char data)
            {

                if(root == null)
                {
                Node newNode = new Node(data);
                newNode.value = data;
                root = newNode;
                    return;
                }
                Node currentNode = root;
                bool added = false;
                do
                {

                }
                while(!added)

            }
        }*/

    
    class Program
    {
        static void Main(string[] args)
        {
            //set goal as character
            //char goal = 'M';
            Console.WriteLine("Enter a capital letter: ");
            char goal = Convert.ToChar(Console.ReadLine());

            Node nodeA = new Node('A');
            Node nodeB = new Node('B');
            Node nodeC = new Node('C');
            Node nodeD = new Node('D');
            Node nodeE = new Node('E');
            Node nodeF = new Node('F');
            Node nodeG = new Node('G');

            nodeA.left = nodeB;
            nodeA.right = nodeC;
            nodeB.left = nodeD; 
            nodeB.right = nodeE;
            nodeC.left = nodeF;
            nodeC.right = nodeG;

            Queue<Node> open = new Queue<Node>();
            Stack<Node> close = new Stack<Node>();
            open.Enqueue(nodeA);
            while(open.Count > 0)
            {
                //display open and close
                Console.Write("open:[");
                foreach (var i in open.ToArray())
                {
                    Console.Write(i.value + ", ");
                }
                Console.Write("] close: [");
                foreach (var i in close.ToArray())
                {
                    Console.Write(i.value + ", ");
                }
                Console.Write("]");
                Console.WriteLine();

                if (open.Peek().value == goal)
                {
                    Console.WriteLine("Found " + goal);
                    Console.Read();
                    return;
                   
                }
                else
                {
                    Node currentNode = open.Peek();
                    if (currentNode.left == null && currentNode.right != null)
                    {
                        open.Enqueue(currentNode.right);
                        close.Push(currentNode);
                        open.Dequeue();
                    }
                    else if (currentNode.left != null && currentNode.right == null)
                    {
                        open.Enqueue(currentNode.left);
                        close.Push(currentNode);
                        open.Dequeue();
                    }
                    else if (currentNode.left != null && currentNode.right != null)
                    {
                        open.Enqueue(currentNode.left);
                        open.Enqueue(currentNode.right);
                        close.Push(currentNode);
                        open.Dequeue();
                    }
                    else if (currentNode.left == null && currentNode.right == null)
                    {
                        close.Push(currentNode);
                        open.Dequeue();
                    }
                    
                   

                }
            }

            Console.WriteLine("Can not Find " + goal);
            Console.Read();
        }
    }
}
