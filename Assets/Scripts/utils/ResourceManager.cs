using UnityEngine;
using System.Collections;
using System.Xml;
using System;

public class ResourceManager
{
	
	private static ResourceManager instance;
	private static Hashtable dataCache;
	
	public static ResourceManager getInstance ()
	{
		if (instance == null) {
			instance = new ResourceManager ();
			dataCache = new Hashtable ();
		}
		return instance;  
	}
	
	public XmlElement getXmlAttribute (string xmlName, string idName, string id)
	{
		//				long a = TimeUtil.UNIX_TIMESTAMP (System.DateTime.Now);
		//				Debug.Log ("a :" + a);
		
		string url = Application.dataPath + "/Resources/data/" + xmlName + ".xml";
		//				if (Debug.isDebugBuild) {
		//						Debug.Log ("url:" + url);
		//				}
		XmlDocument xmldoc = new XmlDocument ();
		
		xmldoc.Load (url);
		XmlElement note = (XmlElement)xmldoc.SelectSingleNode ("/datas/data[@" + idName + "='" + id + "']");
		//				if (n != null) {
		//						Debug.Log (n.GetAttribute ("skillID"));
		//				}
		//				Debug.Log ("time :" + (TimeUtil.UNIX_TIMESTAMP (System.DateTime.Now) - a));
		return note;
	}
	
	public void clear ()
	{
		instance = null;
		dataCache.Clear ();
		dataCache = null;
	}
	
	public Skills getSkills (string id)
	{
		Skills skills;
		String key = Skills.getKey (id);
		if (dataCache.Contains (key) == false) {
			skills = Skills.getInstance (id);
			dataCache.Add (key, skills);
		} else {
			skills = (Skills)dataCache [key];
		}
		return skills;
	}
	
}
