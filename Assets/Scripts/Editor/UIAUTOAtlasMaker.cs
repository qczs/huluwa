using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

static public class UIAUTOAtlasMaker {
	static public void MakeAtlas(string path){
		if(Directory.Exists(path)){
			string[] files = Directory.GetFiles(path);
			foreach(string file in files){
				Debug.Log(file);
			}
		}else{
			Debug.Log("no File " + path);
		}
	}

}
