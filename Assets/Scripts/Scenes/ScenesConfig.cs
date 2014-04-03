using UnityEngine;
using System.Collections;
using Scenes;
public class ScenesConfig 
{
	public static string LOGINSCENE = "ui/LoginView";

	public static IScene GetSceneByName(string name){
		IScene scene = null;
		if(LOGINSCENE.Equals(name)){
			scene = new LoginScene();
		}
		return scene;
	}
}

