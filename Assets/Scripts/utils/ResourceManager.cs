using UnityEngine;
using System.Collections;
using System.Xml;
using System;

public class ResourceManager
{

		private static ResourceManager instance;

		public static ResourceManager getInstance ()
		{
				if (instance == null) {
//						if (Debug.isDebugBuild) {
//								Debug.Log ("aaaaa");
//						}
						instance = new ResourceManager ();
				}
				return instance;  
		}

		public Skills getSkills(string id)
		{
				Skills skills = new Skills();
				XmlElement note = getXmlAttribute ("skills", "skillID", id);
				skills.SkillID = int.Parse(note.GetAttribute("skillID"));
				skills.SkillType = int.Parse(note.GetAttribute("skillType"));
				skills.SkillName = note.GetAttribute("skillName");
				skills.EquipCondition = int.Parse(note.GetAttribute("equipCondition"));

				return skills;
		}

		// skills  skillID
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

}
