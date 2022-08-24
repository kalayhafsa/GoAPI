public class LoginResponse
{
    public int id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string email { get; set; }
    public int customer { get; set; }
    public string customer_name { get; set; }
    public string country_code { get; set; }
    public object app_key { get; set; }
    public int phone_country { get; set; }
    public string phone_value { get; set; }
    public bool allow_gdpr { get; set; }
    public bool allow_reminder_mail { get; set; }
    public object machine_id { get; set; }
    public int gc_type { get; set; }
    public string token { get; set; }
}