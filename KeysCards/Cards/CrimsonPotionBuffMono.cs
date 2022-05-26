using System;
using ModdingUtils.MonoBehaviours;
using UnityEngine;

namespace KeysCards.Cards
{
	public class CrimsonPotionBuffMono : ReversibleEffect
	{
		public override void OnUpdate()
		{
			data.healthHandler.Heal(data.maxHealth * 0.0625f * TimeHandler.deltaTime);
		}
		public override void OnOnDisable()
		{
			Destroy();
		}
	}
}
