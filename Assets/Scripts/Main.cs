using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	private GameObject prefab;  
	// Use this for initialization
	public static Main main;
	private Transform _transform;
	void Start () {
		main = this;

		_transform = gameObject.transform;
		ShowView("ui/LoginView");

	}
	void Awake ()
	{
		//修改当前的FPS
		Application.targetFrameRate = 30;
	}
	public void HideView(GameObject go){
		Destroy(go);
	}
	public void ShowView(string path){
		prefab = Instantiate(Resources.Load(path),_transform.position,_transform.rotation) as GameObject;
		prefab.transform.parent = _transform;
		prefab.transform.localScale = _transform.localScale;
	}

}
