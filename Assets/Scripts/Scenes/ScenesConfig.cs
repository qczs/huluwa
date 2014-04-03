using UnityEngine;
using System.Collections;
using Scenes;
public class ScenesConfig 
{
	public static string LOGINSCENE = "ui/LoginView";
	public static string MAINSCENE = "ui/MainView";
	public static string FORMATIONVIEW = "ui/FormationView";
	public static IScene GetSceneByName(string name){
		IScene scene = null;
		if(LOGINSCENE.Equals(name)){
			scene = new LoginScene();
		}else if(MAINSCENE.Equals(name)){
			scene = new MainScene();
		}else if(FORMATIONVIEW.Equals(name)){
			scene = new FormationScene();
		}
		return scene;
	}
}

