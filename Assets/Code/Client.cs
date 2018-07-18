using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lidgren.Network;


public class Client : MonoBehaviour
{
  MyNetwork MyNetwork;

  NetPeer peer;
  NetConnection connection;

  static private string appName = "gerdman";

  void Start()
  {
    MyNetwork = GetComponent<MyNetwork>();
    NetPeerConfiguration config = new NetPeerConfiguration(appName);
    peer = new NetClient(config);
    peer.Start();

    NetOutgoingMessage approval = peer.CreateMessage();

    connection = peer.Connect("localhost", 3000, approval);
  }

  void Update()
  {
    NetIncomingMessage message;
    while ((message = peer.ReadMessage()) != null)
    {
      switch (message.MessageType)
      {
        case NetIncomingMessageType.Data:
          Debug.Log(message.MessageType);
          NetDataType type = (NetDataType)message.ReadByte();
          OnDataType(type, message);
          break;
        case NetIncomingMessageType.StatusChanged:
          NetConnectionStatus status = (NetConnectionStatus)message.ReadByte();
          Debug.Log("status " + status);
          break;
        case NetIncomingMessageType.DebugMessage:
          break;
        default:
          print("unhandled message with type: " + message.MessageType);
          break;
      }
    }
  }

  void OnDataType(NetDataType type, NetIncomingMessage message)
  {
    switch (type)
    {
      case NetDataType.SPAWN_PLAYER:
        Vector3 position = message.ReadVector3();
        Quaternion rotation = message.ReadQuaternion();
        MyNetwork.SpawnPlayer(position, rotation);
        break;
    }
  }
}
