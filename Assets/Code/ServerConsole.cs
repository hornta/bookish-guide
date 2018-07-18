using UnityEngine;
using System;

public class ServerConsole : MonoBehaviour
{
  ConsoleSystem system;
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN

  Windows.ConsoleWindow console = new Windows.ConsoleWindow();
  Windows.ConsoleInput input = new Windows.ConsoleInput();

  string strInput;

  //
  // Create console window, register callbacks
  //
  void Awake()
  {
#if SERVER
    DontDestroyOnLoad(gameObject);
    system = GetComponent<ConsoleSystem>();

    console.Initialize();
    console.SetTitle("Server");

    input.OnInputText += OnInputText;

    Application.RegisterLogCallback(HandleLog);
#endif
  }

  //
  // Text has been entered into the console
  // Run it as a console command
  //
  void OnInputText(string obj)
  {
    system.Run(obj);
  }

  //
  // Debug.Log* callback
  //
  void HandleLog(string message, string stackTrace, LogType type)
  {
    if (type == LogType.Warning)
      System.Console.ForegroundColor = ConsoleColor.Yellow;
    else if (type == LogType.Error)
      System.Console.ForegroundColor = ConsoleColor.Red;
    else
      System.Console.ForegroundColor = ConsoleColor.White;

    // We're half way through typing something, so clear this line ..
    if (Console.CursorLeft != 0)
      input.ClearLine();

    System.Console.WriteLine(message);

    // If we were typing something re-add it.
    input.RedrawInputLine();
  }

  //
  // Update the input every frame
  // This gets new key input and calls the OnInputText callback
  //
  void Update()
  {
#if SERVER
    input.Update();
#endif
  }

  //
  // It's important to call console.ShutDown in OnDestroy
  // because compiling will error out in the editor if you don't
  // because we redirected output. This sets it back to normal.
  //
  void OnDestroy()
  {
#if SERVER
    console.Shutdown();
#endif
  }

#endif
}