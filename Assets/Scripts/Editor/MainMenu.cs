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

	[MenuItem("发布/资源/UI/mail", false, 4)]
	static void MakemailBreaker () {
		UIAUTOAtlasMaker.MakeAtlas("images/mail");
	}

	[MenuItem("发布/资源/UI/match", false, 5)]
	static void MakematchBreaker () {
		UIAUTOAtlasMaker.MakeAtlas("images/match");
	}

	[MenuItem("发布/资源/UI/menu", false, 6)]
	static void MakemenuBreaker () {
		UIAUTOAtlasMaker.MakeAtlas("images/menu");
	}

	[MenuItem("发布/资源/UI/new_user", false, 7)]
	static void Makenew_userBreaker () {
		UIAUTOAtlasMaker.MakeAtlas("images/new_user");
	}

	[MenuItem("发布/资源/UI/online", false, 8)]
	static void MakeonlineBreaker () {
		UIAUTOAtlasMaker.MakeAtlas("images/online");
	}

	[MenuItem("发布/资源/UI/sign", false, 9)]
	static void MakesignBreaker () {
		UIAUTOAtlasMaker.MakeAtlas("images/sign");
	}

	[MenuItem("发布/资源/UI/recharge", false, 10)]
	static void MakerechargeBreaker () {
		UIAUTOAtlasMaker.MakeAtlas("images/recharge");
	}

	[MenuItem("发布/资源/UI/share", false, 11)]
	static void MakeshareBreaker () {
		UIAUTOAtlasMaker.MakeAtlas("images/share");
	}

	[MenuItem("发布/资源/UI/star", false, 12)]
	static void MakestarBreaker () {
		UIAUTOAtlasMaker.MakeAtlas("images/star");
	}

	[MenuItem("发布/资源/UI/strengthen_place", false, 13)]
	static void Makestrengthen_placeBreaker () {
		UIAUTOAtlasMaker.MakeAtlas("images/strengthen_place");
	}

	[MenuItem("发布/资源/UI/switch", false, 14)]
	static void MakeswitchBreaker () {
		UIAUTOAtlasMaker.MakeAtlas("images/switch");
	}

	[MenuItem("发布/资源/UI/talk", false, 15)]
	static void MaketalkBreaker () {
		UIAUTOAtlasMaker.MakeAtlas("images/talk");
	}

	[MenuItem("发布/资源/UI/upgrade", false, 16)]
	static void MakeupgradeBreaker () {
		UIAUTOAtlasMaker.MakeAtlas("images/upgrade");
	}

	[MenuItem("发布/资源/UI/tip", false, 17)]
	static void MaketipBreaker () {
		UIAUTOAtlasMaker.MakeAtlas("images/tip");
	}

	[MenuItem("发布/资源/UI/chat", false, 18)]
	static void MakechatBreaker () {
		UIAUTOAtlasMaker.MakeAtlas("images/chat");
	}

	[MenuItem("发布/资源/UI/common", false, 19)]
	static void MakecommonBreaker () {
		UIAUTOAtlasMaker.MakeAtlas("images/common");
	}

	[MenuItem("发布/资源/UI/friend", false, 20)]
	static void MakefriendBreaker () {
		UIAUTOAtlasMaker.MakeAtlas("images/friend");
	}
	[MenuItem("发布/资源/UI/astrology", false, 21)]
	static void MakeastrologyBreaker () {
		UIAUTOAtlasMaker.MakeAtlas("images/astrology");
	}
	[MenuItem("发布/资源/UI/intro", false, 22)]
	static void MakeintroBreaker () {
		UIAUTOAtlasMaker.MakeAtlas("images/intro");
	}
	[MenuItem("发布/资源/UI/item", false, 23)]
	static void MakeitemBreaker () {
		UIAUTOAtlasMaker.MakeAtlas("images/item");
	}
	[MenuItem("发布/资源/UI/level_reward", false, 24)]
	static void Makelevel_rewardBreaker () {
		UIAUTOAtlasMaker.MakeAtlas("images/level_reward");
	}
	[MenuItem("发布/资源/UI/active", false, 25)]
	static void MakeactiveBreaker () {
		UIAUTOAtlasMaker.MakeAtlas("images/active");
	}
	[MenuItem("发布/资源/UI/arena", false, 26)]
	static void MakearenaBreaker () {
		UIAUTOAtlasMaker.MakeAtlas("images/arena");
	}
	[MenuItem("发布/资源/UI/bag", false, 27)]
	static void MakebagBreaker () {
		UIAUTOAtlasMaker.MakeAtlas("images/bag");
	}
	[MenuItem("发布/资源/UI/shop", false, 28)]
	static void MakeshopBreaker () {
		String[] ignores = {"pubbg"};
		UIAUTOAtlasMaker.MakeAtlas("images/shop" ,ignores);
	}
	[MenuItem("发布/资源/UI/treasure", false, 29)]
	static void MaketreasureBreaker () {
		String[] ignores = {"background"};
		UIAUTOAtlasMaker.MakeAtlas("images/treasure",ignores);
	}
	[MenuItem("发布/资源/UI/copy", false, 30)]
	static void MakecopyBreaker () {
		String[] ignores = {"nameimage","thumbnail"};
		UIAUTOAtlasMaker.MakeAtlas("images/copy",ignores);
	}
	[MenuItem("发布/资源/UI/hero", false, 31)]
	static void MakeheroBreaker () {
//		String[] ignores = {"nameimage","thumbnail"};
		UIAUTOAtlasMaker.MakeAtlas("images/hero");
	}
//	[MenuItem("发布/资源/UI/hero", false, 32)]
//	static void MakeheroBreaker () {
//		//		String[] ignores = {"nameimage","thumbnail"};
//		UIAUTOAtlasMaker.MakeAtlas("images/hero");
//	}
	[MenuItem("发布/资源/UI/guide", false, 32)]
	static void MakeguideBreaker () {
		String[] ignores = {"effect"};
		UIAUTOAtlasMaker.MakeAtlas("images/guide" , ignores);
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
