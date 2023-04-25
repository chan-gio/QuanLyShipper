﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace QuanLyShipper
{
    public partial class frm_DangNhapKH : Form
    {
        public frm_DangNhapKH()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-DFSF0MK1\SQLEXPRESS;Initial Catalog=QuanLyShipper;Integrated Security=True");
            SqlCommand command = new SqlCommand("SELECT * FROM KhachHang WHERE TaiKhoanKH=@TaiKhoanKH AND MatKhauKH=@MatKhauKH", connection);
            connection.Open();
            command.Parameters.AddWithValue("@TaiKhoanKH", TaiKhoan_txt.Text);
            command.Parameters.AddWithValue("@MatKhauKH", MatKhau_txt.Text);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                //Đóng form đăng nhập
                this.Hide();
                this.Close();

                //Mở form chính
                frm_KhachHang mainForm = new frm_KhachHang();
                mainForm.Show();
                reader.Close();
                connection.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");
            }
        }
    }
}
