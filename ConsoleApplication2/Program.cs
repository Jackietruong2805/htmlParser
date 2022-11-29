using System;

namespace LearnDSAlgorithms // Note: actual namespace depends on the project name.
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

        public void display()
        {
            Node p = front;
            while (p != null)
            {
                Console.Write(p.element + "-->");
                p = p.next;
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Console.Clear();
            string input = @"<body>
<p>Hello I'm Flash</p> 
<span>My Name is Hào</span>
</body>";
            // kiểm tra thẻ body
            string inputTemp = input;
            string temp = "";
            string temp1 = "";
            string temp2 = "";
            int lastArrow = input.IndexOf(">");
            int firstArrow = input.LastIndexOf("<");
            for(int i=0; i <= lastArrow; i++)
            {
                temp += input[i];
                temp1 += input[i];
                
            }
            for (int i = firstArrow; i < input.Length; i++)
            {
                temp += input[i];
                temp2 += input[i];
            }
           
            string[] htmlList = {"<p></p>", "<span></span>", "<body></body>", "<div></div>" };
            int a = 0;
            while (a < htmlList.Length)
            {
                if (htmlList[a] == temp)
                {
                    Console.WriteLine("Thẻ hợp lệ");
                    inputTemp = inputTemp.Replace(temp1, "");
                    inputTemp = inputTemp.Replace(temp2, "");
                    Console.WriteLine(inputTemp);
                    break;
                }
                if ((htmlList[a] != temp) && (a == htmlList.Length - 1))
                {
                    Console.WriteLine("thẻ không hợp lệ");
                }
                a++;
            }
            //Kiểm tra các thẻ còn lại
            string temp3 = "";
            string temp4 = "";
            string temp5 = "";
            int lastArrow2 = input.IndexOf(">");
            int firstArrow2 = input.LastIndexOf("<");
            for (int i = 0; i <= lastArrow2; i++)
            {
                temp += input[i];
                temp1 += input[i];

            }
            for (int i = firstArrow2; i < input.Length; i++)
            {
                temp += input[i];
                temp2 += input[i];
            }

            Console.ReadKey();

        }
    }
}