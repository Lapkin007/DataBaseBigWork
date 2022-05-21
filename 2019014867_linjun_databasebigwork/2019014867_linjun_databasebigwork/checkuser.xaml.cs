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
    /// checkuser.xaml 的交互逻辑
    /// </summary>
    public partial class checkuser : Window
    {
        public checkuser()
        {
            InitializeComponent();
            DataGameListForm();
        }
        private void DataGameListForm()
        {
            String connStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=linjun_2019014867_bigwork;";
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connStr);
                //打开数据库
                conn.Open();
                string sql = "select account as '普通用户账号',password as '密码' from user ";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //创建SqlDataAdapter类的对象
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                //创建DataSet类的对象
                DataTable ds = new DataTable();
                //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                sda.Fill(ds);
                //设置表格控件的DataSource属性
                DG_check.ItemsSource = ds.DefaultView;
                DG_check.IsReadOnly = true;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("出现错误！" + ex.Message);
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
            DataGameListForm();
        }
    }
}
