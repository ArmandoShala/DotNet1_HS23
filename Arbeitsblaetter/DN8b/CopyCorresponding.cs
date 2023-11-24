using System.Reflection;

namespace Copy;

public class CopyCorresponding
{
    public void copyCorresponding(Object source, Object target)
    {
        if (source == null || target == null)
            throw new ArgumentNullException("Source und Target dürfen nicht null sein.");

        var sourceFields = source.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
        var targetFields = target.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);

        foreach (var sourceField in sourceFields)
        {
            var targetField = Array.Find(targetFields, f => f.Name == sourceField.Name);

            if (targetField != null && targetField.FieldType == sourceField.FieldType)
                targetField.SetValue(target, sourceField.GetValue(source));
        }
    }
}
