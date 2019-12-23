using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Swords
{
    public class BolideBringer : ModItem
    {
        bool canShoot = true;
        double lastTimeShot;
        bool damagePlayer = false;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A standard sword morphed into a better double-edged blade\nAttacking an enemy will cause 2 meteors to fall out of the sky");
        }

        public override void SetDefaults()
        {
            item.damage = 48;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 29;
            item.useAnimation = 29;
            item.useStyle = 1;
            item.knockBack = 4;
            item.value = 1000;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.shoot = ProjectileID.Meteor1;
            item.shootSpeed = 8f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("ChampionMod:Tier2Broadswords");
            recipe.AddIngredient(ItemID.MeteoriteBar, 12);
            recipe.AddIngredient(ItemID.FallenStar, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            damagePlayer = true;

            return false;
        }

        // Meteors
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            damagePlayer = false;

            if ((Main.time - lastTimeShot) < 60)
            {
                return;
            }

            lastTimeShot = Main.time;

            for (int i = 0; i < 2; i++)
            {
                Vector2 pos = player.Center + new Vector2((-(float)Main.rand.Next(0, 401) * player.direction), -600f);
                pos.Y -= (100 * i);
                Vector2 heading = target.position - pos;
                if (heading.Y < 0f)
                {
                    heading.Y *= -1f;
                }
                if (heading.Y < 20f)
                {
                    heading.Y = 20f;
                }
                heading.Normalize();
                heading *= item.shootSpeed;
                float spdX = heading.X;
                float spdY = heading.Y + Main.rand.Next(-40, 41) * 0.02f;

                int type = Main.rand.Next(new List<int>() { ProjectileID.Meteor1, ProjectileID.Meteor2, ProjectileID.Meteor3 });
                Projectile.NewProjectile(pos.X, pos.Y, spdX, spdY, type, damage / 4, knockBack, player.whoAmI, 0f, 0.6f); // ai1 is used for the scale of the meteor projectile
            }
        }

        // Cooldown
        public override void HoldItem(Player player)
        {
            if (Main.time - lastTimeShot >= 60)
            {
                if (!canShoot)
                {
                    Main.PlaySound(25, -1, -1, 1, 1f, 0f);
                    int num3;
                    for (int num74 = 0; num74 < 5; num74 = num3 + 1)
                    {
                        int num75 = Dust.NewDust(player.position, player.width, player.height, 45, 0f, 0f, 255, default, (float)Main.rand.Next(20, 26) * 0.1f);
                        Main.dust[num75].noLight = true;
                        Main.dust[num75].noGravity = true;
                        Dust dust2 = Main.dust[num75];
                        dust2.velocity *= 0.5f;
                        num3 = num74;
                    }
                }

                canShoot = true;
            }
            else
            {
                canShoot = false;
            }

            // Double-edged sword damage
            if (player.itemAnimation == 0 && damagePlayer)
            {
                player.Hurt(new PlayerDeathReason() { SourceCustomReason = $"{player.name} was slaughtered by their own Bolide Bringer." }, item.damage / 2, player.direction * -1);
                damagePlayer = false;
            }
        }
    }
}