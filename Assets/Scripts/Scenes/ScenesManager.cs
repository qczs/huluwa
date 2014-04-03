using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Scenes;
public class ScenesManager 
{
	private static ScenesManager _scenesManager;
	public MonoBehaviour stage;
	public int stageHeight=0;
	public int stageWidth = 0;

	private IDictionary<string,IScene> scenesOpenList;
	public static ScenesManager scenesManager{
		get{
			if(_scenesManager==null){
				_scenesManager = new ScenesManager();
			}
			return _scenesManager;
		}
	}

	public void Init(){
		scenesOpenList = new Dictionary<string,IScene>();
		ShowScene(ScenesConfig.LOGINSCENE);
	}

	public void ShowScene(string name){
		IScene scene=null;
		if(scenesOpenList.TryGetValue(name,out scene)){

		}else{
			scene = ScenesConfig.GetSceneByName(name);
			scenesOpenList.Add(name,scene);
			scene.Open();
		}
	}
}

