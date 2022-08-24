
public class Category
{
    public string Name { get; set; }
    public string Header { get; set; }
    public int Appearance { get; set; }
    public int SortOrder { get; set; }
    public string UserString { get; set; }
    public int ScreenMenuId { get; set; }
    public bool MostUsedItemsCategory { get; set; }
    public List<ScreenMenuItem> ScreenMenuItems { get; set; }
    public int MenuItemCount { get; set; }
    public int ColumnCount { get; set; }
    public int MenuItemButtonHeight { get; set; }
    public string MenuItemButtonColor { get; set; }
    public double MenuItemFontSize { get; set; }
    public bool WrapText { get; set; }
    public int PageCount { get; set; }
    public bool SortAlphabetically { get; set; }
    public int MainButtonHeight { get; set; }
    public string MainButtonColor { get; set; }
    public double MainFontSize { get; set; }
    public int SubButtonHeight { get; set; }
    public int SubButtonRows { get; set; }
    public string SubButtonColorDef { get; set; }
    public int NumeratorType { get; set; }
    public object NumeratorValues { get; set; }
    public object AlphaButtonValues { get; set; }
    public object ImagePath { get; set; }
    public string ImageBase { get; set; }
    public bool IsQuickNumeratorVisible { get; set; }
    public bool IsNumeratorVisible { get; set; }
    public int NumberPadPercent { get; set; }
    public int MaxItems { get; set; }
    public int Id { get; set; }
}

public class MenuItem
{
    public string GroupCode { get; set; }
    public object Barcode { get; set; }
    public object Tag { get; set; }
    public object CustomTags { get; set; }
    public int ItemType { get; set; }
    public List<Portion> Portions { get; set; }
    public string UserString { get; set; }
    public bool IsProduct { get; set; }
    public bool IsInventoryProduct { get; set; }
    public double DefaultPrice { get; set; }
    public string Name { get; set; }
    public int Id { get; set; }
}

public class Portion
{
    public string Name { get; set; }
    public int MenuItemId { get; set; }
    public int Multiplier { get; set; }
    public List<Price> Prices { get; set; }
    public double Price { get; set; }
    public int Id { get; set; }
}

public class Price
{
    public int MenuItemPortionId { get; set; }
    public object priceTag { get; set; }
    public decimal price { get; set; }
    public int Id { get; set; }
}

public class SambaMenuResponse
{
    public int CategoryColumnCount { get; set; }
    public int CategoryColumnWidthRate { get; set; }
    public object SelectedCategoryFormat { get; set; }
    public object SelectedSubCategoryFormat { get; set; }
    public List<Category> Categories { get; set; }
    public string UserString { get; set; }
    public string Name { get; set; }
    public int Id { get; set; }
}

public class ScreenMenuItem
{
    public MenuItem MenuItem { get; set; }
    public string UserString { get; set; }
    public string Caption { get; set; }
    public string Name { get; set; }
    public string Header { get; set; }
    public int Appearance { get; set; }
    public int ScreenMenuCategoryId { get; set; }
    public int MenuItemId { get; set; }
    public int SortOrder { get; set; }
    public bool AutoSelect { get; set; }
    public object ButtonColor { get; set; }
    public int Quantity { get; set; }
    public object ImagePath { get; set; }
    public string ImageBase { get; set; }
    public double FontSize { get; set; }
    public string SubMenuTag { get; set; }
    public object ItemPortion { get; set; }
    public object OrderTags { get; set; }
    public object OrderStates { get; set; }
    public object AutomationCommand { get; set; }
    public object AutomationCommandValue { get; set; }
    public bool DisablePortionSelection { get; set; }
    public object GroupTag { get; set; }
    public int Id { get; set; }
}


