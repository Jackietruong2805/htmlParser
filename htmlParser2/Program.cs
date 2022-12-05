using System;
using System.Xml;
using System.IO;
using HtmlAgilityPack;


namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Node
    {
        public string element;
        public Node next;
        public Node(string e, Node n)
        {
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
            if (isEmpty())
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

        public Boolean checkHtmlTag(string html)
        {
            string[] listHtml = { "div", "a", "span", "li", "b", "ul", "h1", "h2", "h3", "h4", "h5", "h6", "p", "section", "template", "b", "i", "strong" };

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var node = htmlDoc.DocumentNode.SelectSingleNode("//body");

            StringWriter sw = new StringWriter();

            XmlTextWriter xw = new XmlTextWriter(sw);
            string tag = "";

            foreach (var nNode in node.Descendants())
            {
                if (nNode.NodeType == HtmlNodeType.Element)
                {
                    //Console.WriteLine(nNode.Name);
                    tag += nNode.Name + " ";
                }

            }

            string[] spearator = { " " };
            // using the method
            string[] strlist = tag.Split(spearator,
                   StringSplitOptions.RemoveEmptyEntries);

            int count = 0;

            for (int i = 0; i < strlist.Length; i++)
            {
                for (int j = i + 1; j < strlist.Length; j++)
                {
                    if (strlist[i] == strlist[j])
                    {
                        strlist[j] = "";
                    }

                }
            }
            for (int i = 0; i < strlist.Length; i++)
            {
                if (strlist[i] == "")
                {
                    count++;
                }
            }

            string[] newTag = new string[strlist.Length - count];
            int index = 0;
            for (int i = 0; i < strlist.Length; i++)
            {
                if (strlist[i] != "")
                {
                    newTag[index++] = strlist[i];
                }
            }

            Boolean isTagValid = true;
            for (int i = 0; i < newTag.Length; i++)
            {
                for (int j = 0; j < listHtml.Length; j++)
                {
                    if (newTag[i] == listHtml[j])
                    {
                        break;
                    }
                    else if (newTag[i] != listHtml[j] && j == listHtml.Length - 1)
                    {
                        isTagValid = false;
                        break;
                    }
                }
            }
            return isTagValid;

        }

        public void display()
        {
            Node p = front;
            while (p != null)
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
                Console.OutputEncoding = System.Text.Encoding.UTF8;

                string html = @"<html>

            <body>

            <p>Hello</p>

            <span>This is a label</span>

            <div>adad</div>

            <a>CỘNG ĐỒNG</a>
            <a>KENH DOANH NGHIỆP</a>
            <a>LIVE ROOM</a>
            <a>TrungQuoc</a>

            

            <div>hahaha<div>

            </body>

            </html>";
                HtmlDocument htmldoc = new HtmlDocument();
                htmldoc.LoadHtml(html);
                QueuesLinked q = new QueuesLinked();
                var body = htmldoc.DocumentNode.SelectSingleNode("//body");
                HtmlNodeCollection childNodes = body.ChildNodes;
                if (q.checkHtmlTag(html))
                {
                    if (htmldoc.ParseErrors.Count() > 0)
                    {
                        Console.WriteLine("Lỗi");
                    }
                    else
                    {
                        foreach (var node in childNodes)
                        {
                            if (node.NodeType == HtmlNodeType.Element)
                            {
                                Console.WriteLine(node.InnerText);
                            }
                        }
                    }
                }else{
                    Console.WriteLine("Lỗi");
                }

                q.display();
                Console.ReadKey();
            }
        }
    }
}