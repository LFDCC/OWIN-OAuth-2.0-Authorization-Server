using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Auth.Infrastructure.Tools.Images
{
    /// <summary>
    /// 缩率图操作类
    /// </summary>
    public class ThumbnailImage
    {
        /// <summary>
        /// 缩略图配置类
        /// </summary>
        public class ThumbnailImageOptions
        {
            /// <summary>
            /// 目标文件的路径
            /// </summary>
            public string TargetFileName { get; set; }

            /// <summary>
            /// 宽度
            /// </summary>
            public int Width { get; set; }

            /// <summary>
            /// 高度
            /// </summary>
            public int Height { get; set; }
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="srcFileName">原始文件</param>
        /// <param name="targetFileName">目标文件，不能和原始文件的路径相同</param>
        /// <param name="width">图宽度</param>
        /// <param name="heigth">图高度</param>
        public static bool SaveThumbnailImage(string srcFileName, string targetFileName, int width, int heigth)
        {
            if (srcFileName == null)
            {
                throw new ArgumentNullException("srcFileName");
            }
            if (targetFileName == null)
            {
                throw new ArgumentNullException("targetFileName");
            }
            return SaveThumbnailImage(srcFileName, new ThumbnailImageOptions[]
            {
                new ThumbnailImageOptions(){ TargetFileName = targetFileName, Width = width, Height = heigth }
            });
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="srcFileName">图片源文件的路径</param>
        /// <param name="optionItems">一个或多个配置</param>
        /// <returns></returns>
        public static bool SaveThumbnailImage(string srcFileName, IEnumerable<ThumbnailImageOptions> optionItems)
        {
            if (srcFileName == null)
            {
                throw new ArgumentNullException("srcFileName");
            }
            if (optionItems == null)
            {
                throw new ArgumentNullException("items");
            }
            if (!optionItems.Any())
            {
                return true;
            }
            using (FileStream fs = new FileStream(srcFileName, FileMode.Open))
            {
                Image img = Image.FromStream(fs);
                try
                {
                    foreach (ThumbnailImageOptions item in optionItems)
                    {
                        Image newThumImg = img.GetThumbnailImage(item.Width, item.Height, null, IntPtr.Zero);
                        newThumImg.Save(item.TargetFileName);
                        newThumImg.Dispose();
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    img.Dispose();
                }
            }
        }
    }
}