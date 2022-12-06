﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;


namespace WindowsFormsApp4
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void label3_Click(object sender, EventArgs e)
        {

        }

       
        public void button1_Click(object sender, EventArgs e)
        {
            string html = txtHtmlRaw.Text;
            HtmlDocument htmldoc = new HtmlDocument();
            htmldoc.LoadHtml(html);
            QueuesLinked q = new QueuesLinked();
            var body = htmldoc.DocumentNode.SelectSingleNode("//body");
            HtmlNodeCollection childnodes = body.ChildNodes;
            if (q.checkHtmlTag(html))
            {
                if (htmldoc.ParseErrors.Count() > 0)
                {
                    lblPlainText.Text = "Lỗi";
                }
                else
                {
                    foreach (var node in childnodes)
                    {
                        if (node.NodeType == HtmlNodeType.Element)
                        {
                            q.enqueue(node.InnerText);
                        }
                    }
                }
                string[] textList = q.display();
                foreach (string text in textList)
                {
                    lblPlainText.Text += text + @"
";
                }
            }
            else
            {
                lblPlainText.Text = "Lỗi";
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtHtmlRaw.Text = "";
            lblPlainText.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
