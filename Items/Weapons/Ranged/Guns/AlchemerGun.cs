using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Ranged.Guns
{
    public abstract class AlchemerGun : ModItem
    {
        public string projType;

        public override void SetDefaults()
        {
            item.damage = 50;
            item.ranged = true;
            item.noMelee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = 600000;
            item.rare = 5;
            item.UseSound = SoundID.Item11;
            item.shoot = 279;
            item.shootSpeed = 10f;
            item.useAmmo = AmmoID.Bullet;
            item.useStyle = 5; // Holding out
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType(projType);

            if (Math.Round(Main.rand.NextDouble(), 2) >= 0.8)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY);
                float scale = 1f - (Main.rand.NextFloat() * 0.3f);
                perturbedSpeed *= scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }

            return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal
        }
    }
}
