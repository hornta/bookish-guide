using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStatics
{
#if SERVER
  public static bool isServer = true;
#else
  public static bool isServer = false;
#endif
}
