using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons
{
    public class ChampionMod : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ichor Blaster");
        }
        public override void SetDefaults()
        {
            item.damage = 18;
            item.ranged = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 22;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = 600000;
            item.rare = 4;
            item.UseSound = SoundID.Item12;
            item.autoReuse = true;
            item.shoot = 279;
            item.shootSpeed = 13f;
            item.useAmmo = AmmoID.Bullet;
            item.useStyle = 5; // Holding out
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.Bullet)
            {
                type = ProjectileID.IchorBullet;
            }

            return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal
        }
    }
}
