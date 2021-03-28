using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Text;

public class Client
{

    private Socket clientSocket;
    private Thread t;
    private byte[] data = new byte[1024];//这个是一个数据容器
    public string message;

    public Client(Socket s)
    {
        clientSocket = s;
        //启动一个线程 处理客户端的数据接收
        t = new Thread(ReceiveMessage);
        t.Start();
    }
    private void ReceiveMessage()
    {
        //一直接收客户端的数据
        while (true)
        {
            //在接收数据之前  判断一下socket连接是否断开
            if (clientSocket.Poll(10, SelectMode.SelectRead))
            {
                clientSocket.Close();
                break;//跳出循环 终止线程的执行
            }

            int length = clientSocket.Receive(data);
            message = Encoding.UTF8.GetString(data, 0, length);
            Debug.Log(message);
        }
    }
}