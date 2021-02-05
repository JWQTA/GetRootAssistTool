using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetRootAssistTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.SelectedItem = toolStripComboBox1.Items[0];
            if (textBox1.Text == "")                   //如果文本框没有文本
            {
                t2has = false;                           //文本框有文本置为假
                textBox1.Text = "请输入【systemifo】信息";               //显示提示信息
                textBox1.ForeColor = Color.LightGray;                //字体颜色设为浅灰色

            }
            else
                t2has = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }
        private bool t2has = false;             //记录文本框是否有文本
        private void textBox1_Leave(object sender, EventArgs e)           //鼠标离开触发事件
        {
            if (textBox1.Text == "")                   //如果文本框没有文本
            {
                t2has = false;                           //文本框有文本置为假
                textBox1.Text = "请输入【systemifo】信息";               //显示提示信息
                textBox1.ForeColor = Color.LightGray;                //字体颜色设为浅灰色

            }
            else {
                textBox1.Text = "";                               //清空文本
                textBox1.ForeColor = Color.Black;              //文本颜色设为黑色
            }
                                       //否则为文本框有文本


        }

        private void textBox1_Enter(object sender, EventArgs e)   //鼠标进入触发事件
        {
            if (t2has == false)                                  //如果没有文本
            {
                textBox1.Text = "";                               //清空文本
                textBox1.ForeColor = Color.Black;              //文本颜色设为黑色
            }
            else {
                t2has = false;                           //文本框有文本置为假
                textBox1.Text = "请输入【systemifo】信息";               //显示提示信息
                textBox1.ForeColor = Color.LightGray;                //字体颜色设为浅灰色
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strText = textBox1.Text;
            if (string.IsNullOrEmpty(strText))
            {
                MessageBox.Show("先填写【systeminfo】信息");
                return;
            }
            List<string> listTemp = new List<string>();
           
            foreach (string str in strText.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList()) {
                //listTemp.Add(str.Split(' ').Where(s => !string.IsNullOrEmpty(s)).ToArray().ToList());
                foreach (string strTemp in str.Split(' ').Where(s => !string.IsNullOrEmpty(s)).ToArray().ToList()) {
                    listTemp.Add(strTemp);
                }
                //listTemp.Add strText.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToString()
            }
            bool flag = false;
            string jsonfile = "./av.json";
            JObject jobTemp = new JObject();
            List<string> listResult = new List<string>();
            using (System.IO.StreamReader file = System.IO.File.OpenText(jsonfile))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    jobTemp = (JObject)JToken.ReadFrom(reader);
                    //string[] str = new string[textBox1.Lines.Length];
 
                    for (int i = 0; i < listTemp.Count; i++)
                    {
                        //jobTemp[textBox1.Lines[i]];
                        string strResult = string.Format("{0}", jobTemp[listTemp[i]]);
                        if (!string.IsNullOrEmpty(strResult)) {
                            flag = true;
                            listResult.Add(strResult);
                        }

                    }
                    if (flag)
                    {
                        label2.Text = string.Join(";", listResult);
                    }
                    else {
                        label2.Text = "未查询到AV信息";
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }

}
