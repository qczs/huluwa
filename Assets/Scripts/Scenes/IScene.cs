using UnityEngine;
using System.Collections;
namespace Scenes{
	public abstract class IScene {
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
				GameObject parent = GetParent();
				Transform tf = parent.transform;
				gameobject = GameObject.Instantiate(assetBundle,tf.position,tf.rotation) as GameObject;
				gameobject.transform.parent = tf;
				gameobject.transform.localScale = tf.localScale;
				gameobject.layer = parent.layer;
				AddComponents();
			}
		}
		protected abstract void AddComponents();
		public abstract string GetViewName();
		public abstract string GetViewPath();
		public abstract GameObject GetParent();
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
			Resources.UnloadUnusedAssets();
		}
	}
}