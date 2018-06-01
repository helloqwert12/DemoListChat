using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;


namespace DemoSocket
{
    public class DrawingViewModel
    {
        public ObservableCollection<Point> Points { get; set; }
        public DelegateCommand<object> SaveImageCommand { get; set; }
        public DelegateCommand<object> MouseDownCommand { get; set; }
        public DelegateCommand<object> MouseMoveCommand { get; set; }
        public DelegateCommand<object> MouseUpCommand { get; set; }
        public System.Drawing.Image Image
        {
            get;
            set;
        }

        public BitmapSource ImageBitmap
        {
            get;
            set;
        }
        public DrawingViewModel()
        {
            SaveImageCommand = new DelegateCommand<object>(SaveImage);
            MouseDownCommand = new DelegateCommand<object>(OnMouseDown);
            MouseMoveCommand = new DelegateCommand<object>(OnMouseMove);
            MouseUpCommand = new DelegateCommand<object>(OnMouseUp);

            Points = new ObservableCollection<Point>();

            //test
            Points.Add(new Point(2, 3));
            Points.Add(new Point(5, 6));
            Points.Add(new Point(20, 40));
            Points.Add(new Point(100, 50));

            System.Drawing.Image image = System.Drawing.Image.FromFile(@"E:\slide0.jpg");
            Image = image;
            string base64 = CopyImageToBase64String(image);
            Image = GetImageFromBase64String(base64);
            ImageBitmap = BitmapToImageSource((System.Drawing.Bitmap)Image);
            
        }

        private void OnMouseDown(object obj)
        {
            //Points.Clear();
        }

        private void OnMouseMove(object obj)
        {
            if (Mouse.LeftButton == MouseButtonState.Released)
                return;
            System.Windows.Controls.Canvas canvas = obj as System.Windows.Controls.Canvas;
            Points.Add(Mouse.GetPosition(canvas));
        }

        private void OnMouseUp(object obj)
        {
            //Points.Clear();
        }

        public void SaveImage(object obj)
        {
            System.Windows.Controls.Canvas canvas = obj as System.Windows.Controls.Canvas;
            CreateSaveBitmap(canvas, @"E:\out.png");
        }

        private void CreateSaveBitmap(System.Windows.Controls.Canvas canvas, string filename)
        {
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)canvas.RenderSize.Width,
                (int)canvas.RenderSize.Height, 96d, 96d, System.Windows.Media.PixelFormats.Default);
            rtb.Render(canvas);

            //var crop = new CroppedBitmap(rtb, new Int32Rect(50, 50, 250, 250));

            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(rtb));

            using (var fs = System.IO.File.OpenWrite(filename))
            {
                pngEncoder.Save(fs);
            }
        }

        //Image to base64 string
        public string CopyImageToBase64String(System.Drawing.Image theImage)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                theImage.Save(memoryStream, theImage.RawFormat);
                byte[] imageBytes = memoryStream.ToArray();
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public System.Drawing.Image GetImageFromBase64String(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }

        //convert the Bitmap to a ImageSource
        public static BitmapImage BitmapToImageSource(System.Drawing.Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }
    }
}
