namespace ITFCode.Core.Service.Tests.TestData
{
    public class TestSimpleClass
    {
        #region Boolean Types

        public bool BoolProperty { get; set; }
        public bool? BoolNullProperty { get; set; }

        #endregion

        #region String Type

        public string StringProperty { get; set; }

        #endregion

        #region Numeric Types

        public sbyte SbyteProperty { get; set; }
        public sbyte? SbyteNullProperty { get; set; }
        public byte ByteProperty { get; set; }
        public byte? ByteNullProperty { get; set; }
        public short ShortProperty { get; set; }
        public short? ShortNullProperty { get; set; }
        public ushort UshortProperty { get; set; }
        public ushort? UshortNullProperty { get; set; }
        public int IntProperty { get; set; }
        public int? IntNullProperty { get; set; }
        public uint UIntProperty { get; set; }
        public uint? UIntNullProperty { get; set; }
        public long LongProperty { get; set; }
        public long? LongNullProperty { get; set; }
        public long ULongProperty { get; set; }
        public long? ULongNullProperty { get; set; }
        public uint NIntProperty { get; set; }
        public uint? NIntNullProperty { get; set; }

        public float FloatProperty { get; set; }
        public float? FloatNullProperty { get; set; }
        public double DoubleProperty { get; set; }
        public double? DoubleNullProperty { get; set; }
        public decimal DecimalProperty { get; set; }
        public decimal? DecimalNullProperty { get; set; }

        #endregion

        #region Guid Types 

        public Guid GuidProperty { get; set; }
        public Guid? GuidNullProperty { get; set; }

        #endregion

        #region Date Types

        public DateTime DateTimeProperty { get; set; }
        public DateTime? DateTimeNullProperty { get; set; }
        public DateTimeOffset DateTimeOffsetProperty { get; set; }
        public DateTimeOffset? DateTimeOffsetNullProperty { get; set; }

        #endregion
    }
}
