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
		
		public override Transform GetParent(){
			return ScenesManager.scenesManager.stage.transform;
		}
}
}

