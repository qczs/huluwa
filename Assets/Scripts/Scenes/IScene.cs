using UnityEngine;
using System.Collections;
namespace Scenes{
	public abstract  class IScene {
		protected bool _destroyOnClose = true;
		protected bool loaded = false;
		protected GameObject gameobject;
		public void Open(){
			if(loaded){

			}else{
				LoaderManager loaderManager =	LoaderManager.loaderManager;
				loaderManager.LoadRessour(GetViewPath(),new LoaderManager.OnLoadComplete(OnLoadComplete));
			}
		}
		protected void OnLoadComplete(WWW www){
			AssetBundle ab = www.assetBundle;
			Transform parent = GetParent();
			gameobject = GameObject.Instantiate(ab.mainAsset,parent.position,parent.rotation) as GameObject;
			gameobject.transform.parent = parent;
			gameobject.transform.localScale = parent.localScale;
			gameobject.layer = parent.gameObject.layer;
			ab.Unload(false);
		}
		public abstract string GetViewName();
		public abstract string GetViewPath();
		public abstract Transform GetParent();
		public bool destroyOnClose{
			get{
				return _destroyOnClose;
			}
			set{
				_destroyOnClose = value;
			}
		}
		public void Close(){
			if(_destroyOnClose){
				Destory();
			}
		}

		public void Destory(){

		}
	}
}