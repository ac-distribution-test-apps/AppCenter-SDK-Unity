﻿// Copyright (c) Microsoft Corporation. All rights reserved.
//
// Licensed under the MIT license.

using System.IO;
using UnityEditor;
using UnityEngine;

// This class provides methods to build the puppet app in many different configurations.
// They are meant to be invoked from the build scripts in this repository.
public class BuildPuppet
{
    private static readonly string BuildFolder = "PuppetBuilds";

    public static void BuildPuppetSceneAndroidMono()
    {
        CreateGoogleServicesJsonIfNotPresent();
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.Mono2x);
        BuildPuppetScene(BuildTarget.Android, "AndroidMonoBuild");
    }

    public static void BuildPuppetSceneAndroidIl2CPP()
    {
        CreateGoogleServicesJsonIfNotPresent();
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);
        BuildPuppetScene(BuildTarget.Android, "AndroidIL2CPPBuild");
    }

    public static void BuildPuppetSceneIosMono()
    {
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.iOS, ScriptingImplementation.Mono2x);
        BuildPuppetScene(BuildTarget.iOS, "iOSMonoBuild");
    }

    public static void BuildPuppetSceneIosIl2CPP()
    {
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.iOS, ScriptingImplementation.IL2CPP);
        BuildPuppetScene(BuildTarget.iOS, "iOSIL2CPPBuild");
    }

    public static void BuildPuppetSceneWsaNetXaml()
    {
        EditorUserBuildSettings.wsaUWPBuildType = WSAUWPBuildType.XAML;
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.WSA, ScriptingImplementation.WinRTDotNET);
        BuildPuppetScene(BuildTarget.WSAPlayer, "WSANetBuildXaml");
    }

    public static void BuildPuppetSceneWsaIl2CPPXaml()
    {
        EditorUserBuildSettings.wsaUWPBuildType = WSAUWPBuildType.XAML;
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.WSA, ScriptingImplementation.IL2CPP);
        BuildPuppetScene(BuildTarget.WSAPlayer, "WSAIL2CPPBuildXaml");
    }
    
    public static void BuildPuppetSceneWsaNetD3D()
    {
        EditorUserBuildSettings.wsaUWPBuildType = WSAUWPBuildType.D3D;
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.WSA, ScriptingImplementation.WinRTDotNET);
        BuildPuppetScene(BuildTarget.WSAPlayer, "WSANetBuildD3D");
    }

    public static void BuildPuppetSceneWsaIl2CPPD3D()
    {
        EditorUserBuildSettings.wsaUWPBuildType = WSAUWPBuildType.D3D;
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.WSA, ScriptingImplementation.IL2CPP);
        BuildPuppetScene(BuildTarget.WSAPlayer, "WSAIL2CPPBuildD3D");
    }

    private static void BuildPuppetScene(BuildTarget target, string outputPath)
    {
        string[] puppetScene = { "Assets/Puppet/PuppetScene.unity" };
        var options = new BuildPlayerOptions
        {
            scenes = puppetScene,
            options = BuildOptions.StrictMode,
            locationPathName = Path.Combine(BuildFolder, outputPath),
            target = target
        };
        BuildPipeline.BuildPlayer(options);
    }

    // Detects whether there exists a "google-services.json" file, and if not,
    // copies the "google-services-placeholder.json" and imports it as a
    // "google-services.json" file. The resulting file contains only
    // placeholders for keys, not actual keys.
    private static void CreateGoogleServicesJsonIfNotPresent()
    {
        var actualFile =  "Assets/google-services.json";
        if (File.Exists(actualFile))
        {
            return;
        }
        var placeholderFile =  "Assets/google-services-placeholder.json";
        if (!File.Exists(placeholderFile))
        {
            Debug.LogError("Could not find google services placeholder.");
        }
        File.Copy(placeholderFile, actualFile);
        AssetDatabase.ImportAsset(actualFile, ImportAssetOptions.Default);
    }
}
