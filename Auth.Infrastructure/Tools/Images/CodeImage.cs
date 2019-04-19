using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.QrCode.Internal;

namespace Auth.Infrastructure.Tools.Images
{
    /// <summary>
    /// 二维码、条形码操作类
    /// </summary>
    public class CodeImage
    {
        /// <summary>
        /// 生成二维码,输出Bitmap对象(Bitmap map =CodeImage.QrCode("123"))
        /// </summary>
        /// <param name="content">二维码内容</param>
        public static Bitmap QrCode(string content, int Width = 500, int Height = 500)
        {
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            QrCodeEncodingOptions options = new QrCodeEncodingOptions();
            options.DisableECI = true;
            //设置内容编码
            options.CharacterSet = "UTF-8";
            //设置二维码的宽度和高度
            options.Width = Width;
            options.Height = Height;
            //设置二维码的边距,单位不是固定像素
            options.Margin = 1;
            writer.Options = options;

            Bitmap map = writer.Write(content);
            return map;
        }

        /// <summary>
        /// 生成二维码,保存成图片(CodeImage.QrCode(@"F:\qrcode.png", "123"))
        /// </summary>
        /// <param name="filename">生成保存的文件绝对路径</param>
        /// <param name="content">二维码内容</param>
        public static void QrCode(string filename, string content, int Width = 500, int Height = 500)
        {
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            QrCodeEncodingOptions options = new QrCodeEncodingOptions();
            options.DisableECI = true;
            //设置内容编码
            options.CharacterSet = "UTF-8";
            //设置二维码的宽度和高度
            options.Width = Width;
            options.Height = Height;
            //设置二维码的边距,单位不是固定像素
            options.Margin = 1;
            writer.Options = options;

            Bitmap map = writer.Write(content);
            map.Save(filename, ImageFormat.Png);
            map.Dispose();
        }

        /// <summary>
        /// 生成条形码，输出Bitmap对象(Bitmap map =CodeImage.BarCode("456"))
        /// </summary>
        /// <param name="content">条形码内容</param>
        public static Bitmap BarCode(string content, int Width = 150, int Height = 50, int Margin = 2)
        {
            BarcodeWriter writer = new BarcodeWriter();
            //使用ITF 格式，不能被现在常用的支付宝、微信扫出来
            //如果想生成可识别的可以使用 CODE_128 格式
            //writer.Format = BarcodeFormat.ITF;
            writer.Format = BarcodeFormat.CODE_128;
            EncodingOptions options = new EncodingOptions()
            {
                Width = Width,
                Height = Height,
                Margin = Margin
            };
            writer.Options = options;
            Bitmap map = writer.Write(content);
            return map;
        }

        /// <summary>
        /// 生成条形码，保存成图片(CodeImage.BarCode(@"F:\brcode.png", "456"))
        /// </summary>
        /// <param name="filename">生成保存的文件绝对路径</param>
        /// <param name="content">条形码内容</param>
        public static void BarCode(string filename, string content, int Width = 150, int Height = 50, int Margin = 2)
        {
            BarcodeWriter writer = new BarcodeWriter();
            //使用ITF 格式，不能被现在常用的支付宝、微信扫出来
            //如果想生成可识别的可以使用 CODE_128 格式
            //writer.Format = BarcodeFormat.ITF;
            writer.Format = BarcodeFormat.CODE_128;
            EncodingOptions options = new EncodingOptions()
            {
                Width = Width,
                Height = Height,
                Margin = Margin
            };
            writer.Options = options;
            Bitmap map = writer.Write(content);
            map.Save(filename, ImageFormat.Png);
            map.Dispose();
        }

        /// <summary>
        /// 读取二维码、条形码(CodeImage.ReadCodeImage(@"F:\qrcode.png"))
        /// 读取失败，返回空字符串
        /// </summary>
        /// <param name="filename">指定二维码、条形码图片位置</param>
        public static string ReadCodeImage(string filename)
        {
            BarcodeReader reader = new BarcodeReader();
            reader.Options.CharacterSet = "UTF-8";
            Bitmap map = new Bitmap(filename);
            Result result = reader.Decode(map);
            return result?.Text;
        }

        /// <summary>
        /// 生成带Logo的二维码(CodeImage.QrCodeWithLogo(@"F:\logo.png", @"f:\qrlogo.png", "789"))
        /// </summary>
        /// <param name="logo_filename">logo图片的绝对路径</param>
        /// <param name="filename">二维码的绝对路径</param>
        /// <param name="content">二维码的内容</param>
        public static void QrCodeWithLogo(string logo_filename, string filename, string content, int Width = 300, int Height = 300)
        {
            //Logo 图片
            Bitmap logo = new Bitmap(logo_filename);
            //构造二维码写码器
            MultiFormatWriter writer = new MultiFormatWriter();
            Dictionary<EncodeHintType, object> hint = new Dictionary<EncodeHintType, object>();
            hint.Add(EncodeHintType.CHARACTER_SET, "UTF-8");
            hint.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);

            //生成二维码
            BitMatrix bm = writer.encode(content, BarcodeFormat.QR_CODE, Width, Height, hint);
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            Bitmap map = barcodeWriter.Write(bm);

            //获取二维码实际尺寸（去掉二维码两边空白后的实际尺寸）
            int[] rectangle = bm.getEnclosingRectangle();

            //计算插入图片的大小和位置
            int middleW = Math.Min((int)(rectangle[2] / 3.5), logo.Width);
            int middleH = Math.Min((int)(rectangle[3] / 3.5), logo.Height);
            int middleL = (map.Width - middleW) / 2;
            int middleT = (map.Height - middleH) / 2;

            //将img转换成bmp格式，否则后面无法创建Graphics对象
            Bitmap bmpimg = new Bitmap(map.Width, map.Height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bmpimg))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.DrawImage(map, 0, 0);
            }
            //将二维码插入图片
            Graphics myGraphic = Graphics.FromImage(bmpimg);
            //白底
            myGraphic.FillRectangle(Brushes.White, middleL, middleT, middleW, middleH);
            myGraphic.DrawImage(logo, middleL, middleT, middleW, middleH);

            //保存成图片
            bmpimg.Save(filename, ImageFormat.Png);
            bmpimg.Dispose();
        }

        /// <summary>
        /// 生成带Logo的二维码 输出Bitmap对象(Bitmap map=CodeImage.QrCodeWithLogo(@"F:\logo.png","789"))
        /// </summary>
        /// <param name="logo_filename">logo图片的绝对路径</param>
        /// <param name="content">二维码的内容</param>
        public static Bitmap QrCodeWithLogo(string logo_filename, string content, int Width = 300, int Height = 300)
        {
            //Logo 图片
            Bitmap logo = new Bitmap(logo_filename);
            //构造二维码写码器
            MultiFormatWriter writer = new MultiFormatWriter();
            Dictionary<EncodeHintType, object> hint = new Dictionary<EncodeHintType, object>();
            hint.Add(EncodeHintType.CHARACTER_SET, "UTF-8");
            hint.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);

            //生成二维码
            BitMatrix bm = writer.encode(content, BarcodeFormat.QR_CODE, Width, Height, hint);
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            Bitmap map = barcodeWriter.Write(bm);

            //获取二维码实际尺寸（去掉二维码两边空白后的实际尺寸）
            int[] rectangle = bm.getEnclosingRectangle();

            //计算插入图片的大小和位置
            int middleW = Math.Min((int)(rectangle[2] / 3.5), logo.Width);
            int middleH = Math.Min((int)(rectangle[3] / 3.5), logo.Height);
            int middleL = (map.Width - middleW) / 2;
            int middleT = (map.Height - middleH) / 2;

            //将img转换成bmp格式，否则后面无法创建Graphics对象
            Bitmap bmpimg = new Bitmap(map.Width, map.Height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bmpimg))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.DrawImage(map, 0, 0);
            }
            //将二维码插入图片
            Graphics myGraphic = Graphics.FromImage(bmpimg);
            //白底
            myGraphic.FillRectangle(Brushes.White, middleL, middleT, middleW, middleH);
            myGraphic.DrawImage(logo, middleL, middleT, middleW, middleH);

            return bmpimg;
        }
    }
}