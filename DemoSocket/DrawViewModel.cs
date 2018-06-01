using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DemoSocket
{
    public class DrawViewModel
    {
        private string path = @"E:\slide0.jpg";
        public DelegateCommand<object> MouseDownCommand { get; set; }
        public DelegateCommand<object> SaveImageCommand { get; set; }
        public string Image
        {
            get
            {
                return @"E:\slide0.jpg";
            }
        }

        public DrawViewModel()
        {
            MouseDownCommand = new DelegateCommand<object>(OnMouseDown);
            SaveImageCommand = new DelegateCommand<object>(SaveImage);

            
        }

        public string ImageToBase64(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public void OnMouseDown(object obj)
        {
            //Application.Current.Dispatcher.Invoke((Action)delegate
            //{
            //    Canvas canvas = obj as Canvas;
            //    Point p = Mouse.GetPosition(canvas);
            //    Line line = new Line();
            //    line.Stroke =  
            //    line.X1 = 2;
            //    line.X1 = 2;
            //    line.X2 = 100;
            //    line.Y2 = 100;
            //    line.StrokeThickness = 4;
            //    canvas.Children.Add(line);
            //});
        }

        public void SaveImage(object obj)
        {
            Canvas canvas = obj as Canvas;
            CreateSaveBitmap(canvas, @"E:\out.png");
        }

        private void CreateSaveBitmap(Canvas canvas, string filename)
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
    }
}
