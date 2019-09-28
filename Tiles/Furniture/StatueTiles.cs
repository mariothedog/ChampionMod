using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ChampionMod.Tiles.Furniture
{
    class HyphenStatueTile : ModTile
    {
        public string name = "Hyphen"; // Default

        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileObsidianKill[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.addTile(Type);
            ModTranslation entryName = CreateMapEntryName();
            AddMapEntry(new Color(144, 148, 144), entryName);
            disableSmartCursor = true;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 0, 0, mod.ItemType($"{name}Statue"));
        }
    }
}