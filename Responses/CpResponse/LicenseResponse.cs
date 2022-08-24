
public class LicenseResponse
{
    public int count { get; set; }
    public object next { get; set; }
    public object previous { get; set; }
    public IEnumerable<LicenseResult> results { get; set; }
}

public class Assignor
{
    public int id { get; set; }
    public string company_name { get; set; }
}

public class CategoryObject
{
    public int id { get; set; }
    public string name { get; set; }
    public string code { get; set; }
    public string info { get; set; }
    public int store_order { get; set; }
    public Translations translations { get; set; }
}

public class CdObject
{
    public int id { get; set; }
    public string company_name { get; set; }
    public PhoneNumber phone_number { get; set; }
    public int phone_country { get; set; }
    public string phone_value { get; set; }
    public int foundation_year { get; set; }
    public int country { get; set; }
    public string city_name { get; set; }
    public string district { get; set; }
    public string address { get; set; }
    public object location { get; set; }
    public string website { get; set; }
    public object tax_office { get; set; }
    public object tax_number { get; set; }
    public object re_branding_brand { get; set; }
    public List<object> service_languages { get; set; }
    public bool website_listing { get; set; }
    public int status { get; set; }
    public double credits { get; set; }
    public string created { get; set; }
    public ManagerObject manager_object { get; set; }
    public CountryObject country_object { get; set; }
    public CityObject city_object { get; set; }
    public Wallet wallet { get; set; }
    public object state { get; set; }
    public StateObject state_object { get; set; }
}

public class ChainObject
{
    public string name { get; set; }
}

public class CityObject
{
    public int id { get; set; }
    public string name { get; set; }
    public int country { get; set; }
}

public class Company
{
    public string company_legal_name { get; set; }
    public string company_name { get; set; }
}

public class CountryObject
{
    public int id { get; set; }
    public string name { get; set; }
    public string iso_code { get; set; }
    public int phone_code { get; set; }
}

public class Customerdetail
{
    public int id { get; set; }
    public int reseller { get; set; }
    public string license_email { get; set; }
    public string company_legal_name { get; set; }
    public string company_name { get; set; }
    public object chain_name { get; set; }
    public int sector { get; set; }
    public PhoneNumber phone_number { get; set; }
    public int phone_country { get; set; }
    public string phone_value { get; set; }
    public string tax_office { get; set; }
    public string tax_number { get; set; }
    public int country { get; set; }
    public string city_name { get; set; }
    public string district { get; set; }
    public string address { get; set; }
    public object location { get; set; }
    public object re_branding_brand { get; set; }
    public object app_key { get; set; }
    public string created { get; set; }
    public ManagerObject manager_object { get; set; }
    public ResellerObject reseller_object { get; set; }
    public CountryObject country_object { get; set; }
    public CityObject city_object { get; set; }
    public ChainObject chain_object { get; set; }
    public List<object> users { get; set; }
    public string main_license_version { get; set; }
    public object state { get; set; }
    public StateObject state_object { get; set; }
    public object currency { get; set; }
    public int status { get; set; }
    public int gc_type { get; set; }
}

public class DistributorObject
{
    public int id { get; set; }
    public int country_distributor { get; set; }
    public string company_name { get; set; }
    public PhoneNumber phone_number { get; set; }
    public int phone_country { get; set; }
    public string phone_value { get; set; }
    public int foundation_year { get; set; }
    public int country { get; set; }
    public string city_name { get; set; }
    public string district { get; set; }
    public string address { get; set; }
    public object location { get; set; }
    public string website { get; set; }
    public string tax_office { get; set; }
    public string tax_number { get; set; }
    public string re_branding_brand { get; set; }
    public List<ServiceLanguage> service_languages { get; set; }
    public bool website_listing { get; set; }
    public int status { get; set; }
    public double credits { get; set; }
    public string created { get; set; }
    public ManagerObject manager_object { get; set; }
    public CountryObject country_object { get; set; }
    public CityObject city_object { get; set; }
    public Wallet wallet { get; set; }
    public CdObject cd_object { get; set; }
    public object state { get; set; }
    public StateObject state_object { get; set; }
}

public class En
{
    public string name { get; set; }
    public string info { get; set; }
}

public class ManagerObject
{
    public int id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string email { get; set; }
    public int customer { get; set; }
    public string customer_name { get; set; }
    public string country_code { get; set; }
    public object app_key { get; set; }
    public PhoneNumber phone_number { get; set; }
    public int phone_country { get; set; }
    public string phone_value { get; set; }
    public bool allow_gdpr { get; set; }
    public bool allow_reminder_mail { get; set; }
    public string machine_id { get; set; }
    public int gc_type { get; set; }
    public Company company { get; set; }
    public int distributor { get; set; }
    public string distributor_name { get; set; }
    public int role { get; set; }
    public RoleObject role_object { get; set; }
    public int status { get; set; }
    public int country_distributor { get; set; }
    public string cd_name { get; set; }
    public int reseller { get; set; }
    public string reseller_name { get; set; }
}

public class PhoneNumber
{
    public int country { get; set; }
    public string number { get; set; }
    public CountryObject country_object { get; set; }
}

public class Product
{
    public int id { get; set; }
    public string name { get; set; }
    public string license_name { get; set; }
    public int category { get; set; }
    public int type { get; set; }
    public bool is_listed { get; set; }
    public bool is_listed_customer { get; set; }
    public bool is_listed_distributor { get; set; }
    public bool is_listed_cd { get; set; }
    public bool is_main_product { get; set; }
    public int regional_visibility { get; set; }
    public int store_order { get; set; }
    public double effective_price { get; set; }
    public int exchange_currency { get; set; }
    public RecommendedSalesPrice recommended_sales_price { get; set; }
    public ProductImage product_image { get; set; }
    public int license_type { get; set; }
    public int payment_schedule { get; set; }
    public string info { get; set; }
    public bool is_okc_based { get; set; }
    public bool is_activation_required { get; set; }
    public CategoryObject category_object { get; set; }
    public Translations translations { get; set; }
    public bool is_inc_gq { get; set; }
}

public class ProductImage
{
    public int id { get; set; }
    public int product { get; set; }
    public string image { get; set; }
    public int image_width { get; set; }
    public int image_height { get; set; }
}

public class RecommendedSalesPrice
{
    public int id { get; set; }
    public int product { get; set; }
    public int exchange_currency { get; set; }
    public object reseller_group { get; set; }
    public object distributor_group { get; set; }
    public object cd_group { get; set; }
    public double price { get; set; }
}

public class ResellerObject
{
    public int id { get; set; }
    public int distributor { get; set; }
    public string company_name { get; set; }
    public PhoneNumber phone_number { get; set; }
    public int phone_country { get; set; }
    public string phone_value { get; set; }
    public int foundation_year { get; set; }
    public int country { get; set; }
    public string city_name { get; set; }
    public string district { get; set; }
    public string address { get; set; }
    public object location { get; set; }
    public string website { get; set; }
    public string tax_office { get; set; }
    public string tax_number { get; set; }
    public string re_branding_brand { get; set; }
    public List<ServiceLanguage> service_languages { get; set; }
    public List<ServiceType> service_types { get; set; }
    public bool website_listing { get; set; }
    public int status { get; set; }
    public double credits { get; set; }
    public string created { get; set; }
    public DistributorObject distributor_object { get; set; }
    public ManagerObject manager_object { get; set; }
    public CountryObject country_object { get; set; }
    public CityObject city_object { get; set; }
    public Wallet wallet { get; set; }
    public object state { get; set; }
    public StateObject state_object { get; set; }
}

public class LicenseResult
{
    public long id { get; set; }
    public long customer { get; set; }
    public string license_email { get; set; }
    public Product product { get; set; }
    public DateTime start_time { get; set; }
    public DateTime end_time { get; set; }
    public List<object> extra_data { get; set; }
    public object alias { get; set; }
    public Assignor assignor { get; set; }
    public bool is_activated { get; set; }
    public bool is_valid { get; set; }
    public Customerdetail customerdetail { get; set; }
}

public class RoleObject
{
    public int id { get; set; }
    public string role_name { get; set; }
    public int resellers { get; set; }
    public int reseller_add { get; set; }
    public int reseller_update { get; set; }
    public int customers { get; set; }
    public int customer_add { get; set; }
    public int customer_update { get; set; }
    public int customer_addNote { get; set; }
    public int customer_keyReset { get; set; }
    public int leads { get; set; }
    public int lead_add { get; set; }
    public int lead_update { get; set; }
    public int lead_addNote { get; set; }
    public int store { get; set; }
    public int store_addBasket { get; set; }
    public int orders { get; set; }
    public int licenses { get; set; }
    public int licenses_assign { get; set; }
    public int periodic_licenses { get; set; }
    public int periodic_licenses_extend { get; set; }
    public int payments { get; set; }
    public int settings { get; set; }
    public int wallets { get; set; }
    public int timeline { get; set; }
    public object distributor { get; set; }
    public int distributors { get; set; }
    public int distributor_add { get; set; }
    public int distributor_update { get; set; }
    public object country_distributor { get; set; }
    public int get_payment { get; set; }
    public object reseller { get; set; }
}

public class ServiceLanguage
{
    public int language { get; set; }
}

public class ServiceType
{
    public int service_type { get; set; }
}

public class StateObject
{
    public string name { get; set; }
    public object country { get; set; }
}

public class Tr
{
    public string name { get; set; }
    public string info { get; set; }
}

public class Translations
{
    public En en { get; set; }
    public Tr tr { get; set; }
}

public class Wallet
{
    public string currency { get; set; }
    public double balance { get; set; }
}

