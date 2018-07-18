using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lidgren.Network;


public class Server : MonoBehaviour
{
  MyNetwork MyNetwork;
  NetPeer peer;
  NetConnection connection;

  static private string appName = "gerdman";
  static private int tickRate = 128;

  void Start()
  {
    MyNetwork = GetComponent<MyNetwork>();
    NetPeerConfiguration config = new NetPeerConfiguration(appName);
    config.Port = 3000;
    config.MaximumConnections = 32;
    config.EnableMessageType(NetIncomingMessageType.ConnectionApproval);
    peer = new NetServer(config);
    peer.Start();
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      Application.Quit();
    }

    NetIncomingMessage message;
    while ((message = peer.ReadMessage()) != null)
    {
      switch (message.MessageType)
      {
        case NetIncomingMessageType.Data:
          break;
        case NetIncomingMessageType.StatusChanged:
          NetConnectionStatus status = (NetConnectionStatus)message.ReadByte();
          Debug.Log("status " + status);
          switch (status)
          {
            case NetConnectionStatus.Connected:
              Vector3 spawnPosition = Vector3.zero;
              Quaternion spawnRotation = Quaternion.identity;

              MyNetwork.SpawnPlayer(spawnPosition, spawnRotation);
              NetOutgoingMessage newMessage = peer.CreateMessage();
              newMessage.Write((byte)NetDataType.SPAWN_PLAYER);
              newMessage.Write(spawnPosition);
              newMessage.Write(spawnRotation);

              NetSendResult result = peer.SendMessage(newMessage, message.SenderConnection, NetDeliveryMethod.ReliableUnordered);
              Debug.Log("sent: " + result);
              break;
          }
          break;
        case NetIncomingMessageType.WarningMessage:
          Debug.LogWarning(message.ReadString());
          break;
        case NetIncomingMessageType.DebugMessage:
          Debug.Log(message.ReadString());
          break;
        case NetIncomingMessageType.ConnectionApproval:
          {
            // TODO: Store connections
            message.SenderConnection.Approve();
            break;
          }
        default:
          print("unhandled message with type: " + message.MessageType);
          break;
      }
    }
  }
}
