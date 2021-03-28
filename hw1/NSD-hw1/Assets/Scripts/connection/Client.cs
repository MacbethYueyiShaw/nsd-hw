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
    private byte[] data = new byte[1024];//�����һ����������
    public string message;

    public Client(Socket s)
    {
        clientSocket = s;
        //����һ���߳� ����ͻ��˵����ݽ���
        t = new Thread(ReceiveMessage);
        t.Start();
    }
    private void ReceiveMessage()
    {
        //һֱ���տͻ��˵�����
        while (true)
        {
            //�ڽ�������֮ǰ  �ж�һ��socket�����Ƿ�Ͽ�
            if (clientSocket.Poll(10, SelectMode.SelectRead))
            {
                clientSocket.Close();
                break;//����ѭ�� ��ֹ�̵߳�ִ��
            }

            int length = clientSocket.Receive(data);
            message = Encoding.UTF8.GetString(data, 0, length);
            Debug.Log(message);
        }
    }
}