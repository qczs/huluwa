using UnityEngine;
using System.Collections;

public class MainView : MonoBehaviour {

	public GameObject btnFormation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (RoleManager.getInstance().roleInfo.updateType){
			UILabel UILabel = GameObject.Find("uname").GetComponent<UILabel>();
			UILabel.text = RoleManager.getInstance().roleInfo.roleName;
			RoleManager.getInstance().roleInfo.updateType = false;
			long a = TimeUtil.UNIX_TIMESTAMP (System.DateTime.Now);
			Debug.Log ("a :" + a);
		}

	}

	void Awake ()
	{  //获取需要监听的按钮对象
		
		
		//设置这个按钮的监听，指向本类的ButtonClick方法中。
		//		UIButton btn = btnLogin.GetComponent<UIButton>();
		//		btn.onClick =ButtonClick
		UIEventListener.Get(btnFormation).onClick = FormationViewClick;
		
	}
	void FormationViewClick(GameObject button)
	{
		Main.main.ShowView("ui/FormationView");
		Main.main.HideView(gameObject);	
	}

}
