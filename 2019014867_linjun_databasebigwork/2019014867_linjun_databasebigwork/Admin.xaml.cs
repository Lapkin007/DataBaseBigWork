using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data.Odbc;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Data;

namespace _2019014867_linjun_databasebigwork
{
    /// <summary>
    /// Admin.xaml 的交互逻辑
    /// </summary>
    public partial class Admin : Window
    {
        private DataTable dt = new DataTable("game");
        public Admin()
        {
            InitializeComponent();
            admin_zhmm.Content = ("账号:" + MainWindow.zh);
            load_gameli();
        }
        private void load_gameli()
        {
            //在LISTBOX里显示
            ArrayList list2 = new ArrayList();
            string str = "select * from gamelist ";
            String connetStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=linjun_2019014867_bigwork;";
            MySqlConnection conn = new MySqlConnection(connetStr);
            conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                //dr[0]表示取结果的第一列，dr[1]就是第二列
                list2.Add(dr[0].ToString().Trim());
            }
            LB_gamelist.ItemsSource = list2;
            conn.Close();
        }
        private void admin_return_main_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow1 = new MainWindow();
            App.Current.MainWindow = mainWindow1;
            this.Close();
            mainWindow1.Show();
        }

        private void B_register_Click(object sender, RoutedEventArgs e)
        {
            String connStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=linjun_2019014867_bigwork;";
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connStr);
                //打开数据库连接
                conn.Open();
                //判断用户名是否重复
                string checkNameSql = "select count(*) from admin where admin_account='{0}'";
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
                string sql = "insert into admin(admin_account,admin_password) values('{0}','{1}')";
                //填充SQL语句
                sql = string.Format(sql, TB_account.Text, TB_password.Text);
                //创建SqlCommand对象
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //执行SQL语句
                int returnvalue = Convert.ToInt32(cmd.ExecuteNonQuery());
                //判断SQL语句是否执行成功
                if (returnvalue != -1)
                {
                    MessageBox.Show("注册管理员账号成功！");
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

        private void B_checkcomment_Click(object sender, RoutedEventArgs e)
        {
            comment comment1 = new comment();
            comment1.Show();
        }

        private void B_delete_Click(object sender, RoutedEventArgs e)
        {
            String connStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=linjun_2019014867_bigwork;";
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connStr);
                //打开数据库连接
                conn.Open();
                string checkNameSql = "select count(*) from user where account='{0}'";
                checkNameSql = string.Format(checkNameSql, TB_account1.Text);
                //创建SqlCommand对象
                MySqlCommand cmdCheckName = new MySqlCommand(checkNameSql, conn);
                //执行SQL语句
                int isRepeatName = Convert.ToInt32(cmdCheckName.ExecuteScalar());
                if (isRepeatName == 0)
                {
                    //用户名重复，则不执行注册操作
                    MessageBox.Show("用户名不存在！");
                    return;
                }
                string sql = "delete from user where account='{0}' and password='{1}'";
                //填充SQL语句
                sql = string.Format(sql, TB_account1.Text, TB_password1.Text);
                //创建SqlCommand对象
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //执行SQL语句
                int returnvalue = Convert.ToInt32(cmd.ExecuteNonQuery());
                //判断SQL语句是否执行成功
                if (returnvalue != -1)
                {
                    MessageBox.Show("删除普通用户成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败！" + ex.Message);
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

       

        private void B_add_Click(object sender, RoutedEventArgs e)
        {
            String connStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=linjun_2019014867_bigwork;";
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connStr);
                //打开数据库连接
                conn.Open();
                //判断用户名是否重复
                string checkNameSql = "select count(*) from gamelist where game='{0}'";
                checkNameSql = string.Format(checkNameSql, TB_gamelist.Text);
                //创建SqlCommand对象
                MySqlCommand cmdCheckName = new MySqlCommand(checkNameSql, conn);
                //执行SQL语句
                int isRepeatName = Convert.ToInt32(cmdCheckName.ExecuteScalar());
                if (isRepeatName != 0)
                {
                    //用户名重复，则不执行注册操作
                    MessageBox.Show("游戏已存在！");
                    return;
                }
                string sql = "insert into gamelist(game) values('{0}')";
                //填充SQL语句
                sql = string.Format(sql, TB_gamelist.Text);
                //创建SqlCommand对象
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //执行SQL语句
                int returnvalue = Convert.ToInt32(cmd.ExecuteNonQuery());
                //判断SQL语句是否执行成功
                if (returnvalue != -1)
                {
                    MessageBox.Show("插入成功！");
                    load_gameli();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加失败！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    //关闭数据库连接
                    conn.Close();
                    load_gameli();
                }

            }
        }

        private void LB_gamelist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void B_game_delete_Click(object sender, RoutedEventArgs e)
        {
            String connStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=linjun_2019014867_bigwork;";
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connStr);
                //打开数据库连接
                conn.Open();
                
                string sql = "delete from gamelist where game='{0}'";
                //填充SQL语句
                sql = string.Format(sql, LB_gamelist.SelectedItem);
                //创建SqlCommand对象
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //执行SQL语句
                int returnvalue = Convert.ToInt32(cmd.ExecuteNonQuery());
                //判断SQL语句是否执行成功
                if (returnvalue != -1)
                {
                    MessageBox.Show("删除成功！");
                    load_gameli();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败！" + ex.Message);
                load_gameli();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            checkuser checkuser = new checkuser();
            checkuser.Show();
        }
    }
}

