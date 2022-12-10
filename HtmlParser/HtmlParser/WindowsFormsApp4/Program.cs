using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Xml.Linq;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System.Xml;
using System.IO;


namespace WindowsFormsApp4
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
            string[] listHtml = { "div", "a", "span", "li", "b", "ul", "h1", "h2", "h3", "h4", "h5", "h6", "p", "section", "template", "button", "i", "strong", "main", "header", "time", "textarea", "table", "tbody", "th", "td", "tfoot" };

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
                    tag += nNode.Name + " ";
                }
            }

            string[] spearator = { " " };
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
        public string[] display()
        {
            Node p = front;
            int count = 0;
            while (p != null)
            {
                count++;
                p = p.next;
            }
            string[] plainText = new string[count];
            int index = 0;
            p = front;
            while (p != null)
            {
                plainText[index++] = p.element;
                p = p.next;
            }

            return plainText;

        }


        internal static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
}
