using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Odbc;
using MySql.Data.MySqlClient;

namespace _2019014867_linjun_databasebigwork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
            B_register.IsEnabled = false;
        }
        //定义属性
        bool lianjie;
        public static string zh;//账号
        public static string mm;//密码
        public void Button_Connect(object sender, RoutedEventArgs e)
        {
            //连接数据库
            String connetStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=linjun_2019014867_bigwork;";
            MySqlConnection conn = new MySqlConnection(connetStr);
            try
            {
                conn.Open();//打开通道，建立连接
                MessageBox.Show("云数据库连接成功", "Success");
                //****
                //测试用例
                /*string sql = string.Format("SELECT * FROM `user` WHERE Admin= 'False'");
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    label1.Content = read[0].ToString();
                } */
                //****
                lianjie = true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("连接数据库失败", "erro");  //有异常，打印错误信息到控制台
            }
            finally
            {
                conn.Close();
            }

        }

        public void B_login_Click(object sender, RoutedEventArgs e)
        {
            if (lianjie == true)
            {
                if (RB_Admin.IsChecked == true)
                {
                    String connetStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=linjun_2019014867_bigwork;";
                    MySqlConnection conn = new MySqlConnection(connetStr);
                    conn.Open();
                    string sql = "Select count(*) from admin where admin_account='{0}' and admin_password='{1}'";
                    //填充SQL语句
                    sql = string.Format(sql, TB_account.Text, TB_password.Password);
                    //创建SqlCommand对象
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    //执行SQL语句
                    int returnvalue = Convert.ToInt32(cmd.ExecuteScalar());
                    //判断SQL语句是否执行成功
                    if (returnvalue != 0)
                    {
                        conn.Close();
                        MessageBox.Show("登录成功！");
                        zh = TB_account.Text; mm = TB_password.Password;
                        Admin admin1 = new Admin();
                        App.Current.MainWindow = admin1;
                        this.Close();
                        admin1.Show();
                    }
                    else if (RB_Admin.IsChecked == false&&RB_User.IsChecked==false)
                    {
                        MessageBox.Show("登录失败！");
                    }
                    else { MessageBox.Show("登录失败！"); };

                }
                else if (RB_Admin.IsChecked == false && RB_User.IsChecked == false)
                {
                    MessageBox.Show("请选择账号类型！");
                }
                else 
                {
                    String connetStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=linjun_2019014867_bigwork;";
                    MySqlConnection conn = new MySqlConnection(connetStr);
                    conn.Open();
                    string sql = "Select count(*) from user where account='{0}' and password='{1}'"; 
                    //填充SQL语句
                    sql = string.Format(sql, TB_account.Text, TB_password.Password);
                    //创建SqlCommand对象
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    //执行SQL语句
                    int returnvalue = Convert.ToInt32(cmd.ExecuteScalar());
                    //判断SQL语句是否执行成功
                    if (returnvalue != 0)
                    {
                        conn.Close();
                        MessageBox.Show("登录成功！");
                        zh = TB_account.Text; mm = TB_password.Password;
                        User user1 = new User();
                        App.Current.MainWindow = user1;
                        this.Close();
                        user1.Show();
                    }
                    else
                    {
                        MessageBox.Show("登录失败！");
                    }
                }
            }
            else { MessageBox.Show("请先测试数据库连接","error"); }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            B_register.IsEnabled =true;
        }

        private void B_clear_Click(object sender, RoutedEventArgs e)
        {
            TB_account.Text = null; TB_password.Password = null;
        }

        private void B_Register(object sender, RoutedEventArgs e)
        {
            String connStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=linjun_2019014867_bigwork;";
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connStr);
                //打开数据库连接
                conn.Open();
                //判断用户名是否重复
                string checkNameSql = "select count(*) from user where account='{0}'";
                checkNameSql = string.Format(checkNameSql, TB_account.Text);
                //创建SqlCommand对象
                MySqlCommand cmdCheckName = new MySqlCommand(checkNameSql, conn);
                //执行SQL语句
                int isRepeatName = Convert.ToInt32(cmdCheckName.ExecuteScalar());
                if (isRepeatName != 0)
                {
                    //用户名重复，则不执行注册操作
                    MessageBox.Show("用户名已存在！");
                    return;
                }
                string sql = "insert into user(account,password) values('{0}','{1}')";
                //填充SQL语句
                sql = string.Format(sql, TB_account.Text, TB_password.Password);
                //创建SqlCommand对象
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //执行SQL语句
                int returnvalue = Convert.ToInt32(cmd.ExecuteNonQuery());
                //判断SQL语句是否执行成功
                if (returnvalue != -1)
                {
                    MessageBox.Show("注册成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("注册失败！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    //关闭数据库连接
                    conn.Close();
                }
            }
        }

        private void RB_Admin_Checked(object sender, RoutedEventArgs e)
        {
            B_register.IsEnabled = false;
        }
    }
        

      
    }
