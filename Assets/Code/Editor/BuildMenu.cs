using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;
using System.Diagnostics;

public class MenuItems
{
  [MenuItem("Build/Build and Run Server _F1")]
  private static void BuildServer()
  {
    PlayerPrefs.DeleteAll();
    PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, "SERVER");
    PlayerSettings.SplashScreen.show = false;
    PlayerSettings.fullScreenMode = FullScreenMode.Windowed;
    PlayerSettings.defaultScreenWidth = 1024;
    PlayerSettings.defaultScreenHeight = 768;
    PlayerSettings.defaultIsNativeResolution = false;
    PlayerSettings.displayResolutionDialog = ResolutionDialogSetting.Disabled;

    BuildPlayerOptions options = new BuildPlayerOptions();
    options.targetGroup = BuildTargetGroup.Standalone;
    options.target = BuildTarget.StandaloneWindows64;
    options.locationPathName = "Server.exe";

    BuildReport report = BuildPipeline.BuildPlayer(options);
    UnityEngine.Debug.Log(report.summary);

    ProcessStartInfo startInfo = new ProcessStartInfo();
    startInfo.FileName = @"Server.exe";
    startInfo.Arguments = @"";
    Process.Start(startInfo);

    PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, "");
    PlayerSettings.SplashScreen.show = true;
    PlayerSettings.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
    PlayerSettings.defaultIsNativeResolution = true;
    PlayerSettings.displayResolutionDialog = ResolutionDialogSetting.Enabled;
  }

  [MenuItem("Build/Run Server _F2")]
  private static void RunServer()
  {
    ProcessStartInfo startInfo = new ProcessStartInfo();
    startInfo.FileName = @"Server.exe";
    startInfo.Arguments = @"";
    Process.Start(startInfo);
  }
}