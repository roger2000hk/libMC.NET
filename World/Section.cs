﻿using System;
using libMC.NET.Entities;

namespace libMC.NET.World {
    public class Section {
        public byte[] Blocks;
        public byte[] Metadata;
        public byte[] BlockLight;
        public byte[] Skylight;
        public byte Y;

        public Section(byte y) {
            Y = y;
            Blocks = new byte[4096];
            Metadata = new byte[4096];
            BlockLight = new byte[4096];
            Skylight = new byte[4096];
        }

        public void SetBlock(int x, int y, int z, int id) {
            var index = x + (z * 16) + (y * 16 * 16);
            Blocks[index] = (byte)id;
        }

        public Block GetBlock(int x, int y, int z) {
            var index = x + (z * 16) + (y * 16 * 16);
            var thisBlock = new Block(Blocks[index], x, y, z, (int)Math.Floor(decimal.Divide(x, 16)), (int)Math.Floor(decimal.Divide(z, 16)));

            return thisBlock;
        }

        public int GetBlockMetadata(int x, int y, int z) {
            var index = (x + (z * 16) + (y * 16 * 16));
            var value = Metadata[index];

            return value;
        }

        public void SetBlockMetadata(int x, int y, int z, byte data) {
            var index = (x + (z * 16) + (y * 16 * 16));
            Metadata[index] = data;
        }

        public byte GetBlockLighting(int x, int y, int z) {
            var index = (x + (z * 16) + (y * 16 * 16));
            return BlockLight[index];
        }

        public void SetBlockLighting(int x, int y, int z, byte data) {
            var index = (x + (z * 16) + (y * 16 * 16));
            BlockLight[index] = data;
        }

        public byte GetBlockSkylight(int x, int y, int z) {
            var index = (x + (z * 16) + (y * 16 * 16));
            return Skylight[index];
        }

        public void SetBlockSkylight(int x, int y, int z, byte data) {
            var index = (x + (z * 16) + (y * 16 * 16));
            Skylight[index] = data;
        }
    }
}
