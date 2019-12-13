using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Swords
{
	public class PrimalCleaver : ModItem
	{
        float tooltipAdditionalCrit = 0;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Every swing increases defense by 1 until struck (Cap - 20)");
        }

        public override void SetDefaults()
		{
            item.damage = 30;
			item.melee = true;
			item.width = 40;
			item.height = 40;
            item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 30000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.useTurn = false;
            item.autoReuse = true;
            //item.crit = -4; // Crit is handled in ModifyHitNPC
		}

		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("KingsGel"), 5);
            recipe.AddIngredient(ItemID.Gel, 100);
            recipe.AddRecipeGroup("ChampionMod:Tier4Bars", 12);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/

        /*public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips[2] = new TooltipLine(mod, "CritChance", string.Format("{0}% critical strike chance", 4 + tooltipAdditionalCrit));
        }*/

        public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {
            crit = false;
            if (Main.rand.Next(100) < 4 + player.meleeCrit)
            {
                damage = 20 + Main.rand.Next(6);
                crit = true;
            }
        }

        public override void GetWeaponCrit(Player player, ref int crit)
        {
            tooltipAdditionalCrit = crit;
        }
    }
}