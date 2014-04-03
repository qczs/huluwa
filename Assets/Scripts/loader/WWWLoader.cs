using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class WWWLoader : MonoBehaviour
{
	public static string suffix = ".u3d";//资源包后缀
	//不同平台下StreamingAssets的路径是不同的
	public static readonly string PathURL =
#if UNITY_ANDROID && !UNITY_EDITOR
		"jar:file://" + Application.dataPath + "!/assets/";
#elif UNITY_IPHONE && !UNITY_EDITOR
		Application.dataPath + "/Raw/";
#elif UNITY_STANDALONE_WIN || UNITY_EDITOR
		"file://" + Application.dataPath + "/StreamingAssets/";
#else
		string.Empty;
#endif
	public static Dictionary<string,GameObject> cache = new Dictionary<string, GameObject>();
	public LoaderManager.OnLoadComplete onLoadCallBack;
	public void Load(string path,LoaderManager.OnLoadComplete callback){
		onLoadCallBack = callback;
		string localPath = Application.dataPath +"/"+ path + ".prefab";
		Debug.Log(localPath);
		if(File.Exists(localPath)){
			StartCoroutine(loadBundle("Assets/"+path+".prefab")); 
		}else{
			StartCoroutine(loadBundleFromLocal(PathURL+path+".u3d")); //本地加载
		}

	}
	private IEnumerator loadBundle(string name){

		Debug.Log(name);
	 	yield return new WaitForSeconds(0.01f);
		Object assetBundle = Resources.LoadAssetAtPath<Object>(name);
		onLoadCallBack(assetBundle);
	}

	private IEnumerator loadBundleFromLocal(string path){
		Debug.Log("loadBundleFromLocal "+path);
		using(WWW www = new WWW(path)){
			yield return www;
			if(www.error == null){
				onLoadCallBack(www.assetBundle.mainAsset);
				www.assetBundle.Unload(false);
				Debug.Log("load data frome local succeed...");
			}
		}
	}
}

