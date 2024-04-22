using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using JA_Saturation_CSHARP;

namespace JA_Projekt
{
    public partial class Form1 : Form
    {
        Stopwatch stopwatch = new Stopwatch();
        Saturation saturation = new Saturation();
        PictureBox pictureBox = new PictureBox();

        [DllImport("JA_Saturation_ASM.dll")]
        static extern void Saturation(float[] tab, int startValue, int fullLoop, int anotherLoop, int thirdLoop, float valueR, float valueG, float valueB);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool SetDllDirectory(string lpPathName);

        public Form1()
        {
            InitializeComponent();

            string relativePath = "../../../../x64/Debug";
            string absolutePath = Path.GetFullPath(relativePath);
            SetDllDirectory(absolutePath);
        }

        private void trackBar_R_Scroll(object sender, EventArgs e)
        {
            lbl_R_v.Text = trackBar_R.Value.ToString();
        }

        private void trackBar_G_Scroll(object sender, EventArgs e)
        {
            lbl_G_v.Text = trackBar_G.Value.ToString();
        }

        private void trackBar_B_Scroll(object sender, EventArgs e)
        {
            lbl_B_v.Text = trackBar_B.Value.ToString();
        }

        private void trackBar_Threads_Scroll(object sender, EventArgs e)
        {
            lbl_Threads_v.Text = trackBar_Threads.Value.ToString();
        }

        private void bttn_Choose_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (pictureBox2.Image != null)
                {
                    pictureBox2.Image.Dispose();
                }
                if (pictureBox.Image != null && pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox.Image.Dispose();
                }
                pictureBox2.Image = null;
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                pictureBox.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void bttn_Clear_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                pictureBox2.Image.Dispose();
            }
            if (pictureBox.Image != null)
            {
                pictureBox.Image.Dispose();
            }
            if(pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            pictureBox1.Image = null;
            pictureBox2.Image = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar_Threads.Value = Environment.ProcessorCount;
            lbl_Threads_v.Text=Environment.ProcessorCount.ToString();
            pictureBox1.AllowDrop = true;
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                var fileNames = data as string[];
                if(fileNames.Length > 0)
                {
                    if (pictureBox2.Image != null)
                    {
                        pictureBox2.Image.Dispose();
                    }
                    if(pictureBox.Image != null && pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox.Image.Dispose();
                    }
                    pictureBox2.Image = null;
                    pictureBox1.Image = Image.FromFile(fileNames[0]);
                    pictureBox.Image = Image.FromFile(fileNames[0]);
                }
            }
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void bttn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bttn_Start_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox.Image.Dispose();
                pictureBox.Image = (Image)pictureBox1.Image.Clone();
                var bmp = (Bitmap)pictureBox.Image;
                int numThreads = trackBar_Threads.Value;
                int anotherPixels = bmp.Width % numThreads;
                int pixelsPerThreads = (bmp.Width - anotherPixels) / numThreads;
                int[,] section = new int[numThreads, 2];
                for (int i = 0; i < numThreads; i++)
                {
                    if (anotherPixels > 0)
                    {
                        anotherPixels--;
                        if (i == 0)
                        {
                            section[i, 0] = 0;
                            section[i, 1] = pixelsPerThreads + 1; ;
                        }
                        else
                        {
                            section[i, 0] = section[i - 1, 1];
                            section[i, 1] = section[i, 0] + pixelsPerThreads + 1;
                        }
                    }
                    else
                    {
                        if (i == 0)
                        {
                            section[i, 0] = 0;
                            section[i, 1] = pixelsPerThreads;
                        }
                        else
                        {
                            section[i, 0] = section[i - 1, 1];
                            section[i, 1] = section[i, 0] + pixelsPerThreads;
                        }
                    }
                }
                Thread[] threads = new Thread[numThreads];
                float valueR, valueG, valueB;
                float t1 = trackBar_R.Value;
                float t2 = trackBar_G.Value;
                float t3 = trackBar_B.Value;
                valueR = t1 / 100;
                valueG = t2 / 100;
                valueB = t3 / 100;
                int height = bmp.Height;
                if (radioBttn_CSHARP_map.Checked)
                {
                    stopwatch.Start();
                    for(int i = 0;i < numThreads;i++)
                    {
                        var section1 = section[i, 0];
                        var section2 = section[i, 1];
                        threads[i] = new Thread(() => saturation.saturationCSHARP_map(bmp, section1, section2, height, valueR, valueG, valueB));
                        threads[i].Start();
                    }
                    foreach (Thread thread in threads)
                    {
                        thread.Join();
                    }
                    stopwatch.Stop();
                    lbl_CSHARP_map_t.Text = stopwatch.ElapsedMilliseconds.ToString() + " ms";
                    stopwatch.Reset();
                    pictureBox2.Image = bmp;
                }
                if (radioBttn_CSHARP_byte.Checked)
                {
                    Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                    System.Drawing.Imaging.BitmapData bmpData =
                    bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                    bmp.PixelFormat);
                    IntPtr ptr = bmpData.Scan0;
                    int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
                    byte[] rgbValues = new byte[bytes];
                    System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
                    if(bmp.PixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                    {
                        stopwatch.Start();
                        for (int i = 0; i < numThreads; i++)
                        {
                            var section1 = section[i, 0] * height * 4;
                            var section2 = section[i, 1] * height * 4;
                            threads[i] = new Thread(() => saturation.saturationCSHARP_byte_png(rgbValues, section1, section2, valueR, valueG, valueB));
                            threads[i].Start();
                        }
                        foreach (Thread thread in threads)
                        {
                            thread.Join();
                        }
                        stopwatch.Stop();
                    } else if (bmp.PixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb)
                    {
                        stopwatch.Start();
                        for (int i = 0; i < numThreads; i++)
                        {
                            var section1 = section[i, 0] * height * 3;
                            var section2 = section[i, 1] * height * 3;
                            threads[i] = new Thread(() => saturation.saturationCSHARP_byte(rgbValues, section1, section2, valueR, valueG, valueB));
                            threads[i].Start();
                        }
                        foreach (Thread thread in threads)
                        {
                            thread.Join();
                        }
                        stopwatch.Stop();
                    }
                    lbl_CSHARP_byte_t.Text = stopwatch.ElapsedMilliseconds.ToString() + " ms";
                    stopwatch.Reset();
                    System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
                    bmp.UnlockBits(bmpData);
                    pictureBox2.Image = bmp;
                }
                if (radioBttn_ASM.Checked)
                {
                    Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                    System.Drawing.Imaging.BitmapData bmpData =
                    bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);
                    IntPtr ptr = bmpData.Scan0;
                    int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
                    byte[] rgbValues = new byte[bytes];
                    float[] rgbValuesf = new float[bytes];
                    System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
                    for (int i = 0; i < bytes; i++)
                    {
                        rgbValuesf[i] = rgbValues[i];
                    }
                    if (bmp.PixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                    {
                        stopwatch.Start();
                        for (int i = 0; i < numThreads; i++)
                        {
                            var section1 = section[i, 0] * height * 4;
                            int data = ((section[i, 1] - section[i, 0]) * height) % 16;
                            int thirdLoop = data % 2;
                            int anotherLoop = (data - thirdLoop) / 2;
                            int fullLoop = (((section[i, 1] - section[i, 0]) * height) - data) / 16;
                            threads[i] = new Thread(() => Saturation(rgbValuesf, section1, fullLoop, anotherLoop, thirdLoop, valueB + 1, valueG + 1, valueR + 1));
                            threads[i].Start();
                            threads[i].Join();
                        }
                        stopwatch.Stop();
                    }
                    for (int i = 0; i < bytes; i++)
                    {
                        rgbValues[i] = (byte)rgbValuesf[i];
                    }
                    lbl_ASM_t.Text = stopwatch.ElapsedMilliseconds.ToString() + " ms";
                    stopwatch.Reset();
                    System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
                    bmp.UnlockBits(bmpData);
                    pictureBox2.Image = bmp;
                }
            }
        }
    }
}
