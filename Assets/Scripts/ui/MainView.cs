using UnityEngine;
using System.Collections;

public class MainView : MonoBehaviour {

	public GameObject btnFormation;
	public GameObject container;
	// Use this for initialization
	void Start () {




	}
	
	// Update is called once per frame
	void Update () {

	}

	void Awake ()
	{  
		//获取需要监听的按钮对象
		
		GameObject btnBag = GameObject.Find("Mainbuttom/Container/button/btnBag");
		UIEventListener.Get(btnBag).onClick = FormationViewClick;
		GameObject btnFormation = GameObject.Find("Mainbuttom/Container/button/btnFormation");
		UIEventListener.Get(btnFormation).onClick = FormationViewClick;
		GameObject btnMainPage = GameObject.Find("Mainbuttom/Container/button/btnMainPage");
		UIEventListener.Get(btnMainPage).onClick = FormationViewClick;
		GameObject btnPromotion = GameObject.Find("Mainbuttom/Container/button/btnPromotion");
		UIEventListener.Get(btnPromotion).onClick = FormationViewClick;
		GameObject btnShop = GameObject.Find("Mainbuttom/Container/button/btnShop");
		UIEventListener.Get(btnShop).onClick = FormationViewClick;
		GameObject btnCopy = GameObject.Find("Mainbuttom/Container/button/btnCopy");
		UIEventListener.Get(btnCopy).onClick = FormationViewClick;
	

	}
	void FormationViewClick(GameObject button)
	{
//		Main.main.ShowView("ui/FormationView");
//		Main.main.HideView(gameObject);	
	}

}
