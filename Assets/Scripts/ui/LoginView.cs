using UnityEngine;
using System.Collections;

public class LoginView : MonoBehaviour {
	public GameObject btnLogin;
	// Use this for initialization
	void Awake ()
	{  //获取需要监听的按钮对象


		//设置这个按钮的监听，指向本类的ButtonClick方法中。
//		UIButton btn = btnLogin.GetComponent<UIButton>();
//		btn.onClick =ButtonClick
		btnLogin = GameObject.Find("btnLogin");
		UIEventListener.Get(btnLogin).onClick = ButtonClick;
	
	}

	void ButtonClick(GameObject button)
	{

//		Skills skill = ResourceManager.getInstance().getSkills("1007");
//		if (Debug.isDebugBuild) {
//			Debug.Log ("skill :" +skill.ToString());
//		}
//		RoleManager.getInstance().roleInfo.roleName = "abcd";
//		RoleManager.getInstance().roleInfo.updateType = true;
		ScenesManager.scenesManager.ShowScene(ScenesConfig.MAINSCENE);
	}


}
