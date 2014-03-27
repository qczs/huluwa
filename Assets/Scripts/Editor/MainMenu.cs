using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

static public class  MainMenu  {

	//得到工程中所有场景名称
	static string[] SCENES = FindEnabledEditorScenes();

	[MenuItem("发布/", false, 1)]
	static void Breaker () { }
	[MenuItem("发布/资源/UI/login", false, 2)]
	static void MakeBreaker () {
		UIAUTOAtlasMaker.MakeAtlas("images/login");
	}

	[MenuItem("发布/资源/UI/main", false, 3)]
	static void MakemainBreaker () {
		UIAUTOAtlasMaker.MakeAtlas("images/main");
	}

	[MenuItem("发布/Android/android", false, 4)]
	static void buildAndroid () {
		BulidTarget("Android","hlw");
	}
	[MenuItem("发布/IOS/iOS", false, 5)]
	static void buildiOS () {
		BulidTarget("IOS","hlw");
	}
	[MenuItem("发布/IOS/iPhone", false, 6)]
	static void buildiPhone () {
		BulidTarget("IOS","hlw");
	}

	static void BulidTarget(string target,string name)
	{
		string app_name = name;
		string target_dir = Application.dataPath + "/TargetAndroid";
		string target_name = app_name + ".apk";
		BuildTargetGroup targetGroup = BuildTargetGroup.Android;
		BuildTarget buildTarget = BuildTarget.Android;
		string applicationPath = 	Application.dataPath.Replace("/Assets","");
		
		if(target == "Android")
		{
			target_dir = applicationPath + "/TargetAndroid";
			target_name = app_name + ".apk";
			targetGroup = BuildTargetGroup.Android;
		}else if(target == "IOS")
		{
			target_dir = applicationPath + "/TargetIOS";
			target_name = app_name;
			targetGroup = BuildTargetGroup.iPhone;
			buildTarget = BuildTarget.iPhone;
		}
		

		if(Directory.Exists(target_dir)) 
		{
			if (File.Exists(target_name))
			{
				File.Delete(target_name);
			}
		}else
		{
			Directory.CreateDirectory(target_dir); 
		}
			PlayerSettings.bundleIdentifier = "com.game.huluwa";
			PlayerSettings.bundleVersion = "v0.0.1";
			PlayerSettings.SetScriptingDefineSymbolsForGroup(targetGroup,"HLW");  

		

		GenericBuild(SCENES, target_dir + "/" + target_name, buildTarget,BuildOptions.None);
		
	}
	
	private static string[] FindEnabledEditorScenes() {
		List<string> EditorScenes = new List<string>();
		foreach(EditorBuildSettingsScene scene in EditorBuildSettings.scenes) {
			if (!scene.enabled) continue;
			EditorScenes.Add(scene.path);
		}
		return EditorScenes.ToArray();
	}
	
	static void GenericBuild(string[] scenes, string target_dir, BuildTarget build_target, BuildOptions build_options)
	{   
		EditorUserBuildSettings.SwitchActiveBuildTarget(build_target);
		string res = BuildPipeline.BuildPlayer(scenes,target_dir,build_target,build_options);
		
		if (res.Length > 0) {
			throw new Exception("BuildPlayer failure: " + res);
		}
	}
}
