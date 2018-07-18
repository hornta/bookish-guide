using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public enum SessionMode
{
  Server,
  Client
}

class Session : MonoBehaviour
{
  public SessionMode Mode = SessionMode.Client;
  public NetServer Server;
  public NetClient Client;
  static readonly string AppName = "Gerdman";

  void Awake()
  {
    DontDestroyOnLoad(gameObject);
  }

  public void StartServer()
  {
    NetPeerConfiguration configuration = new NetPeerConfiguration(AppName);
    configuration.Port = 3000;
    configuration.MaximumConnections = 32;

    Server = new NetServer(configuration);
    Server.Start();
    Mode = SessionMode.Server;
  }

  public void StartClient()
  {
    NetPeerConfiguration configuration = new NetPeerConfiguration(AppName);
    Client = new NetClient(configuration);
    Client.Connect();
    Mode = SessionMode.Client;
  }
}