using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Swords
{
	public class RoyalSword : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 20;
			item.melee = true;
			item.width = 40;
			item.height = 40;
            item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 15000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.useTurn = false;
			//item.scale = 0.6f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Gel, 100);
			recipe.AddIngredient(mod.ItemType("KingsGel"), 1);
            recipe.AddRecipeGroup("ChampionMod:Tier4Bars", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Slimed, 1200, false); // Slimed debuff for 20 seconds
        }

        /*public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextFloat() < 1f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                //Vector2 position = Main.LocalPlayer.Center;
                dust = Main.dust[Terraria.Dust.NewDust(item.position, 30, 30, 13, 0f, 0f, 0, new Color(255, 255, 255), 2.236842f)];
            }
        }*/
    }
}