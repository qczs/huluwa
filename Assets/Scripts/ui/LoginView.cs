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
		UIEventListener.Get(btnLogin).onClick = ButtonClick;
	
	}

	void ButtonClick(GameObject button)
	{
//		Main.main.ShowView("ui/MainView");
//		Main.main.HideView(gameObject);
		Skills skill = ResourceManager.getInstance().getSkills("1007");
		if (Debug.isDebugBuild) {
			Debug.Log ("skill :" +skill.ToString());
		}
	}


}
