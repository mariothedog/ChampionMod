using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Guns
{
    public class AlchemerGuns : ModItem
    {
        public string gun_type = "Blazing"; // Default
        public Dictionary<int, int> items = new Dictionary<int, int>() { { ItemID.FlaskofFire, 10 }, { ItemID.Hellstone, 70 } };

        public override string Texture { get { return $"ChampionMod/Items/Weapons/Guns/{gun_type}AlchemerGun"; } }

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

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("AlchemerCasing"));

            foreach(var item in items)
            {
                int id = item.Key;
                int amount = item.Value;

                recipe.AddIngredient(id, amount);
            }

            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType($"{gun_type}BulletProjectile");

            if (Math.Round(Main.rand.NextDouble(), 2) >= 0.8)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY);
                float scale = 1f - (Main.rand.NextFloat() * 0.3f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }

            return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4, 0);
        }
    }

    public class BlazingAlchemerGun : AlchemerGuns
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Inflicts \"On Fire!\" to those hit by its bullets.");
        }
    }

    public class CorrosiveAlchemerGun : AlchemerGuns
    {
        public CorrosiveAlchemerGun()
        {
            gun_type = "Corrosive";
            items = new Dictionary<int, int>() { { ItemID.FlaskofCursedFlames, 10 }, { ItemID.CursedFlame, 20 } };
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Inflicts \"Cursed Inferno\" to those hit by its bullets.");
        }
    }

    public class AcidicAlchemerGun : AlchemerGuns
    {
        public AcidicAlchemerGun()
        {
            gun_type = "Acidic";
            items = new Dictionary<int, int>() { { ItemID.FlaskofIchor, 10 }, { ItemID.Ichor, 20 } };
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Inflicts \"Ichor\" to those hit by its bullets.");
        }
    }

    public class DreadfulAlchemerGun : AlchemerGuns
    {
        public DreadfulAlchemerGun()
        {
            gun_type = "Dreadful";
            items = new Dictionary<int, int>() { { ItemID.FlaskofPoison, 10 }, { ItemID.JungleSpores, 20 } };
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Inflicts \"Poison\" to those hit by its bullets.");
        }
    }
}