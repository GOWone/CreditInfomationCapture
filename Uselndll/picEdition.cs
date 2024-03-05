using System;
using System.Drawing;
using System.Windows.Forms;

namespace Uselndll
{
    public partial class picEdition : Form
    {
        public picEdition(String path)
        {
            InitializeComponent();
            editPixelWidth.Text = 480 + "";
            editPixelHeight.Text = 640 + "";
            editDpiVal.Text = 300 + "";
            if (editArea != null && editArea.Image != null)
            {
                editArea.Image.Dispose();
                editArea.Image = null;
            }
            this.editArea.Load(path);
            /*
            MagickImageInfo imageInfo = new MagickImageInfo(path);
            //宽高
            int width = imageInfo.Width;
            int height = imageInfo.Height;
            Size picSize = new Size(width, height);
            //分辨率
            double wpx = imageInfo.Density.X;
            double hpx = imageInfo.Density.Y;
            //判断分辨率单位
            if (imageInfo.Density.Units == DensityUnit.PixelsPerCentimeter) {
                wpx *= 2.54;
                hpx *= 2.54;
            }
            */
            Image image = Image.FromFile(path);

            initPicWidth.Text = image.Width + "";
            initPicHeight.Text = image.Height + "";
            //    MessageBoxButtons mess = MessageBoxButtons.OKCancel;
            //    DialogResult dr = MessageBox.Show("图片编辑功能尚不完善", "提示", mess);
        }

        private void picEdition_Load(object sender, EventArgs e)
        {
 
        }

        private void btnBigPic_Click(object sender, EventArgs e)
        {
            /*
            int x,y;
            x = editArea.Location.X - 200;
            if (editArea.Location.Y <= 0)
            {
                y = 0;
            }
            else { 
                y = editArea.Location.Y - 160;
            }
            editArea.Location = new Point(x,y);
            */
            editArea.SizeMode = PictureBoxSizeMode.Zoom;
            editArea.Size = new Size(editArea.Size.Width + 160, editArea.Size.Height + 90);
            curWidth.Text = editArea.Size.Width + "";
            curHeight.Text = editArea.Size.Height + "";
        }

        private void btnSmallPic_Click(object sender, EventArgs e)
        {
            /*
            int x, y; 
            x = editArea.Location.X + 200;
            if (editArea.Location.X < 300) 
            {
                y = 0;
            } 
            else 
            {
                y = editArea.Location.Y + 80; 
            }
            editArea.Location = new Point(x, y);
            */
            editArea.SizeMode = PictureBoxSizeMode.Zoom;
            editArea.Size = new Size(editArea.Width - 160, editArea.Height - 90);
        }
    }
}
