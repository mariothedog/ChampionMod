using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ChampionMod.Items.Weapons
{
    public class Frosthrower : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Uses gel for ammo");
        }

        public override void SetDefaults()
        {
            item.damage = 29;
            item.ranged = true;
            item.noMelee = true;
            item.width = 42;
            item.height = 16;
            item.scale = 0.5f;
            item.useTime = 6;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.knockBack = 0.3f;
            item.UseSound = SoundID.Item34;
            item.value = 500000;
            item.rare = 5;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("FrosthrowerProjectile");
            item.shootSpeed = 3.3f; // For flamethrower this decides how far the flames can go
            item.useAmmo = AmmoID.Gel;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("IronBar", 20);
            recipe.AddIngredient(ItemID.IllegalGunParts);
            recipe.AddIngredient(ItemID.SoulofMight, 20);
            recipe.AddIngredient(ItemID.FrostCore);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}