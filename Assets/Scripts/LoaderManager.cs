using UnityEngine;
using System.Collections;

public class LoaderManager
{
	public delegate void OnLoadComplete(Object assetBundle);
	public delegate void OnImageLoadComplete(Texture texture);
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
	public UIAtlas GetUIatlas(string name){
		UIAtlas[] atlas = Resources.FindObjectsOfTypeAll<UIAtlas>();
		UIAtlas atla = null;
		int length = atlas.Length;
		for(int i = 0;i<length;i++){
			atla = atlas[i];
			Debug.Log(atla.name);
			if(name.Equals(atla.name)){
				return atla;
			}
		}
		return atla;
	}
	public void LoadRessour(string path,OnLoadComplete callBack){

		loader.Load(path,callBack);
	}

	public void LoadImage(string path,UITexture uiTexture){
		loader.LoadImage(path,uiTexture);
	}
}

