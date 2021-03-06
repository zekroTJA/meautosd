﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace meautosd
{
    static class cPush
    {
        public static void send(string token, string title, string body)
        {
            try
            {
                WebRequest request = WebRequest.Create("https://api.pushbullet.com/v2/pushes");
                request.Method = "POST";
                request.Headers.Add("Authorization", "Bearer " + token);
                request.ContentType = "application/json; charset=UTF-8";
                string postData =
                    "{\"type\": \"link\", \"title\": \"" + title + "\", \"body\": \"" + body + "\", \"url\": \"\"}";
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
            }
            catch(Exception exception)
            {
                MessageBox.Show("There occoured an error while sending the push notification. Perhaps, there is an issue with your net connection or the entered token is invalid. \n\nHere you can see the exception code:\n\n" + exception, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
