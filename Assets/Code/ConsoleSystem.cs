using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(ServerConsole))]
public class ConsoleSystem : MonoBehaviour
{

  // public Server_DataPersistence dataPersister;

  void OnEnable()
  {
    // Debug.Log(“ConsoleSystem was enabled”);
    //EnsureDataPersisterLoaded();
  }

  void OnLevelWasLoaded(int level)
  {
    // Debug.Log(“Scene was changed to Scene: ” +level);
    EnsureDataPersisterLoaded();
  }

  public void Run(string text)
  {
    // EnsureDataPersisterLoaded();

    // char[] whitespace = new char[] { ‘ ‘ };
    // string[] cmds = text.Split(whitespace);

    // if (cmds.Length < 1)
    //   return;

    // switch (cmds[0].ToLowerInvariant())
    // {
    //   case "help":
    //     PrintHelp();
    //     break;
    //   case "saves":
    //     PrintSaves();
    //     break;
    //   case "save":
    //     SaveServerState();
    //     break;
    //   case "loadscene":
    //     LoadScene(cmds);
    //     break;
    //   case "shutdown":
    //     //SaveServerState();
    //     Application.Quit();
    //     break;
    //   case "lastsavetime":
    //     PrintLastSaveTime();
    //     Application.Quit();
    //     break;
    //   default:
    //     PrintHelp();
    //     break;
    // }
  }

  void PrintHelp()
  {
    Debug.Log("The following commmands are available to you:");
    Debug.Log("\tHelp – Displays available commands");
    Debug.Log("\tSaves – Displays number of saves made on current data file");
    Debug.Log("\tSave – Saves the current state of the server to a local file");
    Debug.Log("\tLoadscene [sceneNumber] – Will load the scene specified");
    Debug.Log("\tShutdown – Stops the server process");
    Debug.Log("\tLastSaveTime – Displays the date and time of the last save.");
  }

  bool EnsureDataPersisterLoaded()
  {
    // if (dataPersister != null)
    //   return true;
    // GameObject dataPersisterObj = GameObject.Find("DataPersister");
    // if (dataPersisterObj != null)
    // {
    //   dataPersister = dataPersisterObj.GetComponent();
    //   if (dataPersister != null)
    //     return true;
    // }
    // else
    // {
    //   Debug.Log(“Could not find DataPersister gameObject – ConsoleSystem: EnsurePersisterLoaded()”);
    // }
    // Debug.LogWarning(“Unable to load DataPersister.Some commands may not function properly.”);
    // return false;
    return true;
  }

  void PrintSaves()
  {
    // Debug.Log(“There have been ” +dataPersister.GetSaves() + ” saves made to the current world.”);
  }

  void LoadScene(string[] cmds)
  {
    // int level;
    // if (Int32.TryParse(cmds[1], out level))
    // {
    //   if (level != Scenes.LANDING)
    //   {
    //     Application.LoadLevel(level);
    //   }
    //   else
    //   {
    //     Debug.Log(“Cannot load landing scene.Will cause issues with the network manager and server console.”);
    //   }
    // }
  }

  void SaveServerState()
  {
    // dataPersister.Save();
    // Debug.Log(“State of the Server has been saved to ” +dataPersister.GetSaveFilePath());
  }

  void PrintLastSaveTime()
  {
    // Debug.Log(“Last successful save on: ” +dataPersister.GetLastSaveDateTime());
  }
}