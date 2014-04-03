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
		
		GameObject btnBag = GameObject.Find("buttom/button/btnBag");
		UIEventListener.Get(btnBag).onClick = FormationViewClick;
		GameObject btnFormation = GameObject.Find("buttom/button/btnFormation");
		UIEventListener.Get(btnFormation).onClick = FormationViewClick;
		GameObject btnMainPage = GameObject.Find("buttom/button/btnMainPage");
		UIEventListener.Get(btnMainPage).onClick = FormationViewClick;
		GameObject btnPromotion = GameObject.Find("buttom/button/btnPromotion");
		UIEventListener.Get(btnPromotion).onClick = FormationViewClick;
		GameObject btnShop = GameObject.Find("buttom/button/btnShop");
		UIEventListener.Get(btnShop).onClick = FormationViewClick;
		GameObject btnCopy = GameObject.Find("buttom/button/btnCopy");
		UIEventListener.Get(btnCopy).onClick = FormationViewClick;
		ScenesManager.scenesManager.CloseScene(ScenesConfig.LOGINSCENE);

	}
	void FormationViewClick(GameObject button)
	{
		ScenesManager.scenesManager.ShowScene(ScenesConfig.FORMATIONVIEW);
	}

}
