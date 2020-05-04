using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Melee.Swords
{
    public class Immolator : ModItem
	{
		public override void SetDefaults()
        {
			item.damage = 60;
			item.melee = true;
			item.width = 44;
			item.height = 44;
			item.useTime = 38;
			item.useAnimation = 38;
			item.useStyle = 1;
			item.knockBack = 8;
			item.value = Item.buyPrice(gold: 1);
			item.rare = 3;
			item.UseSound = SoundID.Item1;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
        {
			if (Main.rand.NextBool(3))
            {
				// Emit dust when swinging the sword
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 127, 0f, 0f, 255, default);
			}
		}

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            // Explosive sound
            Main.PlaySound(SoundID.Item14, target.position);

            // Smoke Dust spawn
            for (int i = 0; i < 10; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, 31, 0f, 0f, 100, default, 1f);
                Main.dust[dustIndex].velocity *= 1.05f;
            }

            // Fire Dust spawn
            for (int i = 0; i < 10; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, 6, 0f, 0f, 100, default, 1.7f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].velocity *= 1.375f;
                dustIndex = Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, 6, 0f, 0f, 100, default, 1f);
                Main.dust[dustIndex].velocity *= 1.125f;
            }

            // Large Smoke Gore spawn
            int goreIndex = Gore.NewGore(new Vector2(target.position.X + target.width / 2 - 24f, target.position.Y + target.height / 2 - 24f), default, Main.rand.Next(61, 64), 0.8f);
            Main.gore[goreIndex].scale = 1.05f;
            Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.2f;
        }
    }
}
