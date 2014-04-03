using UnityEngine;
using System.Collections;
using Scenes;
namespace Scenes{
public class MainScene : IScene
{

		public MainScene(){
			destroyOnClose = false;
		}
		public override string GetViewName(){
			return ScenesConfig.LOGINSCENE;
		}
		public override string GetViewPath(){
			return "ui/MainView";
		}
		protected override void AddComponents(){
			gameobject.AddComponent<MainView>();
			ScenesManager.scenesManager.centerPanel = GameObject.Find("centerPanel");

		}
		public override GameObject GetParent(){
			return ScenesManager.scenesManager.stage.gameObject;
		}
}
}

