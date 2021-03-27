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
    //1������socket
    Socket tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    void Start()
    {
        //2���������ӵ�����
        IPAddress ipaddress = IPAddress.Parse("59.78.38.54");//���԰�һ���ַ�����ip��ַת����һ��IPaddress�Ķ���
        EndPoint point = new IPEndPoint(ipaddress, 8899);
        tcpClient.Connect(point);//ͨ��ip���˿ں� ��λһ��Ҫ���ӵķ�������  
        firstConnected = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (firstConnected)
        {
            string message2 = "������������";//�û����� ���ͻ��˵���Ϣ
            tcpClient.Send(Encoding.UTF8.GetBytes(message2));//���ַ���ת�����ֽ����飬Ȼ���͵���������
            Debug.Log(message2);
            firstConnected = false;
        }
        tcpClient.Send(Encoding.UTF8.GetBytes(Time.time.ToString()));
    }
}