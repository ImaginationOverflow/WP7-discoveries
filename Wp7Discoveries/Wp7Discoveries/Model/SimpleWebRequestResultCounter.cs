using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Wp7Discoveries.Model
{
    public class SimpleWebRequestResultCounter : IWebRequestResultCounter
    {
        public void GetCountFor(Uri uri, Action<int> callback)
        {
            var request = WebRequest.CreateHttp(uri);
            request.BeginGetResponse(ar =>
            {
                var response = request.EndGetResponse(ar);
                var count =
                    new StreamReader(response.GetResponseStream()).ReadToEnd().Length;
                callback(count);
            }, null);
        }
    }
}
