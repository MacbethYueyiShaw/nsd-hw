using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class Client : MonoBehaviour
{
    private bool firstConnected;
    // Start is called before the first frame update
    //1、创建socket
    Socket tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    void Start()
    {
        //2、发起连接的请求
        IPAddress ipaddress = IPAddress.Parse("59.78.38.54");//可以把一个字符串的ip地址转化成一个IPaddress的对象
        EndPoint point = new IPEndPoint(ipaddress, 8899);
        tcpClient.Connect(point);//通过ip：端口号 定位一个要连接的服务器端  
        firstConnected = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (firstConnected)
        {
            string message2 = "我连进来啦！";//用户输入 给客户端的信息
            tcpClient.Send(Encoding.UTF8.GetBytes(message2));//把字符串转化成字节数组，然后发送到服务器端
            Debug.Log(message2);
            firstConnected = false;
        }
        tcpClient.Send(Encoding.UTF8.GetBytes(Time.time.ToString()));
    }
}