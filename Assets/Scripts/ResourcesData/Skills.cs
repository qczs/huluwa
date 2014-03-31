using UnityEngine;
using System.Collections;

public class Skills {

	private int skillID;
	
	public int SkillID {
		get { return skillID; }
		set { skillID = value; }
	}
	
	private int skillType;
	
	public int SkillType {
		get { return skillType; }
		set { skillType = value; }
	}
	
	private string skillName;
	
	public string SkillName {
		get { return skillName; }
		set { skillName = value; }
	}
	
	private int equipCondition;
	
	public int EquipCondition {
		get { return equipCondition; }
		set { equipCondition = value; }
	}


	public override string ToString(){
		return "skillID:" + skillID+" skillType:"+skillType+" skillName:"+skillName+" equipCondition:"+equipCondition;
	}
}
