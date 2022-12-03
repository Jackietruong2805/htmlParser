using System;
using HtmlAgilityPack;


namespace MyApp // Note: actual namespace depends on the project name.
{
public class Node
    {
        public string element;
        public Node next;
        public Node(string e, Node n) {
            element = e;
            next = n;
        }
    }
    class QueuesLinked
    {
        Node front;
        Node rear;
        int size;

        public QueuesLinked()
        {
            front = null;
            rear = null;
            size = 0;
        }

        public int length()
        {
            return size;
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public void enqueue(string e)
        {
            Node newest = new Node(e, null);
            if(isEmpty())
                front = newest;
            else
                rear.next = newest;
            rear = newest;
            size = size + 1;
        }

        public string dequeue()
        {
            if (isEmpty())
            {
                Console.WriteLine("Queue is Empty");
                return "-1";
            }
            string e = front.element;
            front = front.next;
            size = size - 1;
            if (isEmpty())
                rear = null;
            return e;
        }

        public void display()
        {
            Node p = front;
            while(p != null)
            {
                Console.WriteLine("--> " + p.element);
                p = p.next;
            }
            Console.WriteLine();
        }
    class HTMLLParser
    {
        static void Main(string[] args)
        {
            Console.Clear();
          string html = @"<html>

            <body>

            <p>Hello</p>

            <span>This is a label</span>

            <hihi>hahaha</hihi>

            </body>

            </html>";
        HtmlDocument htmldoc = new HtmlDocument();
        htmldoc.LoadHtml(html);

        QueuesLinked q = new QueuesLinked();
        var body = htmldoc.DocumentNode.SelectSingleNode("//body");
        HtmlNodeCollection childNodes = body.ChildNodes;
        if (htmldoc.ParseErrors.Count() > 0)
        {
            Console.WriteLine("Lỗi");
        }else{
            foreach (var node in childNodes)
            {
                if (node.NodeType == HtmlNodeType.Element)
                {
                    q.enqueue(node.InnerText);
                }
            }
        }
        q.display();
        Console.ReadKey();
        }
    }
}
}