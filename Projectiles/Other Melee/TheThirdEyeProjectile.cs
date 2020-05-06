using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles.OtherMelee
{
	public class TheThirdEyeProjectile : ModProjectile
    {
        public override string Texture => "ChampionMod/Items/Weapons/Melee/OtherMelee/TheThirdEye";

        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 40;
            projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
        }

		private const int DashDuration = 30;

		private const int StateSearching = 0;
		private const int StateDashing = 1;
		private const int StateReturning = 2;

		private float speed;

		private Vector2 dashDir;

		public float State
		{
			get { return projectile.ai[0]; }
			set { projectile.ai[0] = value; }
		}

		public float Timer
		{
			get { return projectile.ai[1]; }
			set { projectile.ai[1] = value; }
		}

		public override void AI()
		{
			if (State == StateSearching)
			{
				State = StateDashing;

				speed = projectile.velocity.Length();

				NPC npc = GetClosestShootableEnemy(projectile.Center);
				if (npc == null)
				{
					Vector2 pos = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
					dashDir = Vector2.Normalize(pos - projectile.Center);
				}
				else
				{
					dashDir = Vector2.Normalize(npc.Center - projectile.Center);
				}
			}

			if (State == StateDashing)
			{
				projectile.velocity = dashDir * speed;

				if (++Timer > DashDuration)
				{
					State = StateReturning;
				}
			}

			if (State == StateReturning)
			{
				Player player = Main.player[projectile.owner];
				Vector2 vecTo = player.Center - projectile.Center;
				Vector2 returnDir = Vector2.Normalize(vecTo);
				float dist = vecTo.Length();
				projectile.velocity = returnDir * speed;

				if (dist < 40f)
				{
					projectile.Kill();
				}
			}

			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(45f);
		}

		NPC GetClosestShootableEnemy(Vector2 pos)
		{
			NPC closestNPC = null;
			float closestNPCDist = 0;

			for (int i = 0; i < 200; i++)
			{
				NPC npc = Main.npc[i];

				if (npc.active && !npc.friendly && npc.type != NPCID.TargetDummy)
				{
					float dist = (npc.Center - pos).Length();
					if (dist < 480f || dist < closestNPCDist)
					{
						closestNPC = npc;
						closestNPCDist = dist;
					}
				}
			}

			return closestNPC;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			State = StateReturning;
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 30; i++)
			{
				Dust dust = Main.dust[Dust.NewDust(projectile.Center, 30, 30, 5, 0f, 0f, 0, new Color(255, 255, 255), 1.2f)];
				dust.noGravity = true;
			}
		}
	}
}