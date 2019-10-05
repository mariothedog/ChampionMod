using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Swords
{
	public class GlacierBlade : ModItem
	{
		public override void SetDefaults()
        {
			item.damage = 23;           
			item.melee = true;          
			item.width = 40;            
			item.height = 40;           
			item.useTime = 20;          
			item.useAnimation = 20;        
			item.useStyle = 1;          
			item.knockBack = 5;         
			item.value = Item.buyPrice(gold: 1);           
			item.rare = 2;              
			item.UseSound = SoundID.Item1;      
			item.autoReuse = true;         
		}

		public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Muramasa);
			recipe.AddIngredient(ItemID.IceBlade);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            for (int i = 0; i < 4; i++)
            {
                int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 45, 0f, 0f, 255, default);
                Main.dust[dust].noLight = true;
                Main.dust[dust].noGravity = true;
            }
        }
    }
}