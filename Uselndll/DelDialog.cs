using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Uselndll
{
    public partial class DelDialog : Form
    {
        Timer timer;
        DataTable table;
        public static int tranIndex = 0;
        public static Boolean status = false;
        String name = "";
        int index = 0;
        String codeVal;
        String outPath;
        public DelDialog(DataTable dt,String path)
        {
            InitializeComponent();
            table = dt;
            outPath = path;

            comboAllCard.Enabled = true;
            comboAllCard.Text = "请选择...";
            comboAllCard.DataSource = table;
            comboAllCard.DisplayMember = "身份证号";
            comboAllCard.ValueMember = "身份证号";

            btnDelTrue.Enabled = true;

            timer = new Timer();
            timer.Interval = 1500;
            timer.Tick += (s, e1) =>
            {
                if (comboAllCard.SelectedValue != null )
                {
                    codeVal = comboAllCard.SelectedValue.ToString();
                  
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        if (table.Rows[i][columnName: "身份证号"] == codeVal)
                        {
                            txtDelName.Text = table.Rows[i][0].ToString();
                            name = table.Rows[i][0].ToString();
                            if (index == 0)
                            {
                                index += 1;
                                tranIndex = i;
                            }
                            //Console.WriteLine(txtDelName.Text);
                            break;
                        }
                    }
                }
            };
            timer.Start();
        }

        private void btnDelTrue_Click(object sender, EventArgs e)
        {
            if (name != "")
            {
                if (index == 1) {
                    index += 1;
                    timer.Stop();
                    status = true;
                    txtDelName.Clear();
                    comboAllCard.Enabled = false;
               
                    String name1 = codeVal.Substring(1);
                    String delPath = outPath + @"\" + name1 + ".jpg";
                    Console.WriteLine(delPath);
                    if (File.Exists(delPath))
                    {
                        File.Delete(delPath);
                    }
                    table.Rows.RemoveAt(tranIndex);
                    table.AcceptChanges();
                    txtBoxDelLog.Text = "用户 " + name + " 已删除" + "\n"
                        + "图像" + name1 + ".jpg" + "已删除";
                    btnDelTrue.Enabled = false;
                }
                status = false;
            }
            else
            {
                status = false;
                txtBoxDelLog.Text = "ERROR:请先选择用户";
            }
        }

        private void btnDelCancel_Click(object sender, EventArgs e)
        {
            timer.Stop();
            //status = false;
            Close();
        }

        private void Form_close(object sender, FormClosingEventArgs e)
        {
            //status=false;
            timer.Stop();
        }

        private void txtDelName_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboAllCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void DelDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
