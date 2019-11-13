#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：RabbitPlatform.Core.File
* 项目描述 ：
* 类 名 称 ：FileDownHelper
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：RabbitPlatform.Core.File
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/11/9 10:32:24
* 更新时间 ：2019/11/9 10:32:24
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting.Internal;
namespace RabbitPlatform.Core
{
    public class FileDownHelper
    {
        public FileDownHelper()
        { }
        public static string FileNameExtension(string FileName)
        {
            return Path.GetExtension(MapPathFile(FileName));
        }
        public static string MapPathFile(string FileName)
        {
            return MyServiceProvider.ServiceProvider.GetRequiredService<HostingEnvironment>().WebRootPath + "\\" + FileName;
            //return HttpContext.Current.Server.MapPath(FileName);
           // return "";
        }
        public static bool FileExists(string FileName)
        {
            string destFileName = FileName;
            if (System.IO.File.Exists(destFileName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void DownLoadold(string FileName, string name)
        {
            string destFileName = FileName;
            if (System.IO.File.Exists(destFileName))
            {
                //FileInfo fi = new FileInfo(destFileName);
                //HttpContext.Current.Response.Clear();
                //HttpContext.Current.Response.Headers.Clear();
                //HttpContext.Current.Response.Buffer = false;
                //HttpContext.Current.Response.Headers.Add("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(name, System.Text.Encoding.UTF8));
                //HttpContext.Current.Response.Headers.Add("Content-Length", fi.Length.ToString());
                //HttpContext.Current.Response.ContentType = "application/octet-stream";
                //HttpContext.Current.Response.WriteFile(destFileName);
                //HttpContext.Current.Response.Flush();
                //HttpContext.Current.Response.End();
            }
        }
        public static void DownLoad(string FileName)
        {
            //string filePath = MapPathFile(FileName);
            //long chunkSize = 204800;             //指定块大小 
            //byte[] buffer = new byte[chunkSize]; //建立一个200K的缓冲区 
            //long dataToRead = 0;                 //已读的字节数   
            //FileStream stream = null;
            //try
            //{
            //    //打开文件   
            //    stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            //    dataToRead = stream.Length;

            //    //添加Http头   
            //    HttpContext.Current.Response.ContentType = "application/octet-stream";
            //    HttpContext.Current.Response.Headers.Add("Content-Disposition", "attachement;filename=" + HttpUtility.UrlEncode(Path.GetFileName(filePath)));
            //    HttpContext.Current.Response.Headers.Add("Content-Length", dataToRead.ToString());

            //    while (dataToRead > 0)
            //    {
            //        if (HttpContext.Current.Response.IsClientConnected)
            //        {
            //            int length = stream.Read(buffer, 0, Convert.ToInt32(chunkSize));
            //            HttpContext.Current.Response.OutputStream.Write(buffer, 0, length);
            //            HttpContext.Current.Response.Flush();
            //            HttpContext.Current.Response.Clear();
            //            dataToRead -= length;
            //        }
            //        else
            //        {
            //            dataToRead = -1; //防止client失去连接 
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    HttpContext.Current.Response.Write("Error:" + ex.Message);
            //}
            //finally
            //{
            //    if (stream != null) stream.Close();
            //    HttpContext.Current.Response.Close();
            //}
        }
        //public static bool ResponseFile(HttpContext.Request _Request, HttpResponse _Response, string _fileName, string _fullPath, long _speed)
        //{
        //    try
        //    {
        //        FileStream myFile = new FileStream(_fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        //        BinaryReader br = new BinaryReader(myFile);
        //        try
        //        {
        //            _Response.AddHeader("Accept-Ranges", "bytes");
        //            _Response.Buffer = false;

        //            long fileLength = myFile.Length;
        //            long startBytes = 0;
        //            int pack = 10240;  //10K bytes
        //            int sleep = (int)Math.Floor((double)(1000 * pack / _speed)) + 1;

        //            if (_Request.Headers["Range"] != null)
        //            {
        //                _Response.StatusCode = 206;
        //                string[] range = _Request.Headers["Range"].Split(new char[] { '=', '-' });
        //                startBytes = Convert.ToInt64(range[1]);
        //            }
        //            _Response.AddHeader("Content-Length", (fileLength - startBytes).ToString());
        //            if (startBytes != 0)
        //            {
        //                _Response.AddHeader("Content-Range", string.Format(" bytes {0}-{1}/{2}", startBytes, fileLength - 1, fileLength));
        //            }

        //            _Response.AddHeader("Connection", "Keep-Alive");
        //            _Response.ContentType = "application/octet-stream";
        //            _Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(_fileName, System.Text.Encoding.UTF8));

        //            br.BaseStream.Seek(startBytes, SeekOrigin.Begin);
        //            int maxCount = (int)Math.Floor((double)((fileLength - startBytes) / pack)) + 1;

        //            for (int i = 0; i < maxCount; i++)
        //            {
        //                if (_Response.IsClientConnected)
        //                {
        //                    _Response.BinaryWrite(br.ReadBytes(pack));
        //                    Thread.Sleep(sleep);
        //                }
        //                else
        //                {
        //                    i = maxCount;
        //                }
        //            }
        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //        finally
        //        {
        //            br.Close();
        //            myFile.Close();
        //        }
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}
