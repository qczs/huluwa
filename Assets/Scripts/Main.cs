using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	
	void Awake ()
	{
		//修改当前的FPS
		Application.targetFrameRate = 30;
		ScenesManager.scenesManager.stage = this;
		ScenesManager.scenesManager.stageHeight = Screen.height;
		ScenesManager.scenesManager.stageWidth = Screen.width;
		ScenesManager.scenesManager.Init();

	}


}
