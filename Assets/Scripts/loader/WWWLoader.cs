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

		if(File.Exists(localPath)){
			StartCoroutine(loadBundle("Assets/"+path+".prefab")); 
		}else{
			StartCoroutine(loadBundleFromLocal(PathURL+path+".u3d")); //本地加载
		}

	}

	public void LoadImage(string path,UITexture uiTexture){
		StartCoroutine(loadImageeFromLocal(PathURL+path,uiTexture));
	}

	private IEnumerator loadBundle(string name){


	 	yield return new WaitForSeconds(0.01f);
		Object assetBundle = Resources.LoadAssetAtPath<Object>(name);

		onLoadCallBack(assetBundle);
	}

	private IEnumerator loadBundleFromLocal(string path){

		using(WWW www = new WWW(path)){
			while(!www.isDone){
				Debug.Log(www.progress);
				yield return 1;
			}

			if(www.error == null){
				onLoadCallBack(www.assetBundle.mainAsset);
				www.assetBundle.Unload(false);
				www.Dispose();

			}
		}
	}

	private IEnumerator loadImageeFromLocal(string path,UITexture uiTexture){
		
		using(WWW www = new WWW(path)){
			while(!www.isDone){
				yield return 1;
			}
			
			if(www.error == null){
//				onLoadCallBack(www.assetBundle.mainAsset);

				uiTexture.mainTexture = www.texture;

				www.Dispose();
				
			}
		}
	}
}

