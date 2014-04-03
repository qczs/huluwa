using UnityEngine;
using System.Collections;
using Scenes;
namespace Scenes{
	public class LoginScene : IScene
	{
		public LoginScene(){
			destroyOnClose = true;
		}
		public override string GetViewName(){
			return ScenesConfig.LOGINSCENE;
		}
		public override string GetViewPath(){
			return "ui/LoginView";
		}

		public override Transform GetParent(){
			return ScenesManager.scenesManager.stage.transform;
		}
			
	}
}

