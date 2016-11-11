using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography;

/*
 * 
 * 常用的流有：
 *            FileStream--文件流(操作文件)
 *            MemoryStream--内存流(使用内存作为后备存储，执行I/O速度快)
 * 用的较少的流：
 *            
  BufferedStream：使用缓冲区作为后备设备，用来增强性能的中间存储
  NetworkStream：没有后备设备，用于在网络上传输数据。
  CryptoStream：和其他流配合使用，执行加密/解密操作。

  所有流都派生Stream
                     Stream类的常用方法：
                     Seek()方法：设置流的当前位置。
                     Read()方法和ReadByte()方法，对流执行同步读取操作。Read()在流尾返回0，ReadByte()返回－1。
                     Write()方法和WriteByte()<从文件中读取一个字节，并将读取位置提升一个字节,如果为末尾返回-1>方法，对流执行同步写入操作。
                     Flush()方法：清除缓存区中的内容.
                     Close()方法：释放资源，如文件、套接字等。该方法自动执行Flush()方法。

                    属性有：
                           CanRead：当前流是否可读。
                           CanWrite：当前流是否可写。
                           CanSeek：当前流是否支持定位操作。
                           Length：流长度，long型
                           Position：流的当前位置。
 * 

 */
/// <summary>
/// 流的相关操作demo
/// </summary>
namespace StreamOperate
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 流相关操作demo

            //文件转化为文件流
            FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory+"30.jpg",FileMode.Open);

            //文件流转byte[]
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer,0, (int)fs.Length);
            fs.Close();
            //fs.ReadByte()//从文件中读取一个字节，并将读取位置提升一个字节,如果为末尾返回-1

            //byte[]转内存流
            MemoryStream ms = new MemoryStream(buffer);

            //内存流转byte[]
            byte[] bt=ms.ToArray();//只有内存流可以直接转byte[];



            BufferedStream bs = new BufferedStream(ms);//缓存流

            

            //流转图片
            Image img =Bitmap.FromStream(ms);
            //ImageFormat.Jpeg保存图片的类型
            img.Save("保存路径", ImageFormat.Jpeg);

            
            //注意Http响应流 不能直接使用操作,需要转化成其他流或者字节byte[],进行操作.





            #endregion


            Console.ReadLine();
        }
    }

    
}
