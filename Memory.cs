using System;
using System.Diagnostics;

namespace SpeedForm
{
    class Memory
    {
        static Process[] processes = Process.GetProcessesByName("RocketLeague");
        static VAMemory vam = new VAMemory("RocketLeague");
        static Process GameProcess = processes[0];

        public static Tuple<float, float, float> getPos()
        {
            IntPtr Base = GameProcess.MainModule.BaseAddress + 0x230B5F8;
            Base = IntPtr.Add((IntPtr)vam.ReadInt64(Base), 0x68);
            Base = IntPtr.Add((IntPtr)vam.ReadInt64(Base), 0x770);

            IntPtr X_Coordinate = IntPtr.Add((IntPtr)vam.ReadInt64(Base), 0x40);
            IntPtr Y_Coordinate = IntPtr.Add((IntPtr)vam.ReadInt64(Base), 0x44);
            IntPtr Z_Coordinate = IntPtr.Add((IntPtr)vam.ReadInt64(Base), 0x48);

            float X = vam.ReadFloat(X_Coordinate);
            float Y = vam.ReadFloat(Y_Coordinate);
            float Z = vam.ReadFloat(Z_Coordinate);

            return Tuple.Create(X, Y, Z);
        }
    }
}
