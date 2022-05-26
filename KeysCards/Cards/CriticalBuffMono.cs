using System;
using ModdingUtils.MonoBehaviours;
using UnityEngine;

namespace KeysCards.Cards
{
	public class CriticalBuffMono : ReversibleEffect
	{
		public override void OnStart()
		{
			if (CardCheck.Amount(player, "Pickpockets Dagger") > 0)
            {
				this.gunStatModifier.damage_mult *= 3f;
			}
            else
            {
				this.gunStatModifier.damage_mult *= 2f;
			}
		}
		public override void OnOnDisable()
		{
			Destroy();
		}
	}
}
