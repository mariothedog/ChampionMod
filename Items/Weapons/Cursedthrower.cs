using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ChampionMod.Items.Weapons
{
    public class Cursedthrower : ModItem
    {
        int ammoTimer = 5;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Uses gel for ammo");
        }

        public override void SetDefaults()
        {
            item.damage = 30;
            item.ranged = true;
            item.noMelee = true;
            item.width = 42;
            item.height = 16;
            item.useTime = 6;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.knockBack = 0.3f;
            item.UseSound = SoundID.Item34;
            item.value = 500000;
            item.rare = 5;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("CursedthrowerProjectile");
            item.shootSpeed = 3.3f; // For flamethrower this decides how far the flames can go
            item.useAmmo = AmmoID.Gel;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("IronBar", 20);
            recipe.AddIngredient(ItemID.IllegalGunParts);
            recipe.AddIngredient(ItemID.SoulofSight, 20);
            recipe.AddIngredient(ItemID.CursedFlame, 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override bool ConsumeAmmo(Player player)
        {
            // So it uses about the same amount of gel as the flamethrower
            if (ammoTimer == 5)
            {
                ammoTimer -= 1;
                return true;
            }
            ammoTimer -= 1;
            if (ammoTimer <= 0)
            {
                ammoTimer = 5;
            }
            return false;
        }
    }
}