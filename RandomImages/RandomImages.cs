using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomImages
{
    public partial class RandomImages : Form
    {
        private const int MAX_WAIT_SECOND = 20;
        private static readonly Random _random = new Random();

        public RandomImages()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            StartRandomImages();
            await Task.Delay(MAX_WAIT_SECOND * 1000);
            btnStart.Enabled = true;
        }

        private async void StartRandomImages()
        {
            string currentFolder = Path.GetDirectoryName(Application.ExecutablePath);
            string pictureFolder = Path.Combine(currentFolder, "Anh");
            for (int i = 0; i < MAX_WAIT_SECOND; i++)
            {
                int randomImageNumber = _random.Next(1, 5);
                pictureBox.Image = Image.FromFile(Path.Combine(pictureFolder, $"{randomImageNumber}.png"));
                await Task.Delay(1000);
            }

            pictureBox.Image= Image.FromFile(Path.Combine(pictureFolder, $"6.png"));
        }
    }
}
