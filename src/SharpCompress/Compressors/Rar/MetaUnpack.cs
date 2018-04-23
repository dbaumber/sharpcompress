using System.IO;
using SharpCompress.Common.Rar.Headers;


namespace SharpCompress.Compressors.Rar
{
    internal class MetaUnpack : IRarUnpack
    {
        private UnpackV1.Unpack _unpackV1;
        private UnpackV2017.Unpack _unpackV2017;
        private bool _useV1;

        private UnpackV1.Unpack UnpackV1 => _unpackV1 ?? (_unpackV1 = new UnpackV1.Unpack());

        private UnpackV2017.Unpack UnpackV2017 => _unpackV2017 ?? (_unpackV2017 = new UnpackV2017.Unpack());

        public void DoUnpack(FileHeader fileHeader, Stream readStream, Stream writeStream)
        {
            if (fileHeader.CompressionAlgorithm >= 50)
            {
                _useV1 = false;
                UnpackV2017.DoUnpack(fileHeader, readStream, writeStream);
            }
            else
            {
                _useV1 = true;
                UnpackV1.DoUnpack(fileHeader, readStream, writeStream);
            }
        }

        public void DoUnpack()
        {
            if (_useV1)
            {
                UnpackV1.DoUnpack();
            }
            else
            {
                UnpackV2017.DoUnpack();
            }
        }

        public bool Suspended
        {
            get => _useV1 ? UnpackV1.Suspended : UnpackV2017.Suspended;
            set
            {
                if (_useV1)
                {
                    UnpackV1.Suspended = value;
                }
                else
                {
                    UnpackV2017.Suspended = value;
                }
            }
        }

        public long DestSize => _useV1 ? UnpackV1.DestSize : UnpackV2017.DestSize;
        public int Char => _useV1 ? UnpackV1.Char : UnpackV2017.Char;

        public int PpmEscChar
        {
            get => _useV1 ? UnpackV1.PpmEscChar : UnpackV2017.PpmEscChar;
            set
            {
                if (_useV1)
                {
                    UnpackV1.PpmEscChar = value;
                }
                else
                {
                    UnpackV2017.PpmEscChar = value;
                }
            }
        }
    }
}
