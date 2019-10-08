using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ChampionMod.Items.Weapons.Flamethrowers
{
    public class MegaMelter : ModItem
    {
        int ammoTimer = 5;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Uses gel for ammo");
        }

        public override void SetDefaults()
        {
            item.damage = 74;
            item.crit = 4; // 8 crit total
            item.ranged = true;
            item.noMelee = true;
            item.width = 42;
            item.height = 16;
            item.useTime = 6;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.knockBack = 0.3f;
            item.UseSound = SoundID.Item34;
            item.value = 1500000;
            item.rare = 8;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("MegaMelterProjectile");
            item.shootSpeed = 5.7f; // For flamethrower this decides how far the flames can go
            item.useAmmo = AmmoID.Gel;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Ultrathrower"));
            recipe.AddIngredient(ItemID.EldMelter);
            recipe.AddIngredient(ItemID.IllegalGunParts);
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

        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
    }
}