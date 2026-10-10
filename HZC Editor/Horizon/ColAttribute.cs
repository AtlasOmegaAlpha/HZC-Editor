using System.ComponentModel;

namespace Horizon
{
    public class ColAttribute
    {
        [DisplayName("Key")]
        public string Key { get; set; }

        [DisplayName("Value")]
        public string Value { get; set; }

        public ColAttribute() : this("NewAttribute", "float(SurfaceType)=0.000000") { }

        public ColAttribute(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Key} = {Value}";
        }
    }
}
