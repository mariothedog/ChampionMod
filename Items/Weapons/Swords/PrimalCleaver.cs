using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Swords
{
	public class PrimalCleaver : ModItem
	{
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
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("ChampionMod:LightsBane");
            recipe.AddIngredient(ItemID.Muramasa);
            recipe.AddIngredient(mod.ItemType("OpticalResidue"));
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {
            crit = false;
            if (Main.rand.Next(100) < 4 + player.meleeCrit)
            {
                damage = 20 + Main.rand.Next(6);
                crit = true;
            }
        }
    }
}