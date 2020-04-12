using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Summoner
{
    public class PrimalInvoker : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons a primal clump to fight for you");
        }

        public override void SetDefaults()
        {
            item.damage = 19;
            item.summon = true;
            item.mana = 10;
            item.width = 26;
            item.height = 28;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 1;
            item.rare = 3;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = 30000;
            item.UseSound = SoundID.Item44;
            item.shoot = mod.ProjectileType("PrimalClump");
            item.buffType = mod.BuffType("PrimalClumpBuff");
        }

        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ImpStaff, 12);
            recipe.AddIngredient(ItemID.HornetStaff, 4);
            recipe.AddIngredient(mod.ItemType("OpticalResidue"));
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            player.AddBuff(item.buffType, 2, true);
            position = Main.MouseWorld;
            return true;
        }
    }
}