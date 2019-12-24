using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Swords
{
	public class BaronsBlade : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Baron's Blade");
            Tooltip.SetDefault("Applies lifesteal upon contact");
        }

        public override void SetDefaults()
        {
			item.damage = 22;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 1;
			item.knockBack = 4;
            item.value = 1000;
			item.rare = 2;
            item.autoReuse = true;
			item.UseSound = SoundID.Item1;
		}

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (target.type != NPCID.TargetDummy)
            {
                player.HealEffect(damage / 10);
                player.statLife += damage / 10;
            }

        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(2) == 0)
            {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), 30, 30, 5, 0f, 0f, 0, new Color(255, 255, 255), 1.5f);
            }
        }
    }
}