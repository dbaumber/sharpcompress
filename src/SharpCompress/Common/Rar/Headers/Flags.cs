namespace SharpCompress.Common.Rar.Headers
{
    internal enum HeaderType : byte
    {
        Null,
        Mark,
        Archive,
        File,
        Service,
        Comment,
        Av,
        Protect,
        Sign,
        NewSub,
        EndArchive,
        Crypt
    }

    internal static class HeaderCodeV
    {
        public const byte Rar4MarkHeader = 0x72;
        public const byte Rar4ArchiveHeader = 0x73;
        public const byte Rar4FileHeader = 0x74;
        public const byte Rar4CommentHeader = 0x75;
        public const byte Rar4AvHeader = 0x76;
        public const byte Rar4SubHeader = 0x77;
        public const byte Rar4ProtectHeader = 0x78;
        public const byte Rar4SignHeader = 0x79;
        public const byte Rar4NewSubHeader = 0x7a;
        public const byte Rar4EndArchiveHeader = 0x7b;

        public const byte Rar5ArchiveHeader = 0x01;
        public const byte Rar5FileHeader = 0x02;
        public const byte Rar5ServiceHeader = 0x03;
        public const byte Rar5ArchiveEncryptionHeader = 0x04;
        public const byte Rar5EndArchiveHeader = 0x05;
    }

    internal static class HeaderFlagsV4
    {
        public const ushort HasData = 0x8000;
    }

    internal static class EncryptionFlagsV5
    {   
        // RAR 5.0 archive encryption header specific flags.
        public const uint CHFL_CRYPT_PSWCHECK = 0x01; // Password check data is present.
        
        public const uint FHEXTRA_CRYPT_PSWCHECK = 0x01; // Password check data is present.
        public const uint FHEXTRA_CRYPT_HASHMAC = 0x02;
    }

    internal static class HeaderFlagsV5
    {
        public const ushort HasExtra = 0x0001;
        public const ushort HasData = 0x0002;
        public const ushort Keep = 0x0004;  // block must be kept during an update
        public const ushort SplitBefore = 0x0008;
        public const ushort SplitAfter = 0x0010;
        public const ushort Child = 0x0020; // ??? Block depends on preceding file block.
        public const ushort PreserveChild = 0x0040; // ???? Preserve a child block if host block is modified
    }

    internal static class ArchiveFlagsV4
    {
        public const ushort Volume = 0x0001;
        public const ushort Comment = 0x0002;
        public const ushort Lock = 0x0004;
        public const ushort Solid = 0x0008;
        public const ushort NewNumbering = 0x0010;
        public const ushort AV = 0x0020;
        public const ushort Protect = 0x0040;
        public const ushort Password = 0x0080;
        public const ushort FirstVolume = 0x0100;
        public const ushort EncryptVer = 0x0200;
    }

    internal static class ArchiveFlagsV5
    {
        public const ushort Volume = 0x0001;
        public const ushort HasVolumeNumber = 0x0002;
        public const ushort Solid = 0x0004;
        public const ushort Protect = 0x0008;
        public const ushort Lock = 0x0010;
    }

    internal static class HostOsV4
    {
        public const byte MsDos = 0;
        public const byte Os2 = 1;
        public const byte Win32 = 2;
        public const byte Unix = 3;
        public const byte MacOs = 4;
        public const byte BeOs = 5;
    }

    internal static class HostOsV5
    {
        public const byte Windows = 0;
        public const byte Unix = 1;
    }

    internal static class FileFlagsV4
    {
        public const ushort SplitBefore = 0x0001;
        public const ushort SplitAfter = 0x0002;
        public const ushort Password = 0x0004;
        public const ushort Comment = 0x0008;
        public const ushort Solid = 0x0010;

        public const ushort WindowMask = 0x00e0;
        public const ushort Window64 = 0x0000;
        public const ushort Window128 = 0x0020;
        public const ushort Window256 = 0x0040;
        public const ushort Window512 = 0x0060;
        public const ushort Window1024 = 0x0080;
        public const ushort Window2048 = 0x00a0;
        public const ushort Window4096 = 0x00c0;
        public const ushort Directory = 0x00e0;

        public const ushort Large = 0x0100;
        public const ushort Unicode = 0x0200;
        public const ushort Salt = 0x0400;
        public const ushort Version = 0x0800;
        public const ushort ExtTime = 0x1000;
        public const ushort ExtFlags = 0x2000;
    }

    internal static class FileFlagsV5
    {
        public const ushort Directory = 0x0001;
        public const ushort HasModTime = 0x0002;
        public const ushort HasCrc32 = 0x0004;
        public const ushort UnpackedSizeUnknown = 0x0008;
    }

    internal static class EndArchiveFlagsV4
    {
        public const ushort NextVolume = 0x0001;
        public const ushort DataCrc = 0x0002;
        public const ushort RevSpace = 0x0004;
        public const ushort VolumeNumber = 0x0008;
    }

    internal static class EndArchiveFlagsV5
    {
        public const ushort HasNextVolume = 0x0001;
    }
}