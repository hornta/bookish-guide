using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lidgren.Network;


public class MyNetwork : MonoBehaviour
{
  public GameObject Character;
  public GameObject Player;
  public Camera Camera;
  Server server;
  Client client;

  void Start()
  {
    server = GetComponent<Server>();
    client = GetComponent<Client>();
    if (GameStatics.isServer)
    {
      server.enabled = true;
    }
    else
    {
      client.enabled = true;
    }
  }

  public void SpawnPlayer(Vector3 position, Quaternion rotation)
  {
    if (Player == null)
    {
      Debug.LogError("Missing Player to instantiate");
      return;
    }

    if (Character == null)
    {
      Debug.LogError("Missing Character to instantiate");
      return;
    }

    GameObject playerObject = Instantiate(Player);
    ExamplePlayer examplePlayer = playerObject.GetComponent<ExamplePlayer>();

    GameObject characterObject = Instantiate(Character, position, rotation);
    ExampleCharacterController exampleCharacterController = characterObject.GetComponent<ExampleCharacterController>();

    examplePlayer.Character = exampleCharacterController;
    examplePlayer.CharacterCamera = Camera.main.GetComponent<ExampleCharacterCamera>();
  }
}
