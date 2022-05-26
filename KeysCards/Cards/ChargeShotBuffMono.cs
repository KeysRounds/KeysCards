using System;
using ModdingUtils.MonoBehaviours;
using UnityEngine;

namespace KeysCards.Cards
{
	public class ChargeShotBuffMono : ReversibleEffect
	{
		public override void OnStart()
		{
			this.gunStatModifier.damage_mult *= 1.35f;

			this.colorEffect = this.player.gameObject.AddComponent<ReversibleColorEffect>();
			this.colorEffect.SetColor(player.GetTeamColors().color - new Color(0.2f,0.2f,0.2f,0f));
			this.colorEffect.SetLivesToEffect(1);
		}

		public override void OnOnDisable()
		{
			Destroy();
		}
		public void OnDestroy()
		{
			colorEffect.Destroy();
		}

		private ReversibleColorEffect colorEffect;
	}
}
