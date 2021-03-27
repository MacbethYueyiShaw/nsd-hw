using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Net.Sockets;
using System.Net;
using System.Collections.Generic;
using System.Threading;

public class Server : MonoBehaviour
{
    static List<Client> clientList = new List<Client>();//����һ������
    Socket tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    Thread t;
    public Text message;
    // Use this for initialization
    void Start()
    {
        tcpServer.Bind(new IPEndPoint(IPAddress.Parse("59.78.38.54"), 8899));
        Debug.Log("������������");
        message.text = "server start.";
        tcpServer.Listen(100);
        t = new Thread(Connection);
        t.Start();
    }


    public void Connection()
    {
        while (true)
        {
            Socket clienttSocket = tcpServer.Accept(); //��ͣ�߳�ֱ���û�����
            Client client = new Client(clienttSocket);//����ÿ���ͻ��˵��߼��ŵ�client�Ķ�����
            clientList.Add(client);
        }
    }
}