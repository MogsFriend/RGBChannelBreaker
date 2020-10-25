namespace RGBChannelBreaker
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void FileOpenMenu(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "PNG|*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (File.Exists(ofd.FileName))
                    {
                        var img = (Bitmap)Image.FromFile(ofd.FileName);

                        Blue.Size = img.Size;
                        Green.Size = img.Size;
                        Red.Size = img.Size;
                        Alpha.Size = img.Size;

                        Bitmap A = new Bitmap(img.Width, img.Height);
                        Bitmap R = new Bitmap(img.Width, img.Height);
                        Bitmap G = new Bitmap(img.Width, img.Height);
                        Bitmap B = new Bitmap(img.Width, img.Height);

                        for (var x = 0; x < img.Width; x++)
                        {
                            for (var y = 0; y < img.Height; y++)
                            {
                                var a = img.GetPixel(x, y);
                                A.SetPixel(x, y, Color.FromArgb(a.A, 255, 255, 255));
                                R.SetPixel(x, y, Color.FromArgb(a.R, 255, 255, 255));
                                G.SetPixel(x, y, Color.FromArgb(a.G, 255, 255, 255));
                                B.SetPixel(x, y, Color.FromArgb(a.B, 255, 255, 255));
                            }
                        }

                        Alpha.Image = A;
                        Red.Image = R;
                        Green.Image = G;
                        Blue.Image = B;
                    }
                }
                catch 
                {
                    MessageBox.Show("이미지 처리 과정에서 문제가 발생했습니다.");
                    Console.WriteLine("이미지 처리 오류");
                }
            }
        }

        private void FileSaveMenu(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var filename = sfd.FileName;
                Alpha.Image.Save(filename.Replace(".png", "_A.png"));
                Red.Image.Save(filename.Replace(".png", "_R.png"));
                Green.Image.Save(filename.Replace(".png", "_G.png"));
                Blue.Image.Save(filename.Replace(".png", "_B.png"));
            }
        }
    }
}
