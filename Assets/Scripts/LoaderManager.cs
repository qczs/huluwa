using UnityEngine;
using System.Collections;

public class LoaderManager
{
	public delegate void OnLoadComplete(WWW www);
	private static LoaderManager _loaderManager;
	private WWWLoader loader;
	public static LoaderManager loaderManager{
		get{
			if(_loaderManager==null){
				_loaderManager = new LoaderManager();
			}
			return _loaderManager;
		}
	}
	public LoaderManager(){
		GameObject _loader =  new GameObject("_loader");
		MonoBehaviour.DontDestroyOnLoad(_loader);
		loader = _loader.AddComponent<WWWLoader>();
	}

	public void LoadRessour(string path,OnLoadComplete callBack){

		loader.Load(path,callBack);
	}
}

