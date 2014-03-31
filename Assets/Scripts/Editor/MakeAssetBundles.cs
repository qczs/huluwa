using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Diagnostics;

static public class  MakeAssetBundles {

	public static  void Make(){


		var options = BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets;
		DirectoryInfo dir = new DirectoryInfo( Application.dataPath+"/ui");
		FileInfo[] files = dir.GetFiles();

		AssetDatabase.CreateFolder("Assets/StreamingAssets/","ui");
		foreach(FileInfo file in files){
			if(file.Extension==".prefab"){
				UnityEngine.Debug.Log(file.Name);
				BuildPipeline.BuildAssetBundle(AssetDatabase.LoadAssetAtPath("Assets/ui/"+file.Name,typeof(UnityEngine.Object)) as UnityEngine.Object,
				                               null,
				                               "Assets/StreamingAssets/ui/"+file.Name.Replace(".prefab",".u3d"),options, BuildTarget.Android);
			}
		}
	}
}
