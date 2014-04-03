using UnityEngine;
using System.Collections;
using System;
using System.Reflection;

public class PathUtils {

	public static string getPath(string arg){
		string path;
		#if UNITY_ANDROID   //安卓
		path = "jar:file://" + Application.dataPath + "!/assets/";
		#elif UNITY_IPHONE  //iPhone
		path = Application.dataPath + "/Raw/";
		#elif UNITY_STANDALONE_WIN || UNITY_EDITOR  //windows平台和web平台
		path = "file://" + Application.dataPath + "/";
		#else
		string.Empty;
		#endif

		Debug.Log ("a :" + (path+arg));
		return path+arg;
	}

	public static void DataBind(BaseRole obj)
	{
		
		Type type = obj.GetType();
		

		PropertyInfo[] infos = type.GetProperties();
//		PropertyInfo inf = type.GetProperty("roleName");
		Debug.Log ("aa:"+type.Name);
		foreach (PropertyInfo info in infos)
		{
				if ("roleName" == info.Name)
				{
					GameObject.Find("uname").GetComponent<UILabel>().text = info.GetValue(obj, null).ToString();
					Debug.Log ("info.Name :" + info.Name + "   value: "+ info.GetValue(obj, null).ToString());

				}

		}
		obj.updateType = false;
		
	}
//	RoleInfo{"roleName","gold", "silver"}
//
//	public string mainPanel(){
//		{, {"roleImg"}};
//
//		return null;
//	}

//	private string[,] main= 

//
//	private static IEnumerator LoadMainGameObject(string path)
//	{
//		Debug.Log(path);
//		WWW bundle = new WWW(path);
//		yield return bundle.texture;
//
//	}
//	

}
