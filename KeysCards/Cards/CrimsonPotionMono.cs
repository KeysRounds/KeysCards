using System;
using System.Linq;
using System.Runtime.CompilerServices;
using UnboundLib;
using UnityEngine;

namespace KeysCards.Cards
{
	public class CrimsonPotionMono : MonoBehaviour
	{
		private void Start()
		{
			startTime = Time.time - cooldown;
			this.player = base.GetComponent<Player>();
			this.block = base.GetComponentInParent<CharacterData>().block;
			Block block = this.block;
			block.BlockAction = (Action<BlockTrigger.BlockTriggerType>)Delegate.Combine(block.BlockAction, new Action<BlockTrigger.BlockTriggerType>(this.OnBlock));
		}

		private void OnBlock(BlockTrigger.BlockTriggerType blockTrigger)
		{
			if (Time.time >= this.startTime + this.cooldown)
			{
				if (GetComponent<Player>().GetComponent<CrimsonPotionBuffMono>() == null)
				{
					this.ResetTimer();
					((DamageOverTime)this.player.data.healthHandler.GetFieldValue("dot")).StopAllCoroutines();
					GetComponent<Player>().transform.gameObject.AddComponent<CrimsonPotionBuffMono>();
					Destroy(GetComponent<Player>().GetComponent<CrimsonPotionBuffMono>(), 4f);
				}
			}
		}
		private void ResetTimer()
		{
			this.startTime = Time.time;
		}

		private void OnDestroy()
		{
			Block block = this.block;
			block.BlockAction = (Action<BlockTrigger.BlockTriggerType>)Delegate.Remove(block.BlockAction, new Action<BlockTrigger.BlockTriggerType>(this.OnBlock));
		}

		private float cooldown = 7f;

		private float startTime;

		private Player player;

		private Block block;
	}
}
