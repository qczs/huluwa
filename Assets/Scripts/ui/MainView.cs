using UnityEngine;
using System.Collections;
using System;
using System.Reflection;

public class MainView : MonoBehaviour {

	public GameObject btnFormation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (RoleManager.getInstance().roleInfo.updateType){
//			UILabel uname = GameObject.Find("uname").GetComponent<UILabel>();
//			uname.text = RoleManager.getInstance().roleInfo.roleName;

//			UITexture heroImage = GameObject.Find("heroImage").GetComponent<UITexture>();
//			Debug.Log ("heroImage :" + heroImage.mainTexture.name);

//			heroImage.mainTexture = RoleManager.getInstance().roleInfo.roleImg;

//			WWW www = new WWW("http://u3dchina.com/template/singcere_dw/common/images/logo.png");
//			yield return www;
//			Texture2D txt2d = new Texture2D(4, 4, TextureFormat.DXT1, false);
//			Resources.LoadAssetAtPath("http://u3dchina.com/template/singcere_dw/common/images/logo.png", typeof(Texture)) as Texture;


//			Texture2D img = Resources.Load<Texture2D>("head_icon/head_caocao");
//			Debug.Log ("img :" + img.name);
//			heroImage.mainTexture =img;
			//GameObject.Find("heroImage").GetComponent<UITexture>().mainTexture = Resources.LoadAssetAtPath(PathUtils.getPath(RoleManager.getInstance().roleInfo.roleImg), typeof(Texture)) as Texture;;
			PathUtils.DataBind(RoleManager.getInstance().roleInfo);
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
