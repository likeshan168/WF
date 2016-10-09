using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础知识.Models
{
    public class StringToHumanTypeConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                Human human = new Human();
                human.Name = value as string;
                return human;
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}
