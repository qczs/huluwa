using UnityEngine;
using System.Collections;

public class Skills {

	public int skillID { get; set; }
	
	public int skillType { get; set; }
	
	public string skillName{ get; set; }
	
	public int equipCondition{ get; set; }

	public override string ToString(){
		return "skillID:" + skillID+" skillType:"+skillType+" skillName:"+skillName+" equipCondition:"+equipCondition;
	}
}
