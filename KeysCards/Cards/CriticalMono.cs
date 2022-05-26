using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnboundLib;
using UnityEngine;

namespace KeysCards.Cards
{
	public class CriticalMono : MonoBehaviour
	{
		// Token: 0x06000042 RID: 66 RVA: 0x00002A28 File Offset: 0x00000C28
		private void Start()
		{
			this.player = base.GetComponent<Player>();
			this.gun = base.GetComponent<Gun>();
			checkCrit();
		}

		public void Update()
		{
			if (!this.player.data.weaponHandler.gun.IsReady())
			{
				if (able == true) {
					if (GetComponent<Player>().GetComponent<CriticalBuffMono>() != null)
					{
						GetComponent<Player>().GetComponent<CriticalBuffMono>().Destroy();
					}
					checkCrit();
					able = false;
				}
			}
            else
            {
				able = true;
            }
		}

		private void checkCrit()
        {
			System.Random rnd = new System.Random();
			int cardAmountCD = CardCheck.Amount(player, "Cloak and Dagger");
			int cardAmountPD = CardCheck.Amount(player, "Pickpockets Dagger");
			int randomInt = 1000000;
			if ((cardAmountCD + (cardAmountPD * 2)) > 4)
            {
				randomInt = 0;
            }
            else
            {
				randomInt = rnd.Next(5 - cardAmountCD - (cardAmountPD * 2));
			}
			if (randomInt == 0)
			{
				GetComponent<Player>().transform.gameObject.AddComponent<CriticalBuffMono>();
			}
		}

		private bool able = true;

		private Player player;

		private Gun gun;
	}
}
