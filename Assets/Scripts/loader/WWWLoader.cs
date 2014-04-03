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
//		if(!File.Exists(Application.dataPath +"/"+ path + ".prefab")){
//			StartCoroutine(loadBundle(path + ".prefab")); 
//		}else{
			StartCoroutine(loadBundleFromLocal(PathURL+path+".u3d")); //本地加载
//		}
	}
	private IEnumerator loadBundle(string name){

		string pathName = Application.persistentDataPath  + name;
		string url = PathURL + name + suffix;
		using(WWW www =new WWW(url)){
			yield return www;
			if(www.error == null){

				if(!File.Exists(pathName)){
					//write file in local
					File.WriteAllBytes(pathName,www.bytes);
					//other function
					//                  FileStream fs = new FileStream(Application.persistentDataPath + path + name + version,FileMode.OpenOrCreate);
					//                  fs.Write(www.bytes,0,www.bytes.Length);
					//                  fs.Flush();
					//                  fs.Close();
					Debug.Log("load bundle succeed,write file path:"+pathName );
				}else{
					Debug.Log("write file error...");
				}
				AssetBundle ab = www.assetBundle;
				GameObject go = ab.mainAsset as GameObject;
				cache[name] = go;
			}
		}
	}

	private IEnumerator loadBundleFromLocal(string path){
		using(WWW www = new WWW(path)){
			yield return www;
			if(www.error == null){
				onLoadCallBack(www);
				Debug.Log("load data frome local succeed...");
			}
		}
	}
}

