﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libMC.NET.Packets.Play {
    class entityProperties : Packet {

        public entityProperties(ref Minecraft mc) {
            int Entity_ID = mc.nh.wSock.readInt();
            int Count = mc.nh.wSock.readInt();

            for (int i = 0; i < Count; i++) {
                string s = mc.nh.wSock.readString();
                double d = mc.nh.wSock.readDouble();

                if (mc.minecraftWorld != null) {
                    int b = mc.minecraftWorld.getEntityById(Entity_ID);
                        if (b != -1) {
                            if (s == "horse.jumpStrength")
                                mc.minecraftWorld.Entities[b].jumpStrength = d;
                            if (s == "generic.movementSpeed")
                                mc.minecraftWorld.Entities[b].movementSpeed = d;
                    }
                }

                short elements = mc.nh.wSock.readShort(); // -- Yeah fuck this packet in particular.

                for (int x = 0; x < elements; x++) {
                    mc.nh.wSock.readLong(); // -- 128-bit integer wtf..
                    mc.nh.wSock.readLong();
                    double amount = mc.nh.wSock.readDouble();
                    byte operation = mc.nh.wSock.readByte();
                }
            }

            //ServerBound.Player player = new ServerBound.Player(ref mc);
        }
    }
}
