using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lidgren.Network;
using UnityEngine;

public static class NetMessageExtensions
{
  public static void Write(this NetBuffer message, Vector3 vector)
  {
    message.Write(vector.x);
    message.Write(vector.y);
    message.Write(vector.z);
  }

  public static Vector3 ReadVector3(this NetBuffer message)
  {
    return new Vector3(message.ReadFloat(), message.ReadFloat(), message.ReadFloat());
  }

  public static void Write(this NetBuffer message, Quaternion quaternion)
  {
    message.Write(quaternion.x);
    message.Write(quaternion.y);
    message.Write(quaternion.z);
    message.Write(quaternion.w);
  }

  public static Quaternion ReadQuaternion(this NetBuffer message)
  {
    return new Quaternion(message.ReadFloat(), message.ReadFloat(), message.ReadFloat(), message.ReadFloat());
  }
}

