using System;
using System.Linq;
using System.Runtime.CompilerServices;
using UnboundLib;
using UnityEngine;

namespace KeysCards.Cards
{
	public class WallSkaterMono : MonoBehaviour
	{
		// Token: 0x06000042 RID: 66 RVA: 0x00002A28 File Offset: 0x00000C28
		private void Start()
		{
			startTime = Time.time - cooldown;
			CharacterData componentInParent = base.GetComponentInParent<CharacterData>();
			this.player = componentInParent.player;
			this.block = componentInParent.block;
			this.gun = componentInParent.weaponHandler.gun;
			Block block = this.block;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002A8C File Offset: 0x00000C8C
		public void Update()
		{
			if (Time.time >= this.startTime + this.cooldown && player.data.isWallGrab)
			{
				this.ResetTimer();
				if (GetComponent<Player>().GetComponent<WallSkaterBuffMono>() != null)
				{
					GetComponent<Player>().GetComponent<WallSkaterBuffMono>().Destroy();
				}
				GetComponent<Player>().transform.gameObject.AddComponent<WallSkaterBuffMono>();
			}

		}
		private void ResetTimer()
		{
			this.startTime = Time.time;
		}

		private float cooldown = 0.1f;

		private float startTime;

		// Token: 0x04000012 RID: 18
		private Player player;

		// Token: 0x04000013 RID: 19
		private Block block;

		// Token: 0x04000014 RID: 20
		private Gun gun;
	}
}
