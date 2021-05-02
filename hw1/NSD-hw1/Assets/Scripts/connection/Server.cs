using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Net.Sockets;
using System.Net;
using System.Collections.Generic;
using System.Threading;

public class Server : MonoBehaviour
{
    static List<Client> clientList = new List<Client>();//建立一个集合
    Socket tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    Thread 线程;
    public Text message;
    // Use this for initialization
    void Start()
    {
        tcpServer.Bind(new IPEndPoint(IPAddress.Parse("59.78.38.54"), 8899));
        Debug.Log("我的 Unity 服务端开始启动 ");
        message.text = "启动！";
        tcpServer.Listen(100);
        线程 = new Thread(Connection);
        线程.Start();
    }


    public void Connection()
    {
        while (true)
        {
            Socket clienttSocket = tcpServer.Accept(); //暂停线程直到用户连接
            Client client = new Client(clienttSocket);//把与每个客户端的逻辑放到client的对象里
            clientList.Add(client);
        }
    }
}