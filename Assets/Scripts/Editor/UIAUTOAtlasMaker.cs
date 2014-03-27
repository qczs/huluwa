using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Diagnostics;
static public class UIAUTOAtlasMaker {
	static public void MakeAtlas(string path){

		DirectoryInfo dir = new DirectoryInfo( Application.dataPath+"/"+path);
		if(dir.Exists){
			AssetDatabase.DeleteAsset("/Resources/ui/"+dir.Name+"/"+dir.Name+".txt");
			AssetDatabase.DeleteAsset("/Resources/ui/"+dir.Name+"/"+dir.Name+".png");
			Process process;
			string fileName = "/Applications/TexturePacker.app/Contents/MacOS/TexturePacker";
			string arguments = 
				"--format unity " +
					"--data "+Application.dataPath+"/Resources/ui/"+dir.Name+"/"+dir.Name+".txt " +
					"--sheet "+Application.dataPath+"/Resources/ui/"+dir.Name+"/"+dir.Name+".png " +
					"--opt RGBA8888 " +
					"--algorithm Basic --basic-sort-by Best "+
			        "--max-width 2048 " +
			        "--max-height 2048 " +
			        "--border-padding 0 " +
			        "--shape-padding 0 "+
					dir.FullName;
			UnityEngine.Debug.Log(fileName +" "+ arguments);
			ProcessStartInfo info = new ProcessStartInfo (fileName, arguments);
			info.UseShellExecute = false;
			info.RedirectStandardError = true;
			info.RedirectStandardOutput = true;
			process = Process.Start (info);

			string strRst = process.StandardOutput.ReadToEnd(); 
			UnityEngine.Debug.Log(strRst);
			process.Close();
			AssetDatabase.Refresh();
			string matPath = "Assets/Resources/ui/"+dir.Name+"/"+dir.Name+".mat";
			string prefabPath ="Assets/Resources/ui/"+dir.Name+"/"+dir.Name+".prefab";
			GameObject go = AssetDatabase.LoadAssetAtPath(prefabPath, typeof(GameObject)) as GameObject;
			// Try to load the material
			Material mat = AssetDatabase.LoadAssetAtPath(matPath, typeof(Material)) as Material;
			TextAsset text = AssetDatabase.LoadAssetAtPath("Assets/Resources/ui/"+dir.Name+"/"+dir.Name+".txt",typeof(TextAsset)) as TextAsset;
			// If the material doesn't exist, create it
			if (mat == null)
			{
				Shader shader = Shader.Find(NGUISettings.atlasPMA ? "Unlit/Premultiplied Colored" : "Unlit/Transparent Colored");
				mat = new Material(shader);
				mat.mainTexture = AssetDatabase.LoadAssetAtPath("Assets/Resources/ui/"+dir.Name+"/"+dir.Name+".png",typeof(Texture)) as Texture;
				// Save the material
				AssetDatabase.CreateAsset(mat, matPath);
				AssetDatabase.Refresh();
				
				// Load the material so it's usable
				mat = AssetDatabase.LoadAssetAtPath(matPath, typeof(Material)) as Material;
			}

			// Create a new prefab for the atlas
			UnityEngine.Object prefab = (go != null) ? go : PrefabUtility.CreateEmptyPrefab(prefabPath);
			string atlasName = prefabPath.Replace(".prefab", "");
			atlasName = atlasName.Substring(prefabPath.LastIndexOfAny(new char[] { '/', '\\' }) + 1);
			go = new GameObject(atlasName);
			UIAtlas uiAtlas = go.AddComponent<UIAtlas>();
			uiAtlas.spriteMaterial = mat;
			if (uiAtlas.texture != null) NGUIEditorTools.ImportTexture(uiAtlas.texture, false, false, !uiAtlas.premultipliedAlpha);
			NGUIJson.LoadSpriteData(uiAtlas,text );
			// Update the prefab
			PrefabUtility.ReplacePrefab(go, prefab);
			EditorWindow.DestroyImmediate(go);
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
		}else{

			UnityEngine.Debug.Log("no File " + path);
		}
	}

}
