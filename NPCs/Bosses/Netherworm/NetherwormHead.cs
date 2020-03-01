using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;

namespace ChampionMod.NPCs.Bosses.Netherworm
{
    internal class NetherwormHead : Netherworm
    {
		public override void SetDefaults()
		{
			// Head is 10 defence, body 20, tail 30.
			npc.CloneDefaults(NPCID.DiggerHead);
			npc.aiStyle = -1;
		}

		public override void Init()
		{
			base.Init();
			head = true;
		}

		private int attackCounter;
		public override void SendExtraAI(BinaryWriter writer)
		{
			writer.Write(attackCounter);
		}

		public override void ReceiveExtraAI(BinaryReader reader)
		{
			attackCounter = reader.ReadInt32();
		}

		public override void CustomBehavior()
		{
			if (Main.netMode != 1)
			{
				if (attackCounter > 0)
				{
					attackCounter--;
				}

				Player target = Main.player[npc.target];
				if (attackCounter <= 0 && Vector2.Distance(npc.Center, target.Center) < 200 && Collision.CanHit(npc.Center, 1, 1, target.Center, 1, 1))
				{
					Vector2 direction = (target.Center - npc.Center).SafeNormalize(Vector2.UnitX);
					direction = direction.RotatedByRandom(MathHelper.ToRadians(10));

					int projectile = Projectile.NewProjectile(npc.Center, direction * 1, ProjectileID.ShadowBeamHostile, 5, 0, Main.myPlayer);
					Main.projectile[projectile].timeLeft = 300;
					attackCounter = 500;
					npc.netUpdate = true;
				}
			}
		}
	}
}