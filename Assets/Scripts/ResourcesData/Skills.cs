using UnityEngine;
using System.Collections;
using System.Xml;

public class Skills {

	public int skillID { get; set; }
	
	public int skillType { get; set; }
	
	public string skillName{ get; set; }
	
	public int equipCondition{ get; set; }

	public static Skills getInstance(string id){
		Skills skills = new Skills ();
		XmlElement note = ResourceManager.getInstance().getXmlAttribute ("skills", "skillID", id);
		skills.skillID = int.Parse (note.GetAttribute ("skillID"));
		skills.skillType = int.Parse (note.GetAttribute ("skillType"));
		skills.skillName = note.GetAttribute ("skillName");
		skills.equipCondition = int.Parse (note.GetAttribute ("equipCondition"));
		return skills;
	}
	
	public static string getKey(string id){
		return "skills_skillID_" + id;
	}

	public override string ToString(){
		return "skillID:" + skillID+" skillType:"+skillType+" skillName:"+skillName+" equipCondition:"+equipCondition;
	}



}
