using UnityEngine;
using System.Collections;
using System.Collections.Generic;



namespace QuestSystem{


	
	public class Quest : MonoBehaviour {


		//Name
		//DescriptionSummary
		//Quest Hint
		//Quest Dialog
		//SourceID
		//QuestID
		//Chain quest and the next quest is blank
		//Chain questID

		public Quest(){

		}


	



		//Objectives
		private List<IQuestObjective> objectives;
		//Collection Objective
			//10 feathers
			//killing 4 enemies
		//Location Objectives
			//go from point A to B
			//Timed you have 10 mins to get to point B from A
		


		//Bonus objectives
		//Rewards

		//Events
			//On Completetion
			//On failed
			//On update


		private bool IsComplete(){
			for(int i = 0; i < objectives.Count; i++){
				if(!objectives[i].IsComplete false && objectives[i].IsBonus == false){
					return false;
				}
			}
			return true;    // get reward!! Fire on complete event!
				
		}


	}
}