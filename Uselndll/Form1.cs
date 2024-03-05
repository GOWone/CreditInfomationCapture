using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
namespace Uselndll
{
    public partial class Form1 : Form
    {
        String inputPath = "";
        String outputPath = "";
        int successCount = 0;
        int picCurCount = 0;
        int picOldCount = 0;
        Timer timer;
        int picIndex = 0;
        int saveCurfileCount = 0;
        int saveOldfileCount = 0;
        String jumpToEditPicPath = "";
        DataTable dt;
        DirectoryInfo directoryInfo;
        FileInfo[] fileSystemInfo;
        int dtRowCount = 0;
        private SaveFileDialog m_objSave;
        Boolean status = false;
        //删除项下标
        int index = 0;
        //检测Excel导出情况
        Boolean isOutputExcel = false;
        //检测导出文件数量，用于判断是否存在未导出文件
        int oldFileCount = 0;
        int curFileCount = 0;
       
        public Form1()
        {
            InitializeComponent();
            //删除项下标
            index = DelDialog.tranIndex;
            //读卡定时器
            tmrLoop = new System.Timers.Timer();
            tmrLoop.Interval = 300;
            tmrLoop.Enabled = false;
            tmrLoop.Elapsed += TmrLoop_Elapsed;
            readWatch = new Stopwatch();
            isStop = true;
            //透明背景
            pictureBox3.SendToBack();
            //设置DataTable
            dt = new DataTable("userInfo");
            dt.Columns.Add("姓名", Type.GetType("System.String"));
            dt.Columns.Add("身份证号", Type.GetType("System.String"));

            Form1_Load();
            //页面数据刷新定时器
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e1) =>
            {
               String path = inputPath;
               String outPath = outputPath;
                //控制删除数据刷新
                if (status && DelDialog.status)
                {
                    dt.Rows.RemoveAt(index);
                    dt.AcceptChanges();
                    status = false;
                }
                if (path != "")
                {
                    //picCurCount = Directory.GetFiles(path).Length;
                    directoryInfo = new DirectoryInfo(inputPath);
                    fileSystemInfo = directoryInfo.GetFiles("*.jpg");
                    picCurCount = fileSystemInfo.Length;
                    //Console.WriteLine(fileSystemInfo.Length);
                    //总数
                    totalCount.Text = saveCurfileCount + "";
                    if (picCurCount != picOldCount)
                    {
                        picOldCount = picCurCount;
                        rushInputContainer();
                    }
                }
                // Console.WriteLine(picCurCount);
                if (outPath != "")
                {
                    //查询输入输出文件夹中文件数量
                    saveCurfileCount = Directory.GetFiles(outPath).Length;
                    //控制输出数据刷新，防止大量占用资源
                    if (saveCurfileCount != saveOldfileCount)
                    {
                        saveOldfileCount = saveCurfileCount;
                        //图像输出列表刷新
                        rushOutputContainer();
                    }
                }
            };
            timer.Start();
        }

        public class FileStatusHelper
        {
            [DllImport("kernel32.dll")]
            public static extern IntPtr _lopen(string lpPathName, int iReadWrite);

            [DllImport("kernel32.dll")]
            public static extern bool CloseHandle(IntPtr hObject);

            public const int OF_READWRITE = 2;
            public const int OF_SHARE_DENY_NONE = 0x40;
            public static readonly IntPtr HFILE_ERROR = new IntPtr(-1);

            /// <summary>
            /// 查看文件是否被占用
            /// </summary>
            /// <param name="filePath"></param>
            /// <returns></returns>
            public static bool IsFileOccupied(string filePath)
            {
                IntPtr vHandle = _lopen(filePath, OF_READWRITE | OF_SHARE_DENY_NONE);
                CloseHandle(vHandle);
                return vHandle == HFILE_ERROR ? true : false;
            }
        }

        private void Form1_Load()
        {

        }

        System.Timers.Timer tmrLoop;
        bool isStop;
        Stopwatch readWatch;

        #region Api
        [DllImport("Sdtapi.dll")]
        
        private static extern int InitComm(int iPort);
        [DllImport("Sdtapi.dll")]
        private static extern int Authenticate();
        [DllImport("Sdtapi.dll")]
        private static extern int ReadBaseInfos(StringBuilder Name, StringBuilder Gender, StringBuilder Folk,
                                                    StringBuilder BirthDay, StringBuilder Code, StringBuilder Address,
                                                        StringBuilder Agency, StringBuilder ExpireStart, StringBuilder ExpireEnd);
        [DllImport("Sdtapi.dll")]
        private static extern int ReadBaseInfosPhoto(StringBuilder Name, StringBuilder Gender, StringBuilder Folk,
                                                    StringBuilder BirthDay, StringBuilder Code, StringBuilder Address,
                                                        StringBuilder Agency, StringBuilder ExpireStart, StringBuilder ExpireEnd, StringBuilder directory);
        [DllImport("Sdtapi.dll")]
        private static extern int ReadBaseInfosFPPhoto(StringBuilder Name, StringBuilder Gender, StringBuilder Folk,
                                                    StringBuilder BirthDay, StringBuilder Code, StringBuilder Address,
                                                        StringBuilder Agency, StringBuilder ExpireStart, StringBuilder ExpireEnd, StringBuilder directory, StringBuilder pucFPMsg, ref int puiFPMsgLen);
        [DllImport("Sdtapi.dll")]
        private static extern int Routon_DecideIDCardType();
        [DllImport("Sdtapi.dll")]
        private static extern int Routon_ReadAllForeignBaseInfos(StringBuilder EnName, StringBuilder Gender, StringBuilder Code, StringBuilder Nation, StringBuilder CnName, StringBuilder BirthDay, StringBuilder ExpireStart, StringBuilder ExpireEnd, StringBuilder CardVertion, StringBuilder Agency, StringBuilder CardType, StringBuilder FutureItem);
        [DllImport("Sdtapi.dll")]
        private static extern int Routon_ReadAllGATBaseInfos(StringBuilder Name, StringBuilder Gender, StringBuilder FutureItem1, StringBuilder BirthDay, StringBuilder Address, StringBuilder Code, StringBuilder Agency, StringBuilder ExpireStart, StringBuilder ExpireEnd, StringBuilder PassID, StringBuilder SignCnt, StringBuilder FutureItem2, StringBuilder CardType, StringBuilder FutureItem3);
        [DllImport("Sdtapi.dll")]
        private static extern int CloseComm();
        [DllImport("Sdtapi.dll")]
        private static extern int ReadBaseMsg(byte[] pMsg, ref int len);
        [DllImport("Sdtapi.dll")]
        private static extern int ReadBaseMsgW(byte[] pMsg, ref int len);
        [DllImport("Sdtapi.dll")]
        private static extern int Routon_IC_FindCard();
        [DllImport("Sdtapi.dll")]
        private static extern int Routon_IC_HL_ReadCardSN(StringBuilder SN);
        [DllImport("Sdtapi.dll")]
        private static extern int Routon_RepeatRead(bool isRepeat);
        #endregion

        private void clearUI()
        {
            txtCardName.Text = "";
            txtCardID.Text = "";
        }

        private void FreeImage(PictureBox pb)
        {
            if (pb != null && pb.Image != null)
            {
                pb.Image.Dispose();
                pb.Image = null;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           DialogResult dr;
           Console.WriteLine(dt.Rows.Count);
           MessageBoxButtons mess = MessageBoxButtons.OKCancel;
            if (oldFileCount == curFileCount)
            {
                isOutputExcel = false;
                dt.Clear();
                dr = MessageBox.Show("确认退出吗？", "退出程序", mess);
                timer.Stop();
                if (dr != DialogResult.OK)
                {
                    e.Cancel = true;
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            else{
                DialogResult dr1;
                dr1 = MessageBox.Show("当前存在新增数据未导出，请导出后关闭\n点击确定强制关闭", "严重警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr1 != DialogResult.OK)
                {
                    e.Cancel = true;
                }
                else {
                    Environment.Exit(0);
                }
            }
        }
        private void ShowImage(PictureBox pb, string srcfilepath, string destfilepath)
        {
            FreeImage(pb);

            if (File.Exists(destfilepath))
            {
                File.Delete(destfilepath);
            }

            if (File.Exists(srcfilepath))
            {
                File.Copy(srcfilepath, destfilepath);
                pb.Image = System.Drawing.Image.FromFile(destfilepath);
            }
        }

        /*
               private void button1_Click(object sender, EventArgs e)
               {
                   //打开端口
                   int intOpenRet = InitComm(1001);
                   if (intOpenRet != 1)
                   {
                       MessageBox.Show("阅读机具未连接");
                       return;
                   }

                   StringBuilder Name = new StringBuilder(1024);
                   if(Routon_IC_HL_ReadCardSN(Name) == 1)
                   {
                       label6.Text = Name.ToString();
                   }
                   else
                   {
                        MessageBox.Show("Routon_IC_HL_ReadCardSN error");
                        return;
                   }
                   int ret =  Routon_IC_FindCard();
                   //label4.Text = ret;

                    //关闭端口
                   int intCloseRet = CloseComm();
               }
       */
        private void button1_Click(object sender, EventArgs e)
        {
            clearUI();
           // Routon_RepeatRead(true);
            //打开端口
            int intOpenRet = InitComm(1001);
            if (intOpenRet != 1)
            {
                MessageBox.Show("阅读机具未连接");
                return;
            }

            //卡认证
            int intReadRet = Authenticate();
            if (intReadRet != 1)
            {
                MessageBox.Show("卡认证失败");
                CloseComm();
                return;
            }
            int cardType = Routon_DecideIDCardType();
            if (cardType == 100)//身份证
            {
                //三种方式读取基本信息
                //ReadBaseInfos（推荐使用）
                StringBuilder Name = new StringBuilder(31);
                StringBuilder Gender = new StringBuilder(3);
                StringBuilder Folk = new StringBuilder(10);
                StringBuilder BirthDay = new StringBuilder(9);
                StringBuilder Code = new StringBuilder(19);
                StringBuilder Address = new StringBuilder(71);
                StringBuilder Agency = new StringBuilder(31);
                StringBuilder ExpireStart = new StringBuilder(9);
                StringBuilder ExpireEnd = new StringBuilder(9);
                StringBuilder directory = new StringBuilder(100);
                StringBuilder pucFPMsg = new StringBuilder(1024);
                int intReadBaseInfosRet = 0;
                directory.Append("C:\\");
                try
                {
                     intReadBaseInfosRet = ReadBaseInfos(Name, Gender, Folk, BirthDay, Code, Address, Agency, ExpireStart, ExpireEnd);
                }
                catch (Exception ex) {
                    SysExceptInfo sysExceptInfo = new SysExceptInfo(ex);
                    sysExceptInfo.WriteExceptLogToTxt();
                }
                //int intReadBaseInfosRet = ReadBaseInfosPhoto(Name, Gender, Folk, BirthDay, Code, Address, Agency, ExpireStart, ExpireEnd, directory);
                //int pucFPMsgLen = 0;
                //int intReadBaseInfosRet = ReadBaseInfosFPPhoto(Name, Gender, Folk, BirthDay, Code, Address, Agency, ExpireStart, ExpireEnd, directory, pucFPMsg, ref pucFPMsgLen);
                if (intReadBaseInfosRet != 1)
                {
                    MessageBox.Show("读卡失败");
                    CloseComm();
                    return;
                }

                txtCardID.Text = Code.ToString();
                textBox3.Text = Code.ToString();
                txtCardName.Text = Name.ToString();
                //pictureBox1.Load("c:\\photo.bmp");
                //pictureBox1.Load("photo.bmp");
                //MessageBox.Show("" + pucFPMsg.ToString());
                ShowImage(pictureBox1, AppDomain.CurrentDomain.BaseDirectory + "\\photo.bmp", AppDomain.CurrentDomain.BaseDirectory + "\\photo_bk.bmp");

            }
            else if (cardType == 101)  //外国人居留证
            {
                StringBuilder Fgn_EnName = new StringBuilder(121); //英文姓名
                StringBuilder Fgn_Gender = new StringBuilder(3);   //性别
                StringBuilder Fgn_Code = new StringBuilder(31);    //外国身份证号码
                StringBuilder Fgn_Nation = new StringBuilder(7);   //国籍
                StringBuilder Fgn_CnName = new StringBuilder(31);   //中文姓名
                StringBuilder Fgn_BirthDay = new StringBuilder(16);  //出生日期
                StringBuilder Fgn_ExpireStart = new StringBuilder(17); //证件有效期起始日期
                StringBuilder Fgn_ExpireEnd = new StringBuilder(17);  //证件有效期截至日期
                StringBuilder Fgn_CardVersion = new StringBuilder(5);  //证件版本号信息
                StringBuilder Fgn_Agency = new StringBuilder(9);  //申请受理机关代码
                StringBuilder Fgn_CardType = new StringBuilder(3);  //证件类型标识
                StringBuilder Fgn_FutureItem = new StringBuilder(7);  //预留项信息 暂无意义

                int FornRet = Routon_ReadAllForeignBaseInfos(Fgn_EnName, Fgn_Gender, Fgn_Code, Fgn_Nation, Fgn_CnName,
                    Fgn_BirthDay, Fgn_ExpireStart, Fgn_ExpireEnd, Fgn_CardVersion, Fgn_Agency, Fgn_CardType, Fgn_FutureItem);
                if (FornRet != 1)
                {
                    MessageBox.Show("读卡失败");
                    CloseComm();
                    return;
                }
                txtCardID.Text = Fgn_Code.ToString();
                txtCardName.Text = Fgn_EnName.ToString() + "  " + Fgn_CnName.ToString();

                ShowImage(pictureBox1, AppDomain.CurrentDomain.BaseDirectory + "\\photo.bmp", AppDomain.CurrentDomain.BaseDirectory + "\\photo_bk.bmp");
            }
            else if (cardType == 102)  //港澳台居住证
            {
                StringBuilder GAT_Name = new StringBuilder(31);         //姓名
                StringBuilder GAT_Sex = new StringBuilder(3);           //性别
                StringBuilder GAT_FutureItem1 = new StringBuilder(5);   //港澳台居住证第一块预留区信息
                StringBuilder GAT_BirthDay = new StringBuilder(17);     //出生日期
                StringBuilder GAT_Address = new StringBuilder(71);      //地址
                StringBuilder GAT_CardNo = new StringBuilder(37);       //证件号码
                StringBuilder GAT_Agency = new StringBuilder(31);       //签发机关
                StringBuilder GAT_ExpireStart = new StringBuilder(17);  //证件有效期起始日期
                StringBuilder GAT_ExpireEnd = new StringBuilder(17);    //证件有效期截至日期
                StringBuilder GAT_PassCardNo = new StringBuilder(19);   //通行证号码
                StringBuilder GAT_PassNu = new StringBuilder(5);        //签发次数
                StringBuilder GAT_FutureItem2 = new StringBuilder(7);   //港澳台居住证第二块预留区信息
                StringBuilder GAT_CardType = new StringBuilder(3);      //证件类型标识
                StringBuilder GAT_FutureItem3 = new StringBuilder(7);   //港澳台居住证第三块预留区信息

                int GATRet = Routon_ReadAllGATBaseInfos(GAT_Name, GAT_Sex, GAT_FutureItem1, GAT_BirthDay, GAT_Address, GAT_CardNo,
                    GAT_Agency, GAT_ExpireStart, GAT_ExpireEnd, GAT_PassCardNo, GAT_PassNu, GAT_FutureItem2, GAT_CardType, GAT_FutureItem3);
                if (GATRet != 1)
                {
                    MessageBox.Show("读卡失败");
                    CloseComm();
                    return;
                }
                txtCardID.Text = GAT_CardNo.ToString();
                txtCardName.Text = GAT_Name.ToString();

                ShowImage(pictureBox1, AppDomain.CurrentDomain.BaseDirectory + "\\photo.bmp", AppDomain.CurrentDomain.BaseDirectory + "\\photo_bk.bmp");
            }
            //关闭端口
            int intCloseRet = CloseComm();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //打开端口
            int intOpenRet = InitComm(1001);
            if (intOpenRet != 1)
            {
                MessageBox.Show("阅读机具未连接");
                return;
            }

            int index = Routon_IC_FindCard();

            StringBuilder Name = new StringBuilder(1024);
            if (Routon_IC_HL_ReadCardSN(Name) == 1)
            {
                //label2.Text = Name.ToString();
            }
            else
            {
                MessageBox.Show("Routon_IC_HL_ReadCardSN error");
                return;
            }
            int ret = Routon_IC_FindCard();
            //label4.Text = ret;

            //关闭端口
            int intCloseRet = CloseComm();
        }

        private void TmrLoop_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                tmrLoop.Stop();
                StringBuilder Name = new StringBuilder(31);
                StringBuilder Gender = new StringBuilder(3);
                StringBuilder Folk = new StringBuilder(10);
                StringBuilder BirthDay = new StringBuilder(9);
                StringBuilder Code = new StringBuilder(19);
                StringBuilder Address = new StringBuilder(71);
                StringBuilder Agency = new StringBuilder(31);
                StringBuilder ExpireStart = new StringBuilder(9);
                StringBuilder ExpireEnd = new StringBuilder(9);
                StringBuilder directory = new StringBuilder(100);
                StringBuilder pucFPMsg = new StringBuilder(1024);
                
                //打开端口
                int intOpenRet = InitComm(1001);
                if (intOpenRet != 1)
                {
                    AppendToText(txtReadLog, "打开端口失败");
                    return;
                }

                //卡认证
                int intReadRet = Authenticate();
                if (intReadRet != 1)
                {
                    //AppendToText(txtReadLog, "卡认证失败");
                    return;
                }

                readWatch.Reset();
                readWatch.Start();

                //AppendToText(txtReadLog, "开始读卡");
                int intReadBaseInfosRet = ReadBaseInfos(Name, Gender, Folk, BirthDay, Code, Address, Agency, ExpireStart, ExpireEnd);
                if (intReadBaseInfosRet != 1)
                {
                    //AppendToText(txtReadLog, "读卡失败");
                    return;
                }
           
                readWatch.Stop();
             
                AppendToText(
                txtReadLog,
                string.Format("[自动读卡]-姓名:{0},身份证号:{1}", Name.ToString(), Code.ToString()));
                //异步线程更新数据
                Action action = () =>
                {
                    txtCardName.Text = Name.ToString();
                    txtCardID.Text = Code.ToString();
                    ShowImage(pictureBox1, AppDomain.CurrentDomain.BaseDirectory + "\\photo.bmp", AppDomain.CurrentDomain.BaseDirectory + "\\photo_bk.bmp");
                };
                Invoke(action);
            }
            catch (Exception ex)
            {
                AppendToText(txtReadLog, "读卡异常:" + ex.Message);
            } 
            finally
            {
                //关闭端口
                int intCloseRet = CloseComm();
                if (!isStop)
                    tmrLoop.Start();
            }
        }

        //添加信息至提示框
        void AppendToText(TextBox textbox, string text)
        {
            if (textbox.InvokeRequired)
                textbox.Invoke(new MethodInvoker(() => textbox.AppendText(text + Environment.NewLine)));
            else
                textbox.AppendText(text + Environment.NewLine);
        }
        /*
        private void btnStartReadID_Click(object sender, EventArgs e)
        {
            Routon_RepeatRead(true);
            if (isStop)
            {
                isStop = false;
                tmrLoop.Start();
                btnStartReadID.Text = "停止读卡";
            }
            else
            {
                isStop = true;
                tmrLoop.Stop();
                btnStartReadID.Text = "开始循环读身份证";
            }
        }
        */
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnSekectFolder_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.Description = "选择目标文件夹";
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    inputPath = folderBrowserDialog.SelectedPath;
                    textBox1.Text = inputPath;
                    if (textBox1.Text == textBox2.Text)
                    {
                        MessageBoxButtons mess = MessageBoxButtons.OKCancel;
                        DialogResult dr = MessageBox.Show("导入/导出文件夹相同，重新设置", "出现错误", mess);
                        textBox1.Text = null;
                    }
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }
            String path = inputPath;
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] fileSystemInfo = directoryInfo.GetFiles("*.*");
            if (fileSystemInfo.Length > 0)
            {
                SortAsFileCreationTime(ref fileSystemInfo);
                //加载首张图像
                textBox3.Text = fileSystemInfo[0].Name;
                if (pictureBox2 != null && pictureBox2.Image != null)
                {
                    pictureBox2.Image.Dispose();
                    pictureBox2.Image = null;
                }
                this.pictureBox2.Load(inputPath + @"\" + fileSystemInfo[0].Name);
                jumpToEditPicPath = inputPath + @"\" + fileSystemInfo[0].Name;
                //倒序输出
                for (int i = fileSystemInfo.Length - 1; i >= 0; i--)
                {
                    String picName = fileSystemInfo[i].Name;
                    //Console.WriteLine(picName);
                    AppendToText(txtBoxInput, picName);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "选择目标文件夹";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                outputPath = folderBrowserDialog.SelectedPath;
                textBox2.Text = outputPath;
                if (textBox1.Text == textBox2.Text)
                {
                    MessageBoxButtons mess = MessageBoxButtons.OKCancel;
                    DialogResult dr = MessageBox.Show("导入/导出文件夹相同，重新设置", "出现错误", mess);
                    textBox2.Text = null;
                }
            }
        }

        private void btnSelectHis_Click(object sender, EventArgs e)
        {
            // string v_OpenFolderPath = null;
            if (inputPath != "")
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = inputPath;
                openFileDialog.Multiselect = false;
                openFileDialog.Title = "选择历史导入的图像";
                openFileDialog.Filter = "图像文件(*.jpg,*.png) | *.jpg;*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    //文件路径
                    String filePath = openFileDialog.FileName;
                    //文件名(带后缀)
                    String fileName = Path.GetFileName(filePath);
                    String[] arr = fileName.Split('.');

                    Console.WriteLine(arr[0]);
                    textBox3.Text = arr[0];
                    pictureBox2.Load(filePath);
                }
            }
            else
            {
                MessageBoxButtons mess = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("请先选择输入文件夹", "出现错误", mess);
            }
        }
       
        private void SortAsFileCreationTime(ref FileInfo[] arrFi)
        {
            Array.Sort(arrFi, delegate (FileInfo x, FileInfo y)
            {
                return y.CreationTime.CompareTo(x.CreationTime);
            });
        }
        private void txtReadLog_TextChanged(object sender, EventArgs e)
        {

        }
        private void label18_Click(object sender, EventArgs e)
        {

        }
        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxInput_TextChanged(object sender, EventArgs e)
        {

        }

        //刷新输入列表
        private void rushInputContainer()
        {
            if (inputPath != "")
            {
                txtBoxInput.Clear();
                DirectoryInfo directoryInfo = new DirectoryInfo(inputPath);
                FileInfo[] fileSystemInfo = directoryInfo.GetFiles("*.jpg");
                if (fileSystemInfo.Length > 0)
                {
                    SortAsFileCreationTime(ref fileSystemInfo);
                    pictureBox2.Load(inputPath + @"\" + fileSystemInfo[0].Name);
                    textBox3.Text = fileSystemInfo[0].Name;
                    picIndex = 0;
                    //倒序输出
                    for (int i = fileSystemInfo.Length - 1; i >= 0; i--)
                    {
                        String picName = fileSystemInfo[i].Name;
                        AppendToText(txtBoxInput, picName);
                    }
                }
            }
        }
        //刷新输出列表
        private void rushOutputContainer()
        {
            if (outputPath != "")
            {
                txtBoxOutput.Clear();
                DirectoryInfo directoryInfo1 = new DirectoryInfo(outputPath);
                FileInfo[] fileSystemInfo1 = directoryInfo1.GetFiles("*.*");
                if (fileSystemInfo1.Length > 0)
                {
                    SortAsFileCreationTime(ref fileSystemInfo1);
                    //倒序输出
                    for (int i = fileSystemInfo1.Length - 1; i >= 0; i --)
                    {
                        String picName = fileSystemInfo1[i].Name;
                        AppendToText(txtBoxOutput, picName);
                    }
                }
            }
        }
        public class FileComparer : System.Collections.IComparer
        {
            public int Compare(object x, object y)
            {
                FileInfo file1 = x as FileInfo;
                FileInfo file2 = y as FileInfo;
                return file1.LastWriteTime.CompareTo(file2.LastWriteTime);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (inputPath != "")
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(inputPath);
                FileInfo[] fileSystemInfo = directoryInfo.GetFiles("*.*");
                if (fileSystemInfo.Length > 0)
                {
                    //String path = inputPath + @"\" + fileSystemInfo[picIndex].Name;
                    picEdition picedition = new picEdition(jumpToEditPicPath);
                    picedition.Show();
                }
                else {
                    MessageBoxButtons mess = MessageBoxButtons.OKCancel;
                    DialogResult dr = MessageBox.Show("文件夹中无图像", "出现错误", mess);
                }
            }
            else
            {
                MessageBoxButtons mess = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("请先选择输入文件夹", "出现错误", mess);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //上一张
        private void btnForward_Click(object sender, EventArgs e)
        {
            if (inputPath != "" && outputPath != "")
            {
                if (picIndex > 0)
                {
                    picIndex -= 1;
                    String path = inputPath;
                    DirectoryInfo directoryInfo = new DirectoryInfo(path);
                    FileInfo[] fileSystemInfo = directoryInfo.GetFiles("*.*");
                    SortAsFileCreationTime(ref fileSystemInfo);
                    if (pictureBox2 != null && pictureBox2.Image != null)
                    {
                        pictureBox2.Image.Dispose();
                        pictureBox2.Image = null;
                    }
                    pictureBox2.Load(path + @"\" + fileSystemInfo[picIndex].Name);
                    String[] arr = fileSystemInfo[picIndex].Name.Split('.');
                    textBox3.Text = arr[0];
                    jumpToEditPicPath = path + @"\" + fileSystemInfo[picIndex].Name;
                }
            }
            else
            {
                MessageBoxButtons mess = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("请先选择输入/输出文件夹", "出现错误", mess);
            }
        }

        //下一张
        private void btnNext_Click(object sender, EventArgs e)
        {
            Console.WriteLine(picCurCount);
            if (inputPath != "" && outputPath != "")
            {
                if (picIndex < picCurCount - 1)
                {
                    picIndex += 1;
                    String path = inputPath;
                    DirectoryInfo directoryInfo = new DirectoryInfo(path);
                    FileInfo[] fileSystemInfo = directoryInfo.GetFiles("*.*");
                    SortAsFileCreationTime(ref fileSystemInfo);
                    if (pictureBox2 != null && pictureBox2.Image != null)
                    {
                        pictureBox2.Image.Dispose();
                        pictureBox2.Image = null;
                    }
                    pictureBox2.Load(path + @"\" + fileSystemInfo[picIndex].Name);
                    String[] arr = fileSystemInfo[picIndex].Name.Split('.');
                    textBox3.Text = arr[0];
                    jumpToEditPicPath = path + @"\" + fileSystemInfo[picIndex].Name;
                }
            }
            else {
                MessageBoxButtons mess = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("请先选择输入/输出文件夹", "出现错误", mess);
            }
        }

        //导入Excel
        private void m_mthDoExport(DataTable dtSource, string strFileName)
        {
            int rowNum = dtSource.Rows.Count;
            int columnNum = dtSource.Columns.Count;
            int rowIndex = 1;
            int columnIndex = 0;

            if (dtSource == null || string.IsNullOrEmpty(strFileName))
            {
                return;
            }
            if (rowNum > 0)
            {
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                //将DataTable的列名导入Excel表第一行
                foreach (DataColumn dc in dtSource.Columns)
                {
                    columnIndex++;
                    xlApp.Cells[rowIndex, columnIndex] = dc.ColumnName;
                }
                //将DataTable中的数据导入Excel中
                for (int i = 0; i < rowNum; i++)
                {
                    rowIndex++;
                    columnIndex = 0;
                    for (int j = 0; j < columnNum; j++)
                    {
                        columnIndex++;
                        xlApp.Cells[rowIndex, columnIndex] = dtSource.Rows[i][j].ToString();
                    }
                }
                xlBook.SaveCopyAs(strFileName);
                xlApp = null;
                xlBook = null;
            }
        }

        //判断本机是否安装Excel文件方法
        private bool codeboolisExcelInstalled()
        {
            Type type = Type.GetTypeFromProgID("Excel.Application");
            return type != null;
        }

        private void saveToExcel_Click(object sender, EventArgs e)
        {
            if (codeboolisExcelInstalled())
            {
                if (dt.Rows.Count > 0)
                {
                    //MessageBox.Show("本机已安装Excel文件");
                    m_objSave = new SaveFileDialog();
                    this.m_objSave.DefaultExt = "xls";
                    this.m_objSave.Filter = "Excel文件(*.xls)|*.xls";

                    if (this.m_objSave.ShowDialog() == DialogResult.OK)
                    {
                        m_mthDoExport(dt, m_objSave.FileName);
                        oldFileCount = curFileCount;
                        isOutputExcel = true;
                        // DataTable data = distinct(dt);
                    //    String path = m_objSave.FileName;
                        //Console.WriteLine(path);
                     //   Boolean status = FileStatusHelper.IsFileOccupied(path);
                        /*if (status)
                        {
                            MessageBox.Show("当前文件被占用，请更名 保存/关闭 正在使用的文件", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else {
                            m_mthDoExport(dt, m_objSave.FileName);
                            oldFileCount = curFileCount;
                            isOutputExcel = true;
                        }
                        */
                    }
                    else
                    {
                        return;
                    }
                }
                else {
                    MessageBox.Show("当前无数据保存，无法导出", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("当前系统没有发现可执行的Excel文件, 如需使用请先安装office Excel组件", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // DataRow drs  = dt.Rows[1];
            // Console.WriteLine(drs[1]);
        }
        private static DataTable distinct(DataTable dt) {
            DataView dv = dt.DefaultView;
            DataTable dataTable = dv.ToTable("Dist", true, "姓名", "身份证号");
            return dataTable;
        }

        private static void isIncludeData(DataTable dt,String codeString) {
            //数据修改
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][columnName: "身份证号"] == codeString)
                {
                    Console.WriteLine(i);
                    //Console.WriteLine(txtDelName.Text);
                    break;
                }
            }
            //return "";
        }


        private void btnChangeSave_Click(object sender, EventArgs e)
        {
            if (outputPath != "")
            {
                if (pictureBox2.Image != null)
                {
                    if (txtCardID.Text != "" && txtCardName.Text != "")
                    {
                        if (txtCardID.Text.Length == 18)
                        {
                            textBox3.Text = txtCardID.Text;
                            String filePath = outputPath + @"\" + txtCardID.Text + ".jpg";
                            if (File.Exists(filePath))
                            {
                                //File.Delete(filePath);
                                //Console.WriteLine(txtCardID.Text);
                                MessageBoxButtons mess = MessageBoxButtons.OKCancel;
                                DialogResult dr1 = MessageBox.Show("检测到重复身份证号: \n" + txtCardID.Text +"\n是否确定覆盖保存!", "警告", mess);
                                if (dr1 != DialogResult.Cancel)
                                {
                                    //图像保存
                                    curFileCount += 1;
                                    String picSavePath = outputPath + @"\" + textBox3.Text + ".jpg";
                                    this.pictureBox2.Image.Save(picSavePath);
                                    advice.Text = "已选中保存";
                                    //内部DataTable数据保存
                                    /*
                                    DataRow dr = dt.NewRow();
                                    textBox3.Text = txtCardID.Text;
                                    dr["姓名"] = txtCardName.Text;
                                    dr["身份证号"] = "'" + textBox3.Text;
                                    dt.Rows.Add(dr);
                                    dt = distinct(dt);
                                    dtRowCount += 1;
                                    successCount += 1;
                                    */
                                    // isIncludeData(dt, textBox3.Text);
                                    /*
                                    if (updateIndex != "") {
                                        dt.Rows[int.Parse(updateIndex)][0] = txtCardName.Text;
                                    }
                                    */
                                    String test = "'" + textBox3.Text;
                                    //Console.WriteLine(test);
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        if (dt.Rows[i][1].Equals(test))
                                        {
                                            //Console.WriteLine(dt.Rows[i][1]);
                                            //Console.WriteLine(txtDelName.Text);
                                            dt.Rows[i][0] = txtCardName.Text;
                                            break;
                                        }
                                    }
                                    AppendToText(txtReadLog, "图片已覆盖保存 , 成功读取：" + successCount);
                                    AppendToText(txtReadLog, "读入:" + textBox3.Text.ToString());
                                    AppendToText(txtReadLog, "-----------------------");
                                    AppendToText(txtBoxOutput, textBox3.Text + ".jpg");
                                }
                                if (dr1 != DialogResult.OK)
                                {
                                    AppendToText(txtReadLog, "操作取消,图片未保存");
                                    AppendToText(txtReadLog, "-----------------------");
                                }
                            }
                            else {
                                curFileCount += 1;
                                String picSavePath = outputPath + @"\" + textBox3.Text + ".jpg";
                                this.pictureBox2.Image.Save(picSavePath);
                                advice.Text = "已选中保存";
                                DataRow dr = dt.NewRow();
                                textBox3.Text = txtCardID.Text;
                                dr["姓名"] = txtCardName.Text;
                                dr["身份证号"] = "'" + textBox3.Text;
                                dt.Rows.Add(dr);
                                dt = distinct(dt);
                                dtRowCount += 1;
                                successCount += 1;
                                AppendToText(txtReadLog, "图片已保存 , 成功读取：" + successCount);
                                AppendToText(txtReadLog, "读入:" + textBox3.Text.ToString());
                                AppendToText(txtReadLog, "-----------------------");
                                AppendToText(txtBoxOutput, textBox3.Text + ".jpg");
                            }   
                        }
                        else {
                            MessageBoxButtons mess = MessageBoxButtons.OKCancel;
                            DialogResult dr = MessageBox.Show("身份证号格式错误，应为18位", "出现错误", mess);
                        }
                    }
                    else
                    {
                        MessageBoxButtons mess = MessageBoxButtons.OKCancel;
                        DialogResult dr = MessageBox.Show("请先读卡或手动输入", "出现错误", mess);
                        //AppendToText(errLog, "ERROR:当前无图像文件");
                    }
                }
                else
                {
                    advice.Text = "未选中";
                    MessageBoxButtons mess = MessageBoxButtons.OKCancel;
                    DialogResult dr = MessageBox.Show("当前无图像 ", "出现错误", mess);
                }
            }
            else
            {
                MessageBoxButtons mess = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("请先选择输出文件夹", "出现错误", mess);
                //AppendToText(errLog, "ERROR:请先选择输出文件夹");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DelDialog delDialog = new DelDialog(dt,outputPath);
            delDialog.ShowDialog();
            status = true;
        }

        private void HeadUpdate_Click(object sender, EventArgs e)
        {
            rushInputContainer();
        }

        private void autoReadMode_Click(object sender, EventArgs e)
        {
            Routon_RepeatRead(true);
            if (isStop)
            {
                isStop = false;
                tmrLoop.Start();
                button1.Enabled = false;
                autoReadMode.Text = "停止读卡";
            }
            else
            {
                isStop = true;
                tmrLoop.Stop();
                autoReadMode.Text = "自动读卡";
                button1.Enabled = true;
            }
        }
    }
}



