﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookMgr
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBoxID.Text!=""&&textBoxpw.Text!="")
            {
                Login();
            }
            else
            {
                MessageBox.Show("输入有空项，请重新输入！");
            }
        }
        //验证是否允许登录
        public void Login()
        {
            if(radioButtonAdmin.Checked==true)
            {
                Dao dao = new Dao();
                string sql = $"select * from t_admin where id='{textBoxID.Text}' and pw='{textBoxpw.Text}'";
                //MessageBox.Show(sql);
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {

                    Data.UID = dc["id"].ToString();
                    Data.UName = dc["name"].ToString();

                    //MessageBox.Show(dc[0].ToString() + dc["name"].ToString());
                    MessageBox.Show("登陆成功！");

                    admin1 admin = new admin1();
                    this.Hide();
                    admin.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("登陆失败！");
                }
                dao.DaoClose();
            }
            else if(radioButtonUser.Checked==true)
            {
                Dao dao = new Dao();
                string sql = $"select * from t_user where id='{textBoxID.Text}' and pw='{textBoxpw.Text}'";
                //MessageBox.Show(sql);
                IDataReader dc = dao.read(sql);
                if(dc.Read())
                {
                    MessageBox.Show("登陆成功！");

                    user1 user = new user1();
                    this.Hide();
                    user.ShowDialog();
                    this.Show();

                }
                else
                {
                    MessageBox.Show("登陆失败！");
                }
                dao.DaoClose();
            }
        }
    }
}