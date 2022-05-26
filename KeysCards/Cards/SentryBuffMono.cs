using System;
using ModdingUtils.MonoBehaviours;
using UnityEngine;

namespace KeysCards.Cards
{
	public class SentryBuffMono : ReversibleEffect
	{
		public override void OnStart()
		{
			//this.player.GetTeamColors()
			this.gunStatModifier.spread_add = 0.07f;
			this.gunStatModifier.gravity_mult = 0.2f;
			this.gunStatModifier.projectileSpeed_mult = 1.5f;
			this.gunAmmoStatModifier.maxAmmo_add = 21;
			this.gunStatModifier.damage_mult *= 0.35f;
			this.gunStatModifier.attackSpeed_mult *= 0.22f;
			this.characterStatModifiersModifier.movementSpeed_mult *= 0.4f;

			this.colorEffect = this.player.gameObject.AddComponent<ReversibleColorEffect>();
			this.colorEffect.SetColor(this.color);
			this.colorEffect.SetLivesToEffect(1);
		}

		public override void OnOnDisable()
        {
			Destroy();
        }

		public void OnDestroy()
		{
			this.colorEffect.Destroy();
		}

		private ReversibleColorEffect colorEffect;

		private readonly Color color = new Color(0.3f, 0.3f, 0.3f, 1f);

		public float startTime;

		public float percHealth;
	}
}
