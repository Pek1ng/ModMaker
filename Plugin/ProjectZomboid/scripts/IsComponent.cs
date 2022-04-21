using System.Reflection;
using System.Text;

namespace ProjectZomboid.scripts
{
    public abstract class IsComponent
    {
        public string Name;

        /// <param name="name">组件的名字</param>
        public IsComponent(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 控制组件缩进
        /// </summary>
        public int Depth { get; set; } = 0;

        /// <summary>
        /// 反序列化字符串
        /// </summary>
        public IsComponent? Parse(string serializableString)
        {
            return null;
        }

        /// <summary>
        /// 串行化字符串
        /// </summary>
        public override string ToString()
        {
            //缩进标准
            string indent = "".PadLeft(Depth * 4, ' ');

            //内部缩进标准
            string internalIndent = "".PadLeft((Depth + 1) * 4, ' ');

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(indent + GetType().Name + ' ' + Name);
            stringBuilder.AppendLine(indent + "{");

            Type type = GetType();
            FieldInfo[] fieldInfoArr = type.GetFields();
            if (fieldInfoArr.Length != 0)
            {
                foreach (var fieldInfo in fieldInfoArr)
                {
                    object[] attributes = fieldInfo.GetCustomAttributes(typeof(FormatAttribute), true);

                    //子项的生成
                    if (fieldInfo.Name == "Items")
                    {
                        IList<IsComponent>? components = fieldInfo.GetValue(this) as List<IsComponent>;

                        if (components != null)
                        {
                            foreach (var component in components)
                            {
                                component.Depth = Depth + 1;
                                stringBuilder.AppendLine(component.ToString());
                            }
                        }
                    }

                    if (attributes.Length == 1)
                    {
                        switch (((FormatAttribute)attributes[0]).FormatString)
                        {
                            case FormatStringEnum.Equal:
                                stringBuilder.Append(fieldInfo.Name + "=" + fieldInfo.GetValue(this));
                                break;

                            case FormatStringEnum.Colon:
                                if (fieldInfo.FieldType == typeof(IList<string>))
                                {
                                    IList<string>? list = fieldInfo.GetValue(this) as List<string>;
                                    if (list!.Count != 0)
                                    {
                                        foreach (string str in list)
                                        {
                                            stringBuilder.AppendLine(internalIndent + fieldInfo.Name + ":" + str + ",");
                                        }
                                    }
                                }
                                else
                                {
                                    var value = fieldInfo.GetValue(this);
                                    if (value != null)
                                    {
                                        stringBuilder.AppendLine(internalIndent + fieldInfo.Name + ":" + value + ",");
                                    }
                                }
                                break;

                            default:
                                break; ;
                        }
                    }
                }
            }

            stringBuilder.Append(indent + "}");

            return stringBuilder.ToString();
        }
    }
}