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
			AssetDatabase.DeleteAsset(Application.dataPath+"/Resources/ui/"+dir.Name+"/"+dir.Name+".txt");
			AssetDatabase.DeleteAsset(Application.dataPath+"/Resources/ui/"+dir.Name+"/"+dir.Name+".png");
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
			AssetDatabase.Refresh();
			process.Close();
		}else{

			UnityEngine.Debug.Log("no File " + path);
		}
	}

}
