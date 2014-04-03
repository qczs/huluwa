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
		protected void OnLoadComplete(Object assetBundle){
			if(!loaded){
				loaded = true;
				Transform parent = GetParent();
				gameobject = GameObject.Instantiate(assetBundle,parent.position,parent.rotation) as GameObject;
				gameobject.transform.parent = parent;
				gameobject.transform.localScale = parent.localScale;
				gameobject.layer = parent.gameObject.layer;
				AddComponents();
			}
		}
		protected abstract void AddComponents();
		public abstract string GetViewName();
		public abstract string GetViewPath();
		public abstract Transform GetParent();
		public  void Update(){

		}
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
				gameobject.SetActive(false);
				Destory();
			}
		}

		public void Destory(){
			GameObject.Destroy(gameobject);
		}
	}
}