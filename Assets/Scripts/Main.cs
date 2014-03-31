using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	private GameObject prefab;  
	// Use this for initialization
	public static Main main;
	private Transform _transform;
	//不同平台下StreamingAssets的路径是不同的
		public static readonly string PathURL =
#if UNITY_ANDROID   //安卓
			"jar:file://" + Application.dataPath + "!/assets/";
#elif UNITY_IPHONE  //iPhone
			Application.dataPath + "/Raw/";
#elif UNITY_STANDALONE_WIN || UNITY_EDITOR  //windows平台和web平台
			"file://" + Application.dataPath + "/StreamingAssets/";
#else
			string.Empty;
#endif
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

		Object go = Resources.Load(path,typeof(GameObject));
		if(go!=null){
			InstantiateViews(go);
		}else{
#if UNITY_EDITOR
			InstantiateViews(Resources.LoadAssetAtPath("Assets/"+path+".prefab",typeof(GameObject)));
#else
			StartCoroutine(LoadMainGameObject(PathURL+path+".u3d"));
#endif
		}
	}
	private IEnumerator LoadMainGameObject(string path)
	{
		Debug.Log(path);
		WWW bundle = new WWW(path);
		yield return bundle;

		yield return InstantiateViews(bundle.assetBundle.mainAsset);
		bundle.assetBundle.Unload(false);
	}

	public GameObject InstantiateViews(Object go){

		prefab = Instantiate(go,_transform.position,_transform.rotation) as GameObject;
		prefab.transform.parent = _transform;
		prefab.transform.localScale = _transform.localScale;
		return prefab;
	}
}
