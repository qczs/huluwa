using UnityEngine;
using System.Collections;
using Scenes;
namespace Scenes{
public class FormationScene : IScene
{
		public FormationScene(){
			destroyOnClose = true;
		}
		public override string GetViewName(){
			return ScenesConfig.FORMATIONVIEW;
		}
		public override string GetViewPath(){
			return "ui/FormationView";
		}
		protected override void AddComponents(){

		}
		public override GameObject GetParent(){
			return ScenesManager.scenesManager.centerPanel;
		}

}
}

