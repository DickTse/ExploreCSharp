using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace FixedLengthFileReader
{
    [AttributeUsage(AttributeTargets.Field)]
    class LayoutAttribute : Attribute
    {
        private int _index;
        private int _length;

        public int index
        {
            get { return _index; }
        }

        public int length
        {
            get { return _length; }
        }

        public LayoutAttribute(int index, int length)
        {
            this._index = index;
            this._length = length;
        }
    }

    class Header
    {
#pragma warning disable 0649
        [Layout(0, 4)]
        public string RecordIdentifier;
        [Layout(4, 8)]
        public DateTime ProcessingDate;
        [Layout(12, 1)]
        public char RecipientType;
        [Layout(13, 3)]
        public string RecipientNumber;
        [Layout(16, 3)]
        public string CurrencyCode;
        [Layout(19, 8)]
        public DateTime ExpectedReturningDate;
        [Layout(27, 9)]
        public string FileIdentifier;
        [Layout(36, 64)]
        public string Unused;
#pragma warning restore 0649

        public override string ToString()
        {
 	        return String.Format("RecordIdentifier: {0}; ProcessingDate: {1}; RecipientType: {2}; RecipientNumber: {3}; CurrencyCode: {4}; ExpectedReturningDate: {5}; FileIdentifier: {6}; Unused: {7}", RecordIdentifier, ProcessingDate, RecipientType, RecipientNumber, CurrencyCode, ExpectedReturningDate, FileIdentifier, Unused);
        }
    }

    class FixedLengthReader
    {
        public void Read<T>(string s, T data)
        {
            foreach (FieldInfo fi in typeof(T).GetFields())
            {
                foreach (object attr in fi.GetCustomAttributes(false))
                {
                    if (attr is LayoutAttribute)
                    {
                        LayoutAttribute la = (LayoutAttribute)attr;
                        string str = s.Substring(la.index, la.length);

                        if (fi.FieldType.Equals(typeof(bool)))
                            fi.SetValue(data, Convert.ToBoolean(str));
                        else if (fi.FieldType.Equals(typeof(char)))
                            fi.SetValue(data, str[0]);
                        else if (fi.FieldType.Equals(typeof(DateTime)))
                        {
                            if (la.length == 8)
                            {
                                DateTime date = DateTime.MinValue;
                                if (DateTime.TryParseExact(str, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out date))
                                    fi.SetValue(data, date);
                            }
                            else if (la.length == 14)
                            {
                                DateTime date = DateTime.MinValue;
                                if (DateTime.TryParseExact(str, "yyyyMMddhhmmss", null, System.Globalization.DateTimeStyles.None, out date))
                                    fi.SetValue(data, date);
                            }
                        }
                        else if (fi.FieldType.Equals(typeof(double)))
                            fi.SetValue(data, Convert.ToDouble(str));
                        else if (fi.FieldType.Equals(typeof(short)))
                            fi.SetValue(data, Convert.ToInt16(str));
                        else if (fi.FieldType.Equals(typeof(int)))
                            fi.SetValue(data, Convert.ToInt32(str));
                        else if (fi.FieldType.Equals(typeof(long)))
                            fi.SetValue(data, Convert.ToInt64(str));
                        else if (fi.FieldType.Equals(typeof(float)))
                            fi.SetValue(data, Convert.ToSingle(str));
                        else if (fi.FieldType.Equals(typeof(ushort)))
                            fi.SetValue(data, Convert.ToUInt16(str));
                        else if (fi.FieldType.Equals(typeof(uint)))
                            fi.SetValue(data, Convert.ToUInt32(str));
                        else if (fi.FieldType.Equals(typeof(ulong)))
                            fi.SetValue(data, Convert.ToUInt64(str));
                        else if (fi.FieldType.Equals(typeof(string)))
                            fi.SetValue(data, str);
                    }
                }
            }
        }
    }
}
