namespace mis321_pa4_cmrozsa
{
    public class ConnectionString
    {
        public string cs {get; set;}
        
        public ConnectionString(){
            string server = "lyn7gfxo996yjjco.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "ub2s5wmclxqi2la8";
            string port = "3306";
            string userName = "wkw5bhpku9ik00vx";
            string password = "qyyyiyv79676ctj5";

            cs = $@"server = {server};user = {userName};database = {database};port = {port};password = {password}";
        }
    }
}