using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Swords
{
	public class BondedMultisword : ModItem
	{
		public override void SetDefaults()
        {
			item.damage = 18;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 19;
			item.useAnimation = 19;
			item.useStyle = 1;
			item.knockBack = 5;
            item.value = 20000;
			item.rare = 1;
            item.crit = 2;
			item.UseSound = SoundID.Item1;
		}

		public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("ChampionMod:Tier1Bars", 5);
            recipe.AddRecipeGroup("IronBar", 5);
            recipe.AddRecipeGroup("ChampionMod:Tier3Bars", 5);
            recipe.AddRecipeGroup("ChampionMod:Tier4Bars", 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (Main.rand.Next(5) == 0)
            {
                target.AddBuff(BuffID.Poisoned, 240);
            }

            if (Main.rand.Next(5) == 0)
            {
                target.AddBuff(BuffID.Confused, 240);
            }
        }
    }
}