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
    /// comment.xaml 的交互逻辑
    /// </summary>
    public partial class comment : Window
    {
        public comment()
        {
            InitializeComponent();
            load_gameli();
            DataGameListForm();
        }
        private void load_gameli()
        {
            //在LISTBOX里显示
            ArrayList list3 = new ArrayList();
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
                list3.Add(dr[0].ToString().Trim());
            }
            LB_comment_gamelist.ItemsSource = list3;
            conn.Close();
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
                string sql = "select * from comment where game='{0}' ";
               
                sql = string.Format(sql, LB_comment_gamelist.SelectedItem);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //创建SqlDataAdapter类的对象
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                //创建DataSet类的对象
                DataTable ds = new DataTable();
                //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                sda.Fill(ds);
                //设置表格控件的DataSource属性
                DG_comment.ItemsSource = ds.DefaultView;
                DG_comment.IsReadOnly = true;
                //设置第 1 列的列标题
                //DG_comment.Columns[0].Header = "游戏";
                //以此类推
                // DG_comment.Columns[1].Header = "评论";
               // DG_comment.Columns[2].Header = "分数";
                //DG_comment.Columns[3].Header = "账号";
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

        private void DG_comment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LB_comment_gamelist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGameListForm();
            L_game.Content = LB_comment_gamelist.SelectedItem;
        }
    }
}
