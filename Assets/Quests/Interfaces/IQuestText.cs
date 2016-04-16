using UnityEngine;
using System.Collections;


namespace QuestSystem{
	
	public interface IQuestText {

		string Title { get; }
		string DescriptionSummary { get; }
		string Hint { get; }
		string Dialog { get; }


	}
}

