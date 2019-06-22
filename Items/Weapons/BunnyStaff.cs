using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons
{
    public class BunnyStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons a bunny to fight for you.");
        }

        public override void SetDefaults()
        {
            item.damage = 2;
            item.summon = true;
            item.mana = 10;
            item.width = 26;
            item.height = 28;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.buyPrice(0, 30, 0, 0);
            item.rare = 11;
            item.UseSound = SoundID.Item44;
            item.shoot = mod.ProjectileType("Bunny");
            item.shootSpeed = 7f;
            item.buffType = mod.BuffType("BunnyBuff"); // summon buff
            item.buffTime = 3600; // duration of buff (3600 is 1 minute)
        }
        public override void AddRecipes()
        {
            // To do

            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LastPrism, 999);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}