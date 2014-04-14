using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FormationView : MonoBehaviour
{
	private GameObject bodyList;
	private GameObject BodyItem;

	private GameObject headList;
	private GameObject HeadItem;
	private UICenterOnChild uiCenterOnChild;
	private UISprite selectItem;
	struct Head_Body{
		public GameObject head;
		public GameObject body;
	}

	private List<Head_Body> head_bodys;
	void Awake (){
		HeadItem = GameObject.Find("Item");
		headList = HeadItem.transform.parent.gameObject;
		HeadItem.SetActive(false);
		HeadItem.transform.parent = null;
//		GameObject item;
//
//		for(int i =0;i<100;i++){
//			item = Instantiate(Item,Item.transform.position,Item.transform.rotation) as GameObject;
//			item.transform.parent = List.transform;
//			item.transform.localScale = List.transform.localScale;
//		}
		BodyItem=GameObject.Find("Item_body_img");
		bodyList = BodyItem.transform.parent.gameObject;
		BodyItem.SetActive(false);
		BodyItem.transform.parent = null;

//		for(int i = 0;i<10;i++){
//			item = Instantiate(Item_body_img,Item_body_img.transform.position,Item_body_img.transform.rotation) as GameObject;
//			item.transform.parent = List.transform;
//			item.transform.localScale = List.transform.localScale;
//		}
		uiCenterOnChild = NGUITools.FindInParents<UICenterOnChild>(bodyList.gameObject);
		if(uiCenterOnChild!=null && uiCenterOnChild.enabled){
			uiCenterOnChild.onFinished = onDragFinished;
		}else{
			UIScrollView scrollview = NGUITools.FindInParents<UIScrollView>(bodyList.gameObject);

		scrollview.onDragFinished = onDragFinished;
		}


		selectItem = NGUITools.AddSprite(headList.transform.parent.gameObject,LoaderManager.loaderManager.GetUIatlas("formation"),"potential/highlight");
		selectItem.width = 128;
		selectItem.height = 128;
		NGUITools.NormalizeWidgetDepths();

		selectItem.transform.position = Vector3.zero;
		selectItem.transform.localPosition = Vector3.zero;

		head_bodys = new List<Head_Body>();
		for(int i = 0;i<10;i++){
			AddHero();
		}
		selectItem.depth = NGUITools.CalculateNextDepth(headList.gameObject);
		UIScrollView headscrollview = NGUITools.FindInParents<UIScrollView>(headList.gameObject);
		Debug.Log("bounds:"+headscrollview.bounds.size);

	}

	public void AddHero(){
		GameObject item;
		UITexture uiTexture;
		Head_Body head_Body = new Head_Body();
		string[] BODY={"baimayicong"    ,"qiangnubing"
			,"bianshi"    ,"qibing"
				,"bulianshi"    ,"qigu"
					,"caifuren"   ,"qigubing"
					,"caiwenji"   ,"shenjinupao"
					,"caoang"     ,"simayi"
					,"caocao"     ,"sunce"
					,"caohong"    ,"sunjian"
					,"caojie"     ,"sunluban"
					,"caopei"     ,"sunluyu"
					,"changqiang"   ,"sunquan"
					,"chendeng"   ,"sunshangxiang"
					,"chengong"   ,"taishici"
					,"chengpu"    ,"tengjiabing"
					,"chunyuqiong"    ,"wangyun"
					,"cike"     ,"weiyan"
					,"dajishi"    ,"wenchou"
					,"daoche"     ,"wenguan1"
					,"daqiao"     ,"wenguan2"
					,"dazhanghuanghou"  ,"wenguan3"
					,"dianwei"    ,"wenguan4"
					,"diaochan"   ,"wenguan5"
					,"dingyuan"   ,"wenguan6"
					,"dongzhuo"   ,"wenpin"
					,"feibiao"    ,"wuguotai"
					,"feixiong"   ,"wuji"
					,"fuqibing"   ,"wujiang1"
					,"ganfuren"   ,"wujiang10"
					,"ganning"    ,"wujiang11"
					,"gaoshun"    ,"wujiang2"
					,"gongbing"   ,"wujiang3"
					,"guanping"   ,"wujiang4"
					,"guanxing"   ,"wujiang5"
					,"guanyinping"    ,"wujiang6"
					,"guanyu"     ,"wujiang7"
					,"guojia"     ,"wujiang8"
					,"guoshi"     ,"wujiang9"
					,"heshi"      ,"wushushi"
					,"huangfusong"    ,"xiahoudun"
					,"huanggai"   ,"xiahoushi"
					,"huangjin"   ,"xiandengsishi"
					,"huangjinjun"    ,"xiangbing"
					,"huangpusong"    ,"xiaoqiao"
					,"huangyueying"   ,"xiliangtieqi"
					,"huangzhong"   ,"xinxianying"
					,"huatuo"     ,"xuchu"
					,"huaxiong"   ,"xuhuang"
					,"hubaoqi"    ,"xunyou"
					,"jiangwei"   ,"xunyu"
					,"jianwunvshen"   ,"xusheng"
					,"jiaxu"      ,"xushu"
					,"jiling"     ,"xuyou"
					,"jingyan_xiongmao" ,"yanliang"
					,"jinweijun"    ,"yaoshushi"
					,"lejin"      ,"yingwei"
					,"lidian"     ,"yuanshang"
					,"lingtong"   ,"yuanshao"
					,"liru"     ,"yuanshu"
					,"lisu"     ,"yuji"
					,"liubei"     ,"yujin"
					,"liubiao"    ,"zhangbao"
					,"longxiang"    ,"zhangbao_1"
					,"lukang"     ,"zhangchunhua"
					,"lusu"     ,"zhangfei"
					,"luxun"      ,"zhanghe"
					,"luzhi"      ,"zhangjiao"
					,"lvbu"     ,"zhangliao"
					,"lvmeng"     ,"zhangxingcai"
					,"machao"     ,"zhangxiu"
					,"madai"      ,"zhangzhao"
					,"manchong"   ,"zhaoyun"
					,"mifuren"    ,"zhenji"
					,"modongzhuo"   ,"zhongqibing"
					,"molvbu"     ,"zhoucang"
					,"mozhangjiao"    ,"zhoutai"
					,"nanxing"    ,"zhouyu"
					,"nanzhu"     ,"zhugejin"
					,"nvxing"     ,"zhugeliang"
					,"nvzhu"      ,"zhurong"
					,"piliche"    ,"zoushi"
					,"qiangnu"    ,"zuoci"
		};
		int index = Mathf.RoundToInt(BODY.Length*Random.value);
		string image = BODY[index];
		item = Instantiate(HeadItem,HeadItem.transform.position,HeadItem.transform.rotation) as GameObject;
		item.transform.parent = headList.transform;
		item.transform.localScale = headList.transform.localScale;
		item.SetActive(true);
		head_Body.head = item;

		uiTexture = item.GetComponentInChildren<UITexture>();
		LoaderManager.loaderManager.LoadImage("images/base/hero/head_icon/head_"+image+".png",uiTexture);
		item = Instantiate(BodyItem,BodyItem.transform.position,BodyItem.transform.rotation) as GameObject;
		item.transform.parent = bodyList.transform;
		item.transform.localScale = bodyList.transform.localScale;
		item.SetActive(true);
		head_Body.body = item;
		uiTexture = item.GetComponentInChildren<UITexture>();
		head_bodys.Add(head_Body);
		LoaderManager.loaderManager.LoadImage("images/base/hero/body_img/quan_jiang_"+image+".png",uiTexture);
	}

	private void onDragFinished(){
//		UIScrollView scrollview = NGUITools.FindInParents<UIScrollView>(bodyList.gameObject);
		UIScrollView headscrollview = NGUITools.FindInParents<UIScrollView>(headList.gameObject);
		Debug.Log("bounds:"+headscrollview.bounds);
		Head_Body head_Body;
		int i = 0, imax = head_bodys.Count;
		for (; i < imax; ++i){
			head_Body = head_bodys[i];
			if(head_Body.body.Equals(uiCenterOnChild.centeredObject)){
			
				break;
			}
		}
	
		UIPanel panel = NGUITools.FindInParents<UIPanel>(headList.gameObject);
		

		Vector3 offset = -panel.cachedTransform.InverseTransformPoint(head_Body.head.transform.position);

		if(offset.x>-31){offset.x = -31;}
			SpringPanel.Begin(panel.cachedGameObject, offset, 10f);
//		}
//		else{
//			SpringPanel.Begin(panel.cachedGameObject, panel.cachedTransform.position, 3f);
//		}
//		offset = selectItem.cachedTransform.InverseTransformPoint(head_Body.head.transform.position);
		SpringPanel.Begin(selectItem.cachedGameObject,-offset, 10f);
		selectItem.Update();
//		uiCenterOnChild.centeredObject
		Debug.Log("onDragFinished");
	}
}

