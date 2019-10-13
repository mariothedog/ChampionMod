using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Guns
{
    public class RiskRevolver : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Critical hits cause bullets to explode");
        }

        public override void SetDefaults()
        {
            item.damage = 15;
            item.ranged = true;
            item.noMelee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = 750000;
            item.rare = 1;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 8f;
            item.useAmmo = AmmoID.Bullet;
            item.useStyle = 5; // Holding out
            item.crit = -4; // 0 crit chance as crit is handled in the shoot method
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips[2] = new TooltipLine(mod, "CritChance", "30% critical strike chance");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (Main.rand.Next(100) < 30) // 30% crit chance
            {
                // Crit
                // Damage is multiplied in the bullet's ModifyHitNPC
                type = mod.ProjectileType("CritBulletProjectile");
            }

            return true;
        }

        public override Vector2? HoldoutOffset() // I still don't know why returning an empty Vector2 fixes it even though the default is a null vector2
        {
            return new Vector2(0, 0);
        }
    }
}