using System;
using System.Data;

namespace LostAndFound
{
    internal static class DataTableColumnMetadata
    {
        private const string FillWeightKey = "FillWeight";
        private const string FormatKey = "Format";
        private const string VisibleKey = "Visible";

        public static void Configure(
            DataTable table,
            string columnName,
            string caption = null,
            float? fillWeight = null,
            string format = null,
            bool? visible = null)
        {
            if (table == null || string.IsNullOrWhiteSpace(columnName) || !table.Columns.Contains(columnName))
            {
                return;
            }

            DataColumn column = table.Columns[columnName];

            if (!string.IsNullOrWhiteSpace(caption))
            {
                column.Caption = caption;
            }

            if (fillWeight.HasValue)
            {
                column.ExtendedProperties[FillWeightKey] = fillWeight.Value;
            }

            if (!string.IsNullOrWhiteSpace(format))
            {
                column.ExtendedProperties[FormatKey] = format;
            }

            if (visible.HasValue)
            {
                column.ExtendedProperties[VisibleKey] = visible.Value;
            }
        }

        public static bool TryGetFillWeight(DataColumn column, out float fillWeight)
        {
            fillWeight = 0F;
            object value;

            if (!TryGetProperty(column, FillWeightKey, out value))
            {
                return false;
            }

            if (value is float)
            {
                fillWeight = (float)value;
                return true;
            }

            return float.TryParse(Convert.ToString(value), out fillWeight);
        }

        public static bool TryGetFormat(DataColumn column, out string format)
        {
            object value;
            format = null;

            if (!TryGetProperty(column, FormatKey, out value))
            {
                return false;
            }

            format = Convert.ToString(value);
            return !string.IsNullOrWhiteSpace(format);
        }

        public static bool TryGetVisible(DataColumn column, out bool visible)
        {
            object value;
            visible = true;

            if (!TryGetProperty(column, VisibleKey, out value))
            {
                return false;
            }

            if (value is bool)
            {
                visible = (bool)value;
                return true;
            }

            return bool.TryParse(Convert.ToString(value), out visible);
        }

        private static bool TryGetProperty(DataColumn column, string key, out object value)
        {
            value = null;
            if (column == null || !column.ExtendedProperties.ContainsKey(key))
            {
                return false;
            }

            value = column.ExtendedProperties[key];
            return true;
        }
    }
}
