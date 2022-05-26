using System;
using System.Linq;
using System.Runtime.CompilerServices;
using UnboundLib;
using UnityEngine;

namespace KeysCards.Cards
{
	public class SentryMono : MonoBehaviour
	{
		// Token: 0x06000042 RID: 66 RVA: 0x00002A28 File Offset: 0x00000C28
		private void Start()
		{
			CharacterData componentInParent = base.GetComponentInParent<CharacterData>();
			this.player = componentInParent.player;
			this.block = componentInParent.block;
			this.gun = componentInParent.weaponHandler.gun;
			Block block = this.block;
			block.BlockAction = (Action<BlockTrigger.BlockTriggerType>)Delegate.Combine(block.BlockAction, new Action<BlockTrigger.BlockTriggerType>(this.OnBlock));
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002A8C File Offset: 0x00000C8C
		private void OnBlock(BlockTrigger.BlockTriggerType blockTrigger)
		{
			if (GetComponent<Player>().GetComponent<SentryBuffMono>() == null)
			{
				GetComponent<Player>().transform.gameObject.AddComponent<SentryBuffMono>();
			}
			else
			{
				GetComponent<Player>().GetComponent<SentryBuffMono>().Destroy();
			}
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002BAC File Offset: 0x00000DAC
		private void OnDestroy()
		{
			Block block = this.block;
			block.BlockAction = (Action<BlockTrigger.BlockTriggerType>)Delegate.Remove(block.BlockAction, new Action<BlockTrigger.BlockTriggerType>(this.OnBlock));
		}

		// Token: 0x04000012 RID: 18
		private Player player;

		// Token: 0x04000013 RID: 19
		private Block block;

		// Token: 0x04000014 RID: 20
		private Gun gun;
	}
}
