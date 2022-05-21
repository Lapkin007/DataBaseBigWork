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
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Odbc;
using MySql.Data.MySqlClient;

namespace _2019014867_linjun_databasebigwork
{
    /// <summary>
    /// xiugai.xaml 的交互逻辑
    /// </summary>
    public partial class xiugai : Window
    {
        public xiugai()
        {
            InitializeComponent();
            string acc = MainWindow.zh;
            load_gameli();
            DataHistoryForm();
        }
        private void DataHistoryForm()
        {
            String connStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=linjun_2019014867_bigwork;";
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connStr);
                //打开数据库
                conn.Open();
                string sql = "select game as '游戏',comment as'评论',score as '评分' from comment where account='{0}' ";

                sql = string.Format(sql, MainWindow.zh);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //创建SqlDataAdapter类的对象
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                //创建DataSet类的对象
                DataTable ds = new DataTable();
                //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                sda.Fill(ds);
                //设置表格控件的DataSource属性
                DG_history.ItemsSource = ds.DefaultView;
                DG_history.IsReadOnly = true;

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
        private void load_gameli()
        {
            //在COMBOBOX里显示
            ArrayList list1 = new ArrayList();
            ArrayList list2 = new ArrayList();
            string str = "select distinct game from comment where account='"+MainWindow.zh+"' ";
            string str2 = "select comment from comment where account='" + MainWindow.zh + "'and game='"+CB_gamelist.SelectedItem+"' ";
            String connetStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=linjun_2019014867_bigwork;";
            MySqlConnection conn = new MySqlConnection(connetStr);
            conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            MySqlDataAdapter db = new MySqlDataAdapter(str2, conn);
            DataSet df = new DataSet();
            da.Fill(ds);
            db.Fill(df);
            DataTable dt = ds.Tables[0];
            DataTable dh = df.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                //dr[0]表示取结果的第一列，dr[1]就是第二列
                list1.Add(dr[0].ToString().Trim());
            }
            foreach (DataRow dk in dh.Rows)
            {
                //dr[0]表示取结果的第一列，dr[1]就是第二列
                list2.Add(dk[0].ToString().Trim());
            }
            CB_gamelist.ItemsSource = list1;
            CB_comment.ItemsSource = list2;
            conn.Close();
        }

        private void CB_gamelist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            load_gameli();
            TB_gai.Text= "";
            TB_score .Text= "";
        }

        private void CB_comment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //编写数据库连接串
            string connStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=linjun_2019014867_bigwork;";
            //创建 SqlConnection的实例
            MySqlConnection conn = null;
            //定义SqlDataReader类的对象
            MySqlDataReader dr = null;
            try
            {
                conn = new MySqlConnection(connStr);
                //打开数据库连接
                conn.Open();
                string sql = "select comment,score from comment where game='" + CB_gamelist.SelectedItem + "' and comment='"+CB_comment.SelectedItem+"'";
                //填充SQL语句
                //创建SqlCommand对象
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //执行Sql语句
                dr = cmd.ExecuteReader();
                //判断SQL语句是否执行成功
                if (dr.Read())
                {
                    //将msg的值显示在标签上
                    TB_gai.Text = Convert.ToString(dr[0]);
                    TB_score.Text = Convert.ToString(dr[1]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询失败！" + ex.Message);
            }
            finally
            {
                if (dr != null)
                {
                    //判断dr不为空，关闭SqlDataReader对象
                    dr.Close();
                }
                if (conn != null)
                {
                    //关闭数据库连接
                    conn.Close();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=linjun_2019014867_bigwork;";
            //创建 SqlConnection的实例
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                //编写数据库连接串
                conn.Open();
                string sql = "delete from comment where game='" + CB_gamelist.SelectedItem + "' and comment='" + CB_comment.SelectedItem + "'";
                //创建SqlCommand对象
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //执行SQL语句
                int returnvalue = Convert.ToInt32(cmd.ExecuteNonQuery());
                //判断SQL语句是否执行成功
                if (returnvalue != -1)
                {
                    MessageBox.Show("删除成功！");
                    DataHistoryForm();
                    load_gameli();
                    TB_score.Text = "";
                    TB_gai.Text = "";
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string connStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=linjun_2019014867_bigwork;";
            //创建 SqlConnection的实例
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                //编写数据库连接串
                conn.Open();
                string sql = "UPDATE comment SET comment ='"+TB_gai.Text+"' where game='" + CB_gamelist.SelectedItem + "' and comment='" + CB_comment.SelectedItem + "'";
                string sql2 = "UPDATE comment SET score ='" + Convert.ToInt32(TB_score.Text) + "' where game='" + CB_gamelist.SelectedItem + "' and comment='" + CB_comment.SelectedItem + "'";
                //创建SqlCommand对象
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                //执行SQL语句
                int returnvalue2 = Convert.ToInt32(cmd2.ExecuteNonQuery());
                int returnvalue = Convert.ToInt32(cmd.ExecuteNonQuery());
                //判断SQL语句是否执行成功
                if (returnvalue != -1 && returnvalue2 != -1)
                {
                    MessageBox.Show("修改成功！");
                    DataHistoryForm();
                    load_gameli();
                    TB_score.Text = "";
                    TB_gai.Text = "";
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
    }
}