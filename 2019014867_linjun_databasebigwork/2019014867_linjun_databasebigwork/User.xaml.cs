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
    /// User.xaml 的交互逻辑
    /// </summary>
    public partial class User : Window
    {
        public User()
        {
            InitializeComponent();
            User_zhmm.Content = ("账号:"+MainWindow.zh);
            load_gameli();
        }

        private void load_gameli()
        {
            //在COMBOBOX里显示
            ArrayList list1 = new ArrayList(); 
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
                list1.Add(dr[0].ToString().Trim());
            }
            CB_gamelist.ItemsSource= list1;
            conn.Close();
        }
        private void user_return_main_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow1 = new MainWindow();
            App.Current.MainWindow = mainWindow1;
            this.Close();
            mainWindow1.Show();
        }

        private void B_checkcomment_Click(object sender, RoutedEventArgs e)
        {
            comment comment1 = new comment();
            comment1.Show();
        }

        private void CB_gamelist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void B_comment_Click(object sender, RoutedEventArgs e)
        {
            String connStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=linjun_2019014867_bigwork;";
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connStr);
                //打开数据库连接
                conn.Open();
                //判断用户名是否重复
               
                string sql = "insert into comment(game,comment,score,account) values('{0}','{1}','{2}','{3}')";
                //填充SQL语句
                string willgame = Convert.ToString(CB_gamelist.SelectedItem);
                int wiiscore= Convert.ToInt32(CB_score.SelectedIndex);
                string wiilscore= Convert.ToString(wiiscore);
                sql = string.Format(sql,willgame,TB_comment.Text,wiilscore,MainWindow.zh);
                //创建SqlCommand对象
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //执行SQL语句
                int returnvalue = Convert.ToInt32(cmd.ExecuteNonQuery());
                //判断SQL语句是否执行成功
                if (returnvalue != -1)
                {
                    MessageBox.Show("评论成功！");
                    TB_comment.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("评论失败！" + ex.Message);
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

        private void B_clear_Click(object sender, RoutedEventArgs e)
        {
            TB_comment.Text = null;
        }

        private void B_xiugai_Click(object sender, RoutedEventArgs e)
        {
            xiugai xiugai1 = new xiugai();
            xiugai1.Show();
        }
    }
}
/* 连接数据库
            String connetStr = "server=rm-bp16jmk0l3xrjx2336o.mysql.rds.aliyuncs.com;port=3306;user=iceiceice;password=Ww1234567;database=linjun_2019014867_bigwork;";
            MySqlConnection conn = new MySqlConnection(connetStr);
            try
{
    conn = new SqlConnection(connStr);
    //打开数据库连接
    conn.Open();
    //创建SqlCommand对象
    SqlCommand cmd = new SqlCommand("AddUser", conn);
    //设置SQLCommand对象的命令类型（CommandType）是存储过程
    cmd.CommandType = CommandType.StoredProcedure;
    //设置存储过程需要的参数
    cmd.Parameters.AddWithValue("name", textBox1.Text);
    cmd.Parameters.AddWithValue("password", textBox2.Text);
    //执行存储过程
    int returnvalue = cmd.ExecuteNonQuery();
    Console.WriteLine(returnvalue);
    //判断SQL语句是否执行成功
    if(returnvalue != -1)
    {
        MessageBox.Show("注册成功！");
    }
}
catch(Exception ex)
{
    MessageBox.Show("注册失败！"+ex.Message);
}
finally
{
    if (conn != null)
    {
        //关闭数据库连接
        conn.Close();
    }
*/